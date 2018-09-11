using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.common
{
    public class Eval
    {
        public static Dictionary<string, Symbol> dictionary = new Dictionary<string, Symbol>();

        public static double eval(AbstractAst a)
        {
            double v = 0.0;
             
            if(a == null)
            {
                //yyerror("internal error, null eval");
                return 0.0;

            }

            switch (a.NodeType)
            {
                /* 常量 */
                case 'K':
                    v = ((Numval)a).Number;
                    break;

                /* 名字引用 */
                case 'N':
                    v = ((SymRef)a).S.Value;
                    break;

                /* 赋值*/
                case '=':
                    ((SymAsgn)a).S.Value = eval(((SymAsgn)a).V);
                    v = ((SymAsgn)a).S.Value;
                    break;

                /* 表达式 */
                case '+':
                    v = eval(((Ast)a).L) + eval(((Ast)a).R);
                    break;
                case '-':
                    v = eval(((Ast)a).L) - eval(((Ast)a).R);
                    break;
                case '*':
                    v = eval(((Ast)a).L) * eval(((Ast)a).R);
                    break;
                case '/':
                    v = eval(((Ast)a).L) / eval(((Ast)a).R);
                    break;
                case '|':
                    v = Math.Abs(eval(((Ast)a).L));
                    break;
                case 'M':
                    v = -(eval(((Ast)a).L));
                    break;

                /* 比较 */
                case '1':
                    v = eval(((Ast)a).L) > eval(((Ast)a).R) ? 1 : 0;
                    break;
                case '2':
                    v = eval(((Ast)a).L) < eval(((Ast)a).R) ? 1 : 0;
                    break;
                case '3':
                    v = eval(((Ast)a).L) != eval(((Ast)a).R) ? 1 : 0;
                    break;
                case '4':
                    v = eval(((Ast)a).L) == eval(((Ast)a).R) ? 1 : 0;
                    break;
                case '5':
                    v = eval(((Ast)a).L) >= eval(((Ast)a).R) ? 1 : 0;
                    break;
                case '6':
                    v = eval(((Ast)a).L) <= eval(((Ast)a).R) ? 1 : 0;
                    break;

                /* 控制流 */
                /* 语法中允许空表达式，所以需要检查这种可能性 */
                /* if/then/else */
                case 'I':
                    if(eval(((Flow)a).Cond) != 0)  //检查条件成立
                    {
                        v = eval(((Flow)a).Tl);
                    }
                    else                           //检查条件不成立
                    {
                        v = eval(((Flow)a).El);
                    }
                    break;

                /* while/do */
                case 'W':
                    v = 0.0;  //默认值

                    if(((Flow)a).Tl != null)
                    {
                        while(eval(((Flow)a).Cond) != 0)
                        {
                            v = eval(((Flow)a).Tl);
                        }
                    }
                    break;

                /* 语句列表 */
                case 'L':
                    eval(((Ast)a).L);
                    v = eval(((Ast)a).R);
                    break;
                case 'F':
                    v = callBuildIn((FnCall)a);
                    break;
                case 'C':
                    v = callUser((UfnCall)a);
                    break;
                default:
                    System.Console.WriteLine("internal error: bad node {}", a.NodeType);
                    break;
            }

            return v;
        }

        /// <summary>
        /// 内置函数
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static double callBuildIn(FnCall f)
        {
            Bifs funcType = f.FuncType;
            double v = eval(f.L);

            switch (funcType)
            {
                case Bifs.B_SQRT:
                    return Math.Sqrt(v);
                case Bifs.B_EXP:
                    return Math.Exp(v);
                case Bifs.B_LOG:
                    return Math.Log(v);
                case Bifs.B_PRINT:
                    System.Console.WriteLine("= {}",v);
                    return v;
                default:
                    //yyerror("Unknown built-in function {}", funcType);
                    return 0.0;
            }
        }

        /// <summary>
        /// 定义函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name=""></param>
        public static void dodef(Symbol name, SymList syms, AbstractAst func)
        {
            name.SymbolList = syms;
            name.Func = func;
        }


        public static double callUser(UfnCall f)
        {
            Symbol fn = f.S;            /* 函数名 */
            SymList symList;            /* 虚拟参数 */
            AbstractAst args = f.L;     /* 实际参数 */
            double[] oldVal, newVal;      /* 保存的参数值*/
            double v;
            int nargs;

            if (fn.Func == null)
            {
                //yyerror("call to undefined function {}", fn.Name);
                return 0;
            }

            /* 计算参数个数 */
            symList = fn.SymbolList;
            for (nargs = 0; symList != null; symList = symList.Next)
            {
                nargs++;
            }

            /* 为保存参数值做准备 */
            oldVal = new double[nargs];
            newVal = new double[nargs];

            /* 计算参数值 */
            for (int i = 0; i < nargs; i++)
            {
                if(args == null)
                {
                    //yyerror("too few args in call to {}", fn.Name);
                    return 0.0;
                }

                if(args.NodeType == 'L')        //是否是节点列表
                {
                    newVal[i] = eval(((Ast)args).L);
                    args = ((Ast)args).R;
                }
                else                             //是否是列表末尾
                {
                    newVal[i] = eval(args);
                    args = null;
                }
            }

            /* 保存虚拟参数的旧值，赋予新值 */
            symList = fn.SymbolList;
            for(int i = 0; i < nargs; i++)
            {
                Symbol s = symList.Sym;

                oldVal[i] = s.Value;
                s.Value = newVal[i];
                symList = symList.Next;
            }

            /* 计算函数 */
            v = eval(fn.Func);

            /* 恢复虚拟参数的值 */

            return v;
            
        }

        public static Symbol lookup(string sym)
        {
            Symbol s = new Symbol(sym, 0, null, null);
            dictionary.Add(sym, s);

            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.common
{
    /* 内置函数 */
    public enum Bifs
    {
        B_SQRT = 1,
        B_EXP,
        B_LOG,
        B_PRINT
    }

    /* 符号表 */
    public class Symbol
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public AbstractAst Func { get; set; } /* 函数体 */
        public SymList SymbolList { get; set; } /* 虚拟参数列表 */

        public Symbol(string name, double value, AbstractAst func, SymList symList)
        {
            Name = name;
            Value = value;
            Func = func;
            SymbolList = symList;
        }
    }

    /* 符号列表,作为参数列表 */
    public class SymList
    {
        public Symbol Sym { get; set; }
        public SymList Next { get; set; }

        public SymList(Symbol symbol, SymList symList)
        {
            Sym = symbol;
            Next = symList;
        }
    }

    /* 抽象语法树节点 */
    /* 所有节点都有公共的初始值nodeType */
    public class AbstractAst
    {
        public int NodeType { get; set; }
    }

    /* 类型 L */
    public class Ast : AbstractAst 
    {
        public AbstractAst L { get; set; }
        public AbstractAst R { get; set; }

        public Ast(int nodeType, AbstractAst l, AbstractAst r)
        {
            NodeType = nodeType;
            L = l;
            R = r;
        }
    }

    /* 类型 F */
    public class FnCall : AbstractAst
    {
        public AbstractAst L { get; set; } /* 参数列表 */
        public Bifs FuncType { get; set; }

        public FnCall(int type, AbstractAst l)
        {
            NodeType = 'F';
            FuncType = (Bifs)type;
            L = l;
        }
    }

    /* 类型 C */
    public class UfnCall : AbstractAst
    {
        public AbstractAst L { get; set; } /* 参数列表 */
        public Symbol S { get; set; }

        public UfnCall(Symbol s, AbstractAst l)
        {
            NodeType = 'C';
            S = s;
            L = l;
        }
    }

    /* 类型 I 或者 W */
    public class Flow : AbstractAst
    {
        public AbstractAst Cond { get; set; } /* 条件 */
        public AbstractAst Tl { get; set; } /* then分支或者do语句 */
        public AbstractAst El { get; set; } /* 可选的else分支 */

        public Flow(int nodeType, AbstractAst cond, AbstractAst tl, AbstractAst el)
        {
            NodeType = nodeType;
            Cond = cond;
            Tl = tl;
            El = el;
        }
    }

    /* 类型 K */
    public class Numval : AbstractAst
    {
        public double Number { get; set; }

        public Numval(double d)
        {
            Number = d;
            NodeType = 'K';
        }
    }

    /* 类型 N */
    public class SymRef : AbstractAst
    {
        public Symbol S { get; set; }
    }

    /* 类型 = */
    public class SymAsgn : AbstractAst
    {
        public Symbol S { get; set; }
        public AbstractAst V { get; set; }

        public SymAsgn(Symbol s, AbstractAst v)
        {
            NodeType = '=';
            S = s;
            V = v;
        }
    }
}

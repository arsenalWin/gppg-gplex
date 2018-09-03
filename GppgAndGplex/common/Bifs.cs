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
        public List<Symbol> SymbolList { get; set; } /* 虚拟参数列表 */
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
    }

    /* 类型 C */
    public class UfnCall : AbstractAst
    {
        public AbstractAst L { get; set; } /* 参数列表 */
        public Symbol S { get; set; }
    }

    /* 类型 I 或者 W */
    public class Flow : AbstractAst
    {
        public AbstractAst cond { get; set; } /* 条件 */
        public AbstractAst tl { get; set; } /* then分支或者do语句 */
        public AbstractAst el { get; set; } /* 可选的else分支 */
    }

    /* 类型 K */
    public class Numval : AbstractAst
    {
        public double Number { get; set; }
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
    }
}

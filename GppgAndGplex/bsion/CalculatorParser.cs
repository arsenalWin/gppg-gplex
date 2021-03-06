// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  小兰
// DateTime: 2018/9/12 0:19:45
// UserName: stern
// Input file <calculator.y - 2018/9/12 0:19:33>

// options: lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using Test1.common;
using Test1.flex;

namespace Test1
{
public enum Tokens {error=126,
    EOF=127,NUMBER=128,NAME=129,FUNC=130,EOL=131,IF=132,
    THEN=133,ELSE=134,WHILE=135,DO=136,LET=137,CMP=138,
    UMINUS=139};

public struct ValueType
#line 6 "calculator.y"
       {
	public AbstractAst a;
	public double d;
	public Symbol s;   /* 指定符号 */
	public SymList sl;
	public int fn;     /* 指定函数 */
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[28];
  private static State[] states = new State[63];
  private static string[] nonTerms = new string[] {
      "exp", "stmt", "list", "explist", "symlist", "calclist", "$accept", };

  static Parser() {
    states[0] = new State(-24,new int[]{-6,1});
    states[1] = new State(new int[]{127,2,137,5,126,61,132,16,135,22,124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-2,3,-1,26});
    states[2] = new State(-1);
    states[3] = new State(new int[]{131,4});
    states[4] = new State(-25);
    states[5] = new State(new int[]{129,6});
    states[6] = new State(new int[]{40,7});
    states[7] = new State(new int[]{129,58},new int[]{-5,8});
    states[8] = new State(new int[]{41,9});
    states[9] = new State(new int[]{61,10});
    states[10] = new State(new int[]{132,16,135,22,124,37,40,39,45,42,128,44,129,45,130,48,131,-6},new int[]{-3,11,-2,13,-1,26});
    states[11] = new State(new int[]{131,12});
    states[12] = new State(-26);
    states[13] = new State(new int[]{59,14});
    states[14] = new State(new int[]{132,16,135,22,124,37,40,39,45,42,128,44,129,45,130,48,131,-6,134,-6,59,-6},new int[]{-3,15,-2,13,-1,26});
    states[15] = new State(-7);
    states[16] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,17});
    states[17] = new State(new int[]{133,18,138,27,43,29,45,31,42,33,47,35});
    states[18] = new State(new int[]{132,16,135,22,124,37,40,39,45,42,128,44,129,45,130,48,134,-6,131,-6,59,-6},new int[]{-3,19,-2,13,-1,26});
    states[19] = new State(new int[]{134,20,131,-2,59,-2});
    states[20] = new State(new int[]{132,16,135,22,124,37,40,39,45,42,128,44,129,45,130,48,131,-6,59,-6},new int[]{-3,21,-2,13,-1,26});
    states[21] = new State(-3);
    states[22] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,23});
    states[23] = new State(new int[]{136,24,138,27,43,29,45,31,42,33,47,35});
    states[24] = new State(new int[]{132,16,135,22,124,37,40,39,45,42,128,44,129,45,130,48,131,-6,59,-6},new int[]{-3,25,-2,13,-1,26});
    states[25] = new State(-4);
    states[26] = new State(new int[]{138,27,43,29,45,31,42,33,47,35,131,-5,59,-5});
    states[27] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,28});
    states[28] = new State(new int[]{131,-8,43,29,45,31,42,33,47,35,59,-8,133,-8,136,-8,41,-8,44,-8});
    states[29] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,30});
    states[30] = new State(new int[]{138,-9,43,-9,45,-9,42,33,47,35,131,-9,59,-9,133,-9,136,-9,41,-9,44,-9});
    states[31] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,32});
    states[32] = new State(new int[]{138,-10,43,-10,45,-10,42,33,47,35,131,-10,59,-10,133,-10,136,-10,41,-10,44,-10});
    states[33] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,34});
    states[34] = new State(-11);
    states[35] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,36});
    states[36] = new State(-12);
    states[37] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,38});
    states[38] = new State(-13);
    states[39] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,40});
    states[40] = new State(new int[]{41,41,138,27,43,29,45,31,42,33,47,35});
    states[41] = new State(-14);
    states[42] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,43});
    states[43] = new State(-15);
    states[44] = new State(-16);
    states[45] = new State(new int[]{61,46,40,55});
    states[46] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-1,47});
    states[47] = new State(new int[]{138,-17,43,29,45,31,42,33,47,35,131,-17,59,-17,133,-17,136,-17,41,-17,44,-17});
    states[48] = new State(new int[]{40,49});
    states[49] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-4,50,-1,52});
    states[50] = new State(new int[]{41,51});
    states[51] = new State(-18);
    states[52] = new State(new int[]{138,27,43,29,45,31,42,33,47,35,44,53,41,-20});
    states[53] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-4,54,-1,52});
    states[54] = new State(-21);
    states[55] = new State(new int[]{124,37,40,39,45,42,128,44,129,45,130,48},new int[]{-4,56,-1,52});
    states[56] = new State(new int[]{41,57});
    states[57] = new State(-19);
    states[58] = new State(new int[]{44,59,41,-22});
    states[59] = new State(new int[]{129,58},new int[]{-5,60});
    states[60] = new State(-23);
    states[61] = new State(new int[]{131,62});
    states[62] = new State(-27);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-7, new int[]{-6,127});
    rules[2] = new Rule(-2, new int[]{132,-1,133,-3});
    rules[3] = new Rule(-2, new int[]{132,-1,133,-3,134,-3});
    rules[4] = new Rule(-2, new int[]{135,-1,136,-3});
    rules[5] = new Rule(-2, new int[]{-1});
    rules[6] = new Rule(-3, new int[]{});
    rules[7] = new Rule(-3, new int[]{-2,59,-3});
    rules[8] = new Rule(-1, new int[]{-1,138,-1});
    rules[9] = new Rule(-1, new int[]{-1,43,-1});
    rules[10] = new Rule(-1, new int[]{-1,45,-1});
    rules[11] = new Rule(-1, new int[]{-1,42,-1});
    rules[12] = new Rule(-1, new int[]{-1,47,-1});
    rules[13] = new Rule(-1, new int[]{124,-1});
    rules[14] = new Rule(-1, new int[]{40,-1,41});
    rules[15] = new Rule(-1, new int[]{45,-1});
    rules[16] = new Rule(-1, new int[]{128});
    rules[17] = new Rule(-1, new int[]{129,61,-1});
    rules[18] = new Rule(-1, new int[]{130,40,-4,41});
    rules[19] = new Rule(-1, new int[]{129,40,-4,41});
    rules[20] = new Rule(-4, new int[]{-1});
    rules[21] = new Rule(-4, new int[]{-1,44,-4});
    rules[22] = new Rule(-5, new int[]{129});
    rules[23] = new Rule(-5, new int[]{129,44,-5});
    rules[24] = new Rule(-6, new int[]{});
    rules[25] = new Rule(-6, new int[]{-6,-2,131});
    rules[26] = new Rule(-6, new int[]{-6,137,129,40,-5,41,61,-3,131});
    rules[27] = new Rule(-6, new int[]{-6,126,131});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // stmt -> IF, exp, THEN, list
#line 34 "calculator.y"
                       { CurrentSemanticValue.a = new Flow('I', ValueStack[ValueStack.Depth-3].a, ValueStack[ValueStack.Depth-1].a, null); }
#line default
        break;
      case 3: // stmt -> IF, exp, THEN, list, ELSE, list
#line 35 "calculator.y"
                              { CurrentSemanticValue.a = new Flow('I', ValueStack[ValueStack.Depth-5].a, ValueStack[ValueStack.Depth-3].a, ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 4: // stmt -> WHILE, exp, DO, list
#line 36 "calculator.y"
                      { CurrentSemanticValue.a = new Flow('W', ValueStack[ValueStack.Depth-3].a, ValueStack[ValueStack.Depth-1].a, null); }
#line default
        break;
      case 6: // list -> /* empty */
#line 40 "calculator.y"
              { CurrentSemanticValue.a = null; }
#line default
        break;
      case 7: // list -> stmt, ';', list
#line 42 "calculator.y"
 {
		if (ValueStack[ValueStack.Depth-1].a == null)
			CurrentSemanticValue.a = ValueStack[ValueStack.Depth-3].a;
		else
			CurrentSemanticValue.a = new Ast('L', ValueStack[ValueStack.Depth-3].a, ValueStack[ValueStack.Depth-1].a);
	}
#line default
        break;
      case 8: // exp -> exp, CMP, exp
#line 50 "calculator.y"
                 { CurrentSemanticValue.a = new Ast(ValueStack[ValueStack.Depth-2].fn,ValueStack[ValueStack.Depth-3].a,ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 9: // exp -> exp, '+', exp
#line 51 "calculator.y"
                 { CurrentSemanticValue.a = new Ast('+',ValueStack[ValueStack.Depth-3].a,ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 10: // exp -> exp, '-', exp
#line 52 "calculator.y"
                 { CurrentSemanticValue.a = new Ast('-',ValueStack[ValueStack.Depth-3].a,ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 11: // exp -> exp, '*', exp
#line 53 "calculator.y"
                 { CurrentSemanticValue.a = new Ast('*',ValueStack[ValueStack.Depth-3].a,ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 12: // exp -> exp, '/', exp
#line 54 "calculator.y"
                 { CurrentSemanticValue.a = new Ast('/',ValueStack[ValueStack.Depth-3].a,ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 13: // exp -> '|', exp
#line 55 "calculator.y"
             { CurrentSemanticValue.a = new Ast('|',ValueStack[ValueStack.Depth-1].a,null); }
#line default
        break;
      case 14: // exp -> '(', exp, ')'
#line 56 "calculator.y"
                 { CurrentSemanticValue.a = ValueStack[ValueStack.Depth-2].a; }
#line default
        break;
      case 15: // exp -> '-', exp
#line 57 "calculator.y"
                           { CurrentSemanticValue.a = new Ast('M',ValueStack[ValueStack.Depth-1].a,null); }
#line default
        break;
      case 16: // exp -> NUMBER
#line 58 "calculator.y"
            { CurrentSemanticValue.a = new Numval(ValueStack[ValueStack.Depth-1].d); }
#line default
        break;
      case 17: // exp -> NAME, '=', exp
#line 59 "calculator.y"
                  { CurrentSemanticValue.a = new SymAsgn(ValueStack[ValueStack.Depth-3].s, ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 18: // exp -> FUNC, '(', explist, ')'
#line 60 "calculator.y"
                          { CurrentSemanticValue.a = new FnCall(ValueStack[ValueStack.Depth-4].fn, ValueStack[ValueStack.Depth-2].a); }
#line default
        break;
      case 19: // exp -> NAME, '(', explist, ')'
#line 61 "calculator.y"
                          { CurrentSemanticValue.a = new UfnCall(ValueStack[ValueStack.Depth-4].s, ValueStack[ValueStack.Depth-2].a); }
#line default
        break;
      case 21: // explist -> exp, ',', explist
#line 65 "calculator.y"
                       { CurrentSemanticValue.a = new Ast('L',ValueStack[ValueStack.Depth-3].a,ValueStack[ValueStack.Depth-1].a); }
#line default
        break;
      case 22: // symlist -> NAME
#line 68 "calculator.y"
                { CurrentSemanticValue.sl = new SymList(ValueStack[ValueStack.Depth-1].s, null); }
#line default
        break;
      case 23: // symlist -> NAME, ',', symlist
#line 69 "calculator.y"
                           { CurrentSemanticValue.sl = new SymList(ValueStack[ValueStack.Depth-3].s, ValueStack[ValueStack.Depth-1].sl); }
#line default
        break;
      case 25: // calclist -> calclist, stmt, EOL
#line 73 "calculator.y"
                              {
		       Console.WriteLine("= {0}", Eval.eval(ValueStack[ValueStack.Depth-2].a));
		   }
#line default
        break;
      case 26: // calclist -> calclist, LET, NAME, '(', symlist, ')', '=', list, EOL
#line 76 "calculator.y"
                                                    {
		       Eval.dodef(ValueStack[ValueStack.Depth-7].s, ValueStack[ValueStack.Depth-5].sl, ValueStack[ValueStack.Depth-2].a);
			   Console.WriteLine("Defined ", ValueStack[ValueStack.Depth-7].s.Name);
		   }
#line default
        break;
      case 27: // calclist -> calclist, error, EOL
#line 80 "calculator.y"
                        { yyerrok(); Console.WriteLine("> "); }
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 84 "calculator.y"

// No argument CTOR. By deafult Parser's ctor requires scanner as param.
public Parser(Scanner scn) : base(scn) { }

static void Main(string[] args)
{
	      
    Scanner scn = new Scanner();
    Parser parser = new Parser(scn);
	String str = "";
	while (true)
	{
		str = System.Console.ReadLine();
		scn.SetSource(str, 0);
		parser.Parse();

	}
}
#line default
}
}

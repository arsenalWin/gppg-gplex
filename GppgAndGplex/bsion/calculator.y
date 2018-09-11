%namespace Test1

%using Test1.common;
%using Test1.flex;

%union {
	public AbstractAst a;
	public double d;
	public Symbol s;   /* 指定符号 */
	public SymList sl;
	public int fn;     /* 指定函数 */
}

/* 声明记号 */
%token <d> NUMBER
%token <s> NAME
%token <fn> FUNC
%token EOL

%token IF THEN ELSE WHILE DO LET

%nonassoc <fn> CMP
%right '='
%left '+' '-'
%left '*' '/'
%nonassoc '|' UMINUS

%type <a> exp stmt list explist
%type <sl> symlist

%start calclist

%%
stmt: IF exp THEN list	{ $$ = new Flow('I', $2, $4, null); }
	| IF exp THEN list ELSE list	{ $$ = new Flow('I', $2, $4, $6); }
	| WHILE exp DO list		{ $$ = new Flow('W', $2, $4, null); }
	| exp
;

list: /* 空 */ { $$ = null; }
	| stmt ';' list 
	{
		if ($3 == null)
			$$ = $1;
		else
			$$ = new Ast('L', $1, $3);
	}
;

exp: exp CMP exp { $$ = new Ast($2,$1,$3); }
   | exp '+' exp { $$ = new Ast('+',$1,$3); }
   | exp '-' exp { $$ = new Ast('-',$1,$3); }
   | exp '*' exp { $$ = new Ast('*',$1,$3); }
   | exp '/' exp { $$ = new Ast('/',$1,$3); }
   | '|' exp { $$ = new Ast('|',$2,null); }
   | '(' exp ')' { $$ = $2; }
   | '-' exp %prec UMINUS  { $$ = new Ast('M',$2,null); }
   | NUMBER { $$ = new Numval($1); }
   | NAME '=' exp { $$ = new SymAsgn($1, $3); }
   | FUNC '(' explist ')' { $$ = new FnCall($1, $3); }
   | NAME '(' explist ')' { $$ = new UfnCall($1, $3); }
;

explist:  exp
	   |  exp ',' explist { $$ = new Ast('L',$1,$3); }
;

symlist:  NAME  { $$ = new SymList($1, null); }
       |  NAME ',' symlist { $$ = new SymList($1, $3); }
;

calclist:  /* 空 */
        |  calclist stmt EOL  {
		       Console.WriteLine("= {0}", Eval.eval($2));
		   }
		|  calclist LET NAME '(' symlist ')' '=' list EOL {
		       Eval.dodef($3, $5, $8);
			   Console.WriteLine("Defined ", $3.Name);
		   }
		|  calclist error EOL { yyerrok(); Console.WriteLine("> "); }
;

%%

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
%namespace Test1

%using Test1.common;
%using Test1.flex;

%union {
	public AbstractAst a;
	public double d;
	public Symbol s;   /* 指定符号 */
	public SymbolList sl;
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
;
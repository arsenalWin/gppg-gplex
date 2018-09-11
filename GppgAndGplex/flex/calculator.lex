%namespace Test1.flex

%using Test1;
%using Test1.common;

%option help, listing, summary, stack, minimize, parser, verbose, persistbuffer, unicode, compressNext, embedbuffers, noFiles

%{
public override void yyerror(string format, params object[] args)
{
	System.Console.Error.WriteLine("Error: line {0}, col{1} - {2}" + format, yyline, yycol, args);
}
%}

/* 浮点数指数部分 */
EXP		([Ee][-+]?[0-9]+)

%%

/* 单一字符操作符 */
"+" |
"-" |
"*" |
"/" |
"=" |
"|" |
"," |
";" |
"(" |
")" {return yytext[0];}

/* 比较操作符,所有返回值都是CMP记号*/
">" {yylval.fn = 1; return (int) Tokens.CMP;}
"<" {yylval.fn = 2; return (int) Tokens.CMP;}
"<>" {yylval.fn = 3; return (int) Tokens.CMP;}
"==" {yylval.fn = 4; return (int) Tokens.CMP;}
">=" {yylval.fn = 5; return (int) Tokens.CMP;}
"<=" {yylval.fn = 6; return (int) Tokens.CMP;}

/* 关键字 */
"if"	{return (int) Tokens.IF;}
"then"	{return (int) Tokens.THEN;}
"else"	{return (int) Tokens.ELSE;}
"while"	{return (int) Tokens.WHILE;}
"do"	{return (int) Tokens.DO;}
"let"	{return (int) Tokens.LET;}

/* 内置函数 */
"sqrt"	{yylval.fn = (int) Bifs.B_SQRT; return (int) Tokens.FUNC;}
"exp"	{yylval.fn = (int) Bifs.B_EXP; return (int) Tokens.FUNC;}
"log"	{yylval.fn = (int) Bifs.B_LOG; return (int) Tokens.FUNC;}
"print"	{yylval.fn = (int) Bifs.B_PRINT; return (int) Tokens.FUNC;}

/* 名字 */
[a-zA-Z][a-zA-Z0-9]* {yylval.s = Eval.lookup(yytext); return (int) Tokens.NAME;}

[0-9]+"."[0-9]*{EXP}?	|
"."?[0-9]+{EXP}?		{double.TryParse (yytext, NumberStyles.Float, CultureInfo.CurrentCulture, out yylval.d); return (int) Tokens.NUMBER;}

"//".*	{;}
[ \t]	{;}/* 忽略空白字符 */

\\\n { System.Console.Error.Write("c> ");} /* 忽略续行符 */

\n	{return (int) Tokens.EOL;}

.	{ yyerror("Mystery character {1}", yytext);}
%%
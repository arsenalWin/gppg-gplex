%namespace Test1.flex

%using Test1;
%using Test1.common;

%option help, listing, summary, stack, minimize, parser, verbose, persistbuffer, unicode, compressNext, embedbuffers

%{
public override void yyerror(string format, params object[] args)
{
	System.Console.Error.WriteLine("Error: line {0}, col{1} - " + format, yyline, yycol, args);
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
">" {yylval.fn = 1; return Tokens.CMP;}
"<" {yylval.fn = 2; return Tokens.CMP;}
"<>" {yylval.fn = 3; return Tokens.CMP;}
"==" {yylval.fn = 4; return Tokens.CMP;}
">=" {yylval.fn = 5; return Tokens.CMP;}
"<=" {yylval.fn = 6; return Tokens.CMP;}

/* 关键字 */
"if"	{return Tokens.IF;}
"then"	{return Tokens.THEN;}
"else"	{return Tokens.ELSE;}
"while"	{return Tokens.WHILE;}
"do"	{return Tokens.DO;}
"let"	{return Tokens.LET;}

/* 内置函数 */
"sqrt"	{yylval.fn = Bifs.B_SQRT; return Tokens.FUNC;}
"exp"	{yylval.fn = Bifs.B_EXP; return Tokens.FUNC;}
"log"	{yylval.fn = Bifs.B_LOG; return Tokens.FUNC;}
"print"	{yylval.fn = Bifs.B_PRINT; return Tokens.FUNC;}

/* 名字 */
[a-zA-Z][a-zA-Z0-9]* {yylval.s = lookup(yytext); return Tokens.NAME;}

[0-9]+"."[0-9]*{EXP}?	|
"."?[0-9]+{EXP}?		{double.TryParse (yytext, NumberStyles.Float, CultureInfo.CurrentCulture, out yylval.d); return Tokens.NUMBER;}

"//".*	{;}
[ \t]	{;}/* 忽略空白字符 */

\\\n { System.Console.Error.Write("c> ");} /* 忽略续行符 */

\n	{return Tokens.EOL;}

.	{ yyerror("Mystery character {3}", yytext);}
%%
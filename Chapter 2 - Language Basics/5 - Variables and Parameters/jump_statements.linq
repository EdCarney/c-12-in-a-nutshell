<Query Kind="Statements" />


// c# JUMP STATEMENTS are break, continue, goto, return, and throw

// BREAK
//
// end the execution of the body of an iteration or switch statement

// CONTINUE
//
// forgoes the remaining statements in a loop and immediately starts the next iteration

// GOTO
//
// transfers execution to another label in the statement block; form is 'goto statement-label',
// or 'goto case case-constant' if within a switch (only works with constants)

// a LABEL is a placeholder in a codeblock that precedes a statement; denoted with a colon suffix

int i = 1;
startLoop:
if (i <= 5)
{
	Console.WriteLine(i++ + " ");
	goto startLoop;
}

// RETURN
//
// exits a method; must return an expression with the same return type as the method; can appear
// anywhere, except in a finally block

// THROW
<Query Kind="Statements" />


// a STATEMENT BLOCK is a series of statements appearing between braces; functions
// are basically a sequence of statements

// DECLARATION STATEMENTS
//
// variable declaration introduces a new variable and optionally initializes it with an expression;
// multiple variables can be declared in a comma-separated list

string word = "rosebud";
bool young = false, rich = true;

// constant declarations require that initialization must occur with declaration

const double pi = 3.14159;

// note that local variable/constant scope extends throughout the current scope (in both directions)

// EXPRESSION STATEMENTS
//
// these are expressions that are also valid statements; must either change state or call something
// that could change state (essentially change a variable); possible expression statements are:
//	- assignment expressions (including increment/decrement)
//	- method call expressions (void and nonvoid)
//	- object instantiation expressions

// declaration statements
string s;
int x, y;
StringBuilder sb;

// expression statements
x = 1 + 2;					// assignment
x++;						// increment (assignment)
y = Math.Max(x, 5);			// assignment
Console.WriteLine(y);		// method call
new StringBuilder();		// object instantiation - technically legal, but useless

// SELECTION STATEMENTS
//
// the following mechanisms control program flow:
//	- selection statements (if, switch)
//	- conditional operator (:?)
//	- loop statements (while, do-while, for, foreach)

// IF - executes statement if bool expression is true; note the statement can be a code block
// ELSE - an if statement can optionally have an else clause, which can contain another if statement

if (2 + 2 == 5)
	Console.WriteLine("Does not compute");
else
	if (2 + 2 == 4)
		Console.WriteLine("False");

// note that the else-clause always applies to the immediately preceding if-statement; this can be
// broken with the use of {}

if (true)
	if (false)
		Console.WriteLine();
	else
		Console.WriteLine("executes");
		

// note that there is NO ELSE IF statement, this is actually just nesting if and else clauses, for e.g.:

int age = 30;

if (age >= 35)
	Console.WriteLine("be president!");
else if (age >= 21)
	Console.WriteLine("drink!");
else if (age >= 18)
	Console.WriteLine("vote!");
else
	Console.WriteLine("wait!");

// the above is technically doing the following

if (age >= 35)
{
	Console.WriteLine("be president!");
}
else
{
	if (age >= 21)
	{
		Console.WriteLine("drink!");
	}
	else
	{
		if (age >= 18)
		{
			Console.WriteLine("vote!");
		}
		else
		{
			Console.WriteLine("wait!");
		}
	}
}

// SWITCH STATEMENTS
//
// branches based on possible values a variable might have; these require an expression to be evaluated
// only one time; most common use case is to switch on CONSTANTS, and for this you are limited to built-in
// numeric types, bool, char, string, and enum types
//
// note that a case clause cannot fall through, you need to specify where execution must go next with a jump
// statement:
//	- break: jumps to end of switch
//	- goto case x: jumps to another case clause
//	- goto default: jumps to default clause
//	- other jump statements (e.g., return, throw, continue, goto label)

static void ShowCardWithName(int cardNumber)
{
	switch (cardNumber)
	{
		case 13:
			Console.WriteLine("king");
			break;
		case 12:
			Console.WriteLine("queen");
			break;
		case 11:
			Console.WriteLine("jack");
			break;
		case -1:				// in this game we treat jokers as queens
			goto case 12;
		default:
			Console.WriteLine(cardNumber);
			break;
	}
}

// you can stack cases when they should be handled the same

static void ShowCardWithoutName(int cardNumber)
{
	switch (cardNumber)
	{
		case 13:
		case 12:
		case 11:
			Console.WriteLine("face card");
			break;
		default:
			Console.WriteLine("non-face card");
			break;
	}
}

// starting in c#7 you can now switch on types (special form of switching on a pattern); there
// is no restriction on the types you can use for this, but unlike for numeric constants, the
// order of the cases can modify the result

TellMeTheType(12);
TellMeTheType("hello");
TellMeTheType(true);

static void TellMeTheType(object obj)
{
	switch(obj)
	{
		case int i:
			Console.WriteLine($"it's an int: {i}");
			break;
		case string s:
			Console.WriteLine($"it's a string: {s}");
			break;
		case DateTime dt:
			Console.WriteLine($"it's a datetime!");
			break;
		case bool b when b == true:							// you can predicate a case with the WHEN keyword
			Console.WriteLine("it's a true bool!");
			break;
		default:
			Console.WriteLine("unknown type!");
			break;
	}
}

// multiple pattern-matching cases can be stacked; in this case the compiler doesn't know which case
// was actually matched, so we can't use any of the assigned values

GetHighNumberTypes(12_000.222f);
static void GetHighNumberTypes(object obj)
{
	switch (obj)
	{
		case float f when f > 1000:
		case double d when d > 1000:
		case decimal m when m > 1000:
			Console.WriteLine($"we can refer to x here ({obj}), but not f, d, or m");
			break;
		case null:
			Console.WriteLine("Nothing here");
			break;
	}
}
<Query Kind="Statements" />


// NULL-COALESCING OPERATOR (??)
//
// instructs to take the lefthand value if it is non-null, otherwise, take the righthand
// value; note if the lefthand expression is non-null, then the righthand expression is
// never evaluated

string s1 = null;
string s2 = s1 ?? "something else";		// s2 gets "something else"
Console.WriteLine(s2);

// NULL-COALESCING ASSIGNMENT OPERATOR (??=)
//
// introduced in c#8, instructs to assign the right operand to the left operand if the left
// operand is null

string myVar = null;
myVar ??= "non-null value";
Console.WriteLine(myVar);

// NULL-CONDITIONAL OPERATOR (.?) - 'Elvis Operator'
//
// allows you to call methods and access members per usual, but if the lefthand operand is
// null the expression will evaluate to null, instead of throwing a nullref; also works
// with indexers

StringBuilder sb = null;
string s3 = sb?.ToString();

string[] words = null;
string s4 = words?[0];

// note that the operator short-circuits the expression

string s5 = sb?.ToString().ToUpper();	// ToUpper() is never evaluated
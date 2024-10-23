<Query Kind="Statements">
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>


// interpolation is done via the $; any object type can be used and its
// ToString() method will automatically be called

int i = 5;
string s1 = $"an interpolated string with {i}";
Console.WriteLine(s1);

// you can use a colon plus a format string to change the format of the
// interpolated value

var maxValue = byte.MaxValue;
Console.WriteLine($"255 in hex is {maxValue:X2}");  // X2 = two-digit, capitalized hex

// if you need to use a colon in the expression, you must wrap it in ()

bool b = true;
Console.WriteLine($"the max value of a short in hex is {(b ? short.MaxValue : int.MaxValue):x2}");

// since c#10, interpolated strings can be const so long as the expression(s)
// are also const strings

const float f = 3.14159f;
const string s2 = "hello";
const string s3 = $"{s2}, world!";

// const string s4 = $"pi is {f}";	// compile-time error; const value must be string

// since c#11, interpolated string expressions can now span multiple lines

Console.WriteLine($"this interpolation spans {1 +
1} lines");

// raw string literals can also be interpolated

string s4 = $"""
	here is a raw string literal
	with { 5 / 5 } interpolations
""";
Console.WriteLine(s4);

// if you need to include a brace in an interpolated string...
//	- for a normal string, just repeat the brace character
// 	- for a raw string literal, repeat the $ char to increase the number of
// 	  braces required to register the interpolation part

string s5 = $"here is a {{normal}} interpolated string with {2} braces";
Console.WriteLine(s5);

string s6 = $$"""
	for a {raw} string literal, I repeat the $
	char; in this case I used $$ to indicate the
	interpolated part will use {{2}} braces
""";
Console.WriteLine(s6);
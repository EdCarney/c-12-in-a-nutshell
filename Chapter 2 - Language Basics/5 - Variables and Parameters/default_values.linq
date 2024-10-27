<Query Kind="Statements" />


// all type instances have a default value that is the result of bitwise zeroing memory
//	- ref types and nullable value types => null
// 	- numeric and enum types => 0
//	- char type => '\0'
//	- bool type => false

Console.WriteLine(default(decimal));

decimal d = default;	// you can omit the type with default when it can be inferred
Console.WriteLine(d);
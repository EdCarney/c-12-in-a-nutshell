<Query Kind="Statements" />


// strings are an immutable sequence of unicode chars; escape sequences work the same

string a = "Here's a tab: \t";

// strings are reference types, but use value-type equality checks

string s1 = "hello there";
string s2 = "hello there";
Console.WriteLine(s1 == s2);

// a verbatim string can be used to avoid having to escape characters
// (at the cost of NOT being able to escape characters)

string v1 = @"\\server\folder1\folder2\my_file.cs";
Console.WriteLine(v1);

// use two double-quotes to escape the double quote in a verbatim string

string v2 = @"<customer ""id""=123></customer>";
Console.WriteLine(v2);

// concatenate strings with +
// note this can be inefficient when used repeatedly, use a StringBuilder
// in those cases instead
<Query Kind="Statements" />


// since c#11 you can use the u8 suffix to indicate UTF-8 encoding

ReadOnlySpan<byte> utf8 = "ab→cd"u8; // arrow is 3 bytes, all others are 1
string utf16 = "ab→cd"; 			 // all chars are 2 bytes

Console.WriteLine(utf8.Length);
Console.WriteLine(System.Text.ASCIIEncoding.Unicode.GetByteCount(utf16));

// this is primarily meant for advanced scenarios (e.g. handling raw JSON)
// to improve performance hotspots
<Query Kind="Statements" />

// floats and doubles have special values

// divide nonzero by zero to get infinity
Console.WriteLine(1.0 / 0.0);
Console.WriteLine(1.0 / -0.0);
Console.WriteLine(-1.0 / 0.0);
Console.WriteLine(-1.0 / -0.0);

// divide zero by zero to get NaN
Console.WriteLine(0.0 / 0.0);

// arithmetic w/ inf also yields NaN
Console.WriteLine((1.0 / 0.0) - (1.0 / 0.0));

// must use special function to test for NaN
Console.WriteLine(double.IsNaN(0.0 / 0.0));

// decimal values are preferred for system dealing with real numbers
// (i.e. those generated from real-world measurements) because they
// are stored internally as base10...but they are also ~10 times
// slower than doubles/floats

float f = 0.1f;
decimal d = 0.1M;

Console.WriteLine(f + f + f + f + f + f + f + f + f + f);  // not quite 1.0
Console.WriteLine(d + d + d + d + d + d + d + d + d + d);  // exactly 1.0
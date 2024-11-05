<Query Kind="Statements" />



/* FLAGS ENUMS

enum members can be combined; to prevent ambiguities when doing this the combined members require you
to explicitly specify the assigned values (typically in powers of 2)

we do this because we can then work with the bitwise operators to determine combinations of the enum
values (because each value flips only one bit)

the [Flags] attribute should always be used when the memebers of an enum type are combinable; this does
two things:
	- indicates to others that the enum is combinable
	- modifies the ToString() call to default to print a formatted string with the values (instead of a number)
	
convention is to give the enum a plural name when the types are combinable (e.g. BorderSides instead of
BorderSide)

you can also include baked-in combination members within the enumeration itself

*/


// now if you want to specify some combination of two values...
var leftRight = BorderSides_1.Left | BorderSides_1.Right;			// 11000000

if ((leftRight & BorderSides_1.Left) != 0)							// 11000000 & 10000000 = 10000000 != 0
{
	Console.WriteLine("Includes left");
}

Console.WriteLine(leftRight.ToString());

[Flags]
enum BorderSides_1 : byte
{
	None   = 0,
	Left   = 1,
	Right  = 1 << 1,
	Top    = 1 << 2,
	Bottom = 1 << 3,
	
	// combination members
	LeftRight = Left | Right,
	TopBottom = Top | Bottom,
	All = LeftRight | TopBottom,
}

// equivalent definition to BorderSides_1

[Flags]
enum BorderSides_2
{
	None   = 0,
	Left   = 1,
	Right  = 2,
	Top    = 4,
	Bottom = 8,
}

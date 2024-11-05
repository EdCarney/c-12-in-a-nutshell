<Query Kind="Statements" />


/* ENUM BASICS

let you specify a group of named numeric constants; by default the values are int's and their numeric values
0, 1, 2,... are automatically assigned in the order of the enum members

you can optionally specify a different underlying integral type (e.g. byte), and optionally specify all or some
of the underlying values for the members

enums can be converted to/from the underlying integral value with an explicit cast; this can also be done to
convert enums of differing type

numeric literal 0 is a special case, and you can assign 0 directly to any enum type w/out an explicit cast

*/

// converting enum to underlying value

int i = (int)BorderSide_Custom.Left;
BorderSide_Custom side = (BorderSide_Custom)i;
bool leftOrRight = (int)side <= 2;

// converting b/w enum types

var h_1 = (HorizontalAlignment)BorderSide_Custom.Right;
var h_2 = (HorizontalAlignment)BorderSide_Custom.Top;

Console.WriteLine(Enum.GetName(h_1));		// prints Right since the int values are the same
Console.WriteLine(Enum.GetName(h_2));		// prints null, since 10 is outside the range for HorizontalAlignment

public enum BorderSide_Default
{
	Left, Right, Top, Bottom
}

public enum BorderSide_Custom : byte
{
	Left = 1,
	Right,			// values increment from last specified (2)
	Top = 10,
	Bottom			// values increment from last specified (11)
}

public enum HorizontalAlignment
{
	Left = 1,
	Right = 2,
	Center
}
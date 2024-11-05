<Query Kind="Statements" />



/* TYPE SAFETY

recall that an enum value could be converted from an integral value that is not defined
in the enum range; or you could get there from arithmetric on enums

invalid values could break logic where you assume an enum is always within range; could add
more logic to handle this, or could use the static Enum.IsDefined() method

however, this WILL NOT work for flagged enums; you need to be more careful with these values;
the trick below works because the [Flag] attribute will force ToString() to output a nice
comma-separated list of enum values if the combination is valid, otherwise it will output the
integral value; so if the parse is successful then you know the flag is NOT defined

*/

var b1 = (BorderSide)1234;				// outside of valid values

var b2 = BorderSide.Bottom;
b2++;									// no error, but now outside of valid values

if (Enum.IsDefined(typeof(BorderSide), b1))
{
	Console.WriteLine("valid value");
}
else
{
	Console.WriteLine("invalid value");
}

for (int i = 0; i <= 16; i++)
{
	var side = (BorderSides)i;
	Console.WriteLine(IsFlagDefined(side) + ": " + side);
}

static bool IsFlagDefined(Enum e) => !int.TryParse(e.ToString(), out _);

public enum BorderSide { Left, Right, Top, Bottom }

[Flags]
public enum BorderSides
{
	Left = 1,
	Right = 2,
	Top = 4,
	Bottom = 8,
}
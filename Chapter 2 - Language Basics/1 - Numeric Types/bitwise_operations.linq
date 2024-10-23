<Query Kind="Statements" />


short bin = -10;

// there are all the normal complement/or/xor/and bitwise operators

Console.WriteLine($"Base10: {bin}");
Console.WriteLine($"Binary:     {FormatBinary(bin)}");

// note that for signed int's the highest order bit denotes the sign
// this is because for negative values we use the complement
// (e.g. sbyte with -1 is 0b_1111_1111, but you can't specify that via a literal)

// the shift right operator (>>) will keep the highest order bit for
// signed types; the unsigned shift right (>>>) will not

Console.WriteLine($"bin >> 1  = {FormatBinary(bin >> 1)}");
Console.WriteLine($"bin >>> 1 = {FormatBinary(bin >>> 1)}");

static string FormatBinary(int value)
{
	string binStr = Convert.ToString(value, 2);
	var groupsOfFour = Enumerable.Range(0, binStr.Length / 4).Select(i => binStr.Substring(i * 4, 4));
	return "0b_" + string.Join('_', groupsOfFour);
}
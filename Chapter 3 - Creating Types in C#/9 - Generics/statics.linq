<Query Kind="Statements" />


/* STATIC GENERIC DATA

the static data for a generic is unique FOR EACH CLOSED TYPE

*/

Console.WriteLine(++Bobby<int>.Count);			// 1
Console.WriteLine(++Bobby<int>.Count);			// 2
Console.WriteLine(++Bobby<double>.Count);		// 1
Console.WriteLine(++Bobby<string>.Count);		// 1


class Bobby<T>
{
	public static int Count;
}
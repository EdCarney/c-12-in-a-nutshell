<Query Kind="Statements" />


/* GENERIC DELEGATES

delegates, like the methods they represent, can use generic type parameters

*/

int[] values = [ 1, 2, 3 ];
Util.Transform(values, Square);

foreach (int x in values)
	Console.Write(x + ", ");

int Square(int x) => x * x;

class Util
{
	public static void Transform<T>(T[] values, Transformer<T> t)
	{
		for (int i = 0; i < values.Length; i++)
			values[i] = t(values[i]);
	}
}

delegate T Transformer<T>(T x);
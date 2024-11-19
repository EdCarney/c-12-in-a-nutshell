<Query Kind="Statements" />


/* DELEGATES FOR PLUG-INS

delegate variables are assigned their methods at runtime, which is useful for writing plug-in methods; this
can be done by having a method take a delegate as a parameter and having the method use that delegate

methods that use delegates (i.e. use other methods) are HIGHER-ORDER FUNCTIONS; this includes methods that
take delegates as args and those that return methods

*/

int[] values = [ 1, 2, 3 ];

Transform(values, Square);
foreach (int i in values)
	Console.Write(i + ", ");
Console.WriteLine();

Transform(values, Cube);
foreach (int i in values)
	Console.Write(i + ", ");
Console.WriteLine();
	
void Transform(int[] values, Transformer t)
{
	for (int i = 0; i < values.Length; i++)
		values[i] = t(values[i]);
}

int Square(int x) => x * x;
int Cube(int x) => x * x * x;

delegate int Transformer(int x);
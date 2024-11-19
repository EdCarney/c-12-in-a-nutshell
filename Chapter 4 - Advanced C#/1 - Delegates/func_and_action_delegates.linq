<Query Kind="Statements" />


/* FUNC AND ACTION DELEGATES

with generic type parameters, we can start to define delegates that are general enough to work
for any return type and any reasonable number of args

these are the Func and Action types! => they are just generalized delegates, with Func having a
nonvoid return type and Action having a void return type

	delegate TResult Func<out TResult>();
	delegate TResult Func<in T, out TResult>(T arg);
	delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
	...up to T16
	
	delegate void Action();
	delegate void Action<in T>(T arg);
	delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
	...up to T16

note that when c# was introduced the Func and Action types didn't exist because generics didn't
exist; this is why we still have the delegate type, it is all but deprecated at this point

note that many problems you would use a delegate for could also be solved with an INTERFACE; a
delegate could be preferred in cases where:
	- the interface would define only a single method
	- multicast capability is needed
	- the delegate subscriber needs to implement the interface multiple times

*/

// the transformer example in other files in this section can use a Func

int[] values = [ 1, 2, 3 ];

Util.Transform(values, Cube);
foreach (int x in values)
	Console.Write(x + ", ");
Console.WriteLine();

Util.Transform(values, new Squarer());
foreach (int x in values)
	Console.Write(x + ", ");
Console.WriteLine();

int Cube(int x) => x * x * x;

// note that we (the subscriber) would need to implement the equivalent interface multiple times in this example;
// combined with the interface only being one method, this becomes quite cumbersome; a delegate is likely a
// better solution here

class Squarer : ITransformer
{
	public int Transform(int x) => x * x;
}

class Cuber : ITransformer
{
	public int Transform(int x) => x * x * x;
}

class Util
{
	public static void Transform<T>(T[] values, Func<T, T> t)
	{
		for (int i = 0; i < values.Length; i++)
			values[i] = t(values[i]);
	}
	
	public static void Transform(int[] values, ITransformer t)
	{
		for (int i = 0; i < values.Length; i++)
			values[i] = t.Transform(values[i]);
	}
}

interface ITransformer
{
	int Transform(int x);
}
<Query Kind="Statements" />


/* TYPEOF FOR GENERICS

open generic types do not exist at runtime (they are closed as part of compilation); however, it is possible
for UNBOUND generic types to exist at runtime as a Type; the only way to specify this is via typeof



*/

Type a1 = typeof(A<>);				// UNBOUND due to lack of type arguments
Type a2 = typeof(A<,>);				// using commas to indicate multiple type args

Type a3 = typeof(A<int,int>);		// you can naturally use typeof on a closed generic type as well

class A<T> { }
class A<T1, T2> { }

class B<T>
{
	void X()
	{
		Type t = typeof(T);			// T is open but closed at runtime
	}
}
<Query Kind="Statements" />



// OBJECT TYPE
//
// object is the ultimate base class in c#; all types (both reference AND value) can be upcast to an
// object (c#'s TYPE UNIFICATION)
//
// to cast from a value type to an object, the CLR works to bridge the sematics b/w ref and val types;
// this is BOXING and UNBOXING


var stack = new Stack();
stack.Push("hello world");
stack.Push(1);


// BOXING and UNBOXING
//
// boxing: going from value-type instance to a reference-type instance (either an object or interface)
// unboxing: reverses the boxing; the runtime checks that the stated value type matches the object type
//
// invalid cast exception thrown if check fails
//
// note that boxing COPIES the value instance into a new object and unboxing copies the contents back
// into a value instance; as such, changing the value intance does not affect the boxed copy

int x = 9;
object obj = x;		// boxes the int
int y = (int)obj;	// unboxes the int

object obj_1 = 3.1459;
int z = (int)(double)obj_1;		// first (double) unboxes the value, then (int) does a numeric conversion


int a = 10;
object obj_2 = a;
a = 5;
Console.WriteLine(obj_2);		// prints 10 since boxed object is unaffected


public class Stack
{
	int position;
	object[] items = new object[10];
	public void Push(object obj) => items[position++] = obj;
	public object Pop() => items[--position];
}

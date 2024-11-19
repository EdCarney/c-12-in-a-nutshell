<Query Kind="Statements" />


/* DELEGATES

a delegate type is an object that knows how to call a method

delegate types define the kind of methods that the delegate instance can call (i.e. defines the method return and
parameter types)

delegate instances literally act as a delegate for the caller; the caller invokes the delegate, and the delegate
calls the target method (decoupling the caller from the target method)

generally, delegates are similar to CALLBACKS

*/

Transformer t = Square;								// creates a delegate INSTANCE

Transformer t_long = new Transformer(Square);		// also creates a delegate instance; the above version is shorthand

int ans = t(5);								// calls the method that the delegate instance points to

int ans_long = t.Invoke(5);					// also calls the method; the above version is shorthand for this

int Square(int x) => x * x;

delegate int Transformer(int x);			// a delegate type that can point to any method that takes an int and returns an int
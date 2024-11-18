<Query Kind="Statements" />



/* TYPE PARAMETERS AND CONVERSIONS

c#'s cast operator can perform several types of conversion, including:
	- numeric
	- reference
	- boxing/unboxing
	- custom
	
which type of conversion will take place is determined at COMPILE TIME based on the types of the operands;
this can be problematic for generic params where the precise type might be unknown at compile time and can
thus generate a compiler error

common when trying to explicitly cast reference types; the compiler cannot know if you mean to cast the generic
type using a custom conversion; solution is to use 'as' since it is unambiguous since it cannot do custom
conversions

*/



StringBuilder Foo<T> (T arg)
{
	if (arg is StringBuilder)
		//return (StringBuilder)arg;		// compile-time error; could be a custom conversion
		return arg as StringBuilder;
}


// could also first convert to an object, since these conversions are assumed to be either reference conversions
// or un/boxing conversions

StringBuilder Foo1<T>(T arg)
{
	return (StringBuilder)(object)arg;		// no error
}

int Foo2<T>(T arg)
	//=> (int)arg;							// error, could be an unboxing, numeric, or custom conversion
	=> (int)(object)arg;					// unambiguous, must be an unboxing
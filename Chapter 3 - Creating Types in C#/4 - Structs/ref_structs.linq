<Query Kind="Statements" />



// REF STRUCTS
//
// value types (and therefore structs) live in-place (whereever their variable was declared) on the stack
//
// BUT, if a value type appears as a field in a class, then it will actually reside on the heap, since the
// class is allocated on the heap
//
// also, arrays of structs will live on the heap, and boxing a struct to an object will also send it to the
// heap
//
// a 'ref struct' allows you to state that you only ever want it to reside on the stack; attempting to do
// this for something that would require the struct to be on the heap causes a compile time error
//
// similarly, ANY feature that would result in potential heap allocation for ref structs is prohibited by
// the compiler


// ref structs were primarily introduced for use with Span<T> and ReadOnlySpan<T>; since they exist only on
// the stack, it is possible for them to safely wrap stack-allocated memory


var points = new Point[100];		// lives on the heap

// compiler error!
// var refPoints = new RefPoint[100];

class MyClass
{
	Point p;						// lives on the heap
	
	// compiler error!
	//RefPoint rp;
}

struct Point
{
	public int X, Y;
}

ref struct RefPoint
{
	public int X, Y;
}
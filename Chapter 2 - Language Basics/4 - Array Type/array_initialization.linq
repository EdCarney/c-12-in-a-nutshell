<Query Kind="Statements" />


// the array types all inherit from System.Array

// multiple ways to initialize

char[] arr1 = new char[] { 'a', 'e', 'i', 'o', 'u' };
char[] arr2 = { 'a', 'e', 'i', 'o', 'u' };

// since c#12 there is also the collection expression; this is especially
// useful when creating an array to pass into a method

char[] arr3 = [ 'a', 'e', 'i', 'o', 'u' ];

// default initialization for an array's values is always the result of
// bitwise zeroing of the memory

var arr4 = new PointStruct[100];	// creates 100 instances and sets members to default values
var arr5 = new PointClass[100];		// creates an array of 100 nulls

// note also that an array itself is a reference type and so can be null

PointStruct[] arr6 = null;

// simplified initialization can be done by omitting the new operator and type qualifications
// (and possibly using a collection expression), which is shown above
//
// OR you can use var

// note that with var for arrays, there are the following considerations
// - all elements must be implicitly convertible to a single type
// - one of the elements must be of that single type
// - there must be exactly one best type

var x1 = new[] { 1, 100_000_000_000 };

// also note that the implicit var typing cannot be used with an array initializer or collection expression

/*
var x2 = { 1, 100_000_000_000 };	// invalid array initializer
var x3 = [ 1, 100_000_000_000 ];	// invalid collection expression
*/

// type decalarations

struct PointStruct { int X, Y; }
class PointClass { public int X, Y; }
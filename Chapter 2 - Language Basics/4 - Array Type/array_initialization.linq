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

struct PointStruct { int X, Y; }
class PointClass { public int X, Y; }

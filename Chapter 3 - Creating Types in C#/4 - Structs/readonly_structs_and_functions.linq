<Query Kind="Statements" />



// READONLY STRUCTS and FUNCTIONS
//
// a struct can be marked as readonly, in which case all of the fields must also be
// readonly
//
// for more granular control, a structs functions can individually be marked as readonly,
// which causes the compiler to generate an error if the function attempts to modify the
// any field


readonly struct ReadonlyPoint
{
	public readonly int X, Y;
}

struct Point
{
	public int X, Y;
	public readonly int GetX => X;
	
	// compiler error!
	/*
	public readonly int ResetX => X = 0;
	*/
}
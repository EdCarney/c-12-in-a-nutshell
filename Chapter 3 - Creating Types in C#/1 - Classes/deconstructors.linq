<Query Kind="Statements" />


// note that DECONSTRUCTORS in C# are different than deconstructors in other languages like C++
// in that they are intended to deconstruct an object back into its component parts (rather than
// clean up an object after its use, this is where disposal methods come in)

var test = new Test(3, 4);

// this calls the deconstructor	
(float width_1, float height_1) = test;

// note the above is the same as doing this
test.Deconstruct(out float width_2, out float height_2);

// you can also use implicit typing here
var (width_3, height_3) = test;

// also note if the variables already exist, you can just reference
// them in the dtor; this is a DECONSTRUCTING ASSIGNMENT
float width_4, height_4;
(width_4, height_4) = test;

// starting in c#10, you can mix existing variables with new variables when deconstructing
float width_5;
(width_5, float height_5) = test;

class Test
{
	public readonly float Width, Height;
	
	public Test(float width, float height)
	{
		Width = width;
		Height = height;
	}
	
	public void Deconstruct(out float width, out float height)
	{
		width = Width;
		height = Height;
	}
}

class Test_2
{
	public readonly float Width, Height;
	
	// deconstructing assignment can be used to simplify a ctor as well
	public Test_2(float width, float height) =>
		(Width, Height) = (width, height);
}
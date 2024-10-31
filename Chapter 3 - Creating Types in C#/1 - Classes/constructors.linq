<Query Kind="Statements" />



class Wine
{
	public decimal Price;
	public int Year;
	
	// OVERLOADING CTORS
	//
	// a class/struct can overload ctors; to avoid duplication, one ctor can be used to call another;
	// with this, the called ctor executes first
	
	public Wine(decimal price) => Price = price;
	public Wine(decimal price, int year) : this(price) => Year = year;
	
	// IMPLICIT CTOR
	//
	// c# auto-generates an empty/default ctor for classes when you have not defined any ctors; once
	// you define a ctor, the default ctor is no longer generated
	
	
	// FIELD INITIALIZATION
	//
	// note that field initialization happens before the ctor executes, and the fields are initialized
	// in order
	public string Notes = "Meh wine";
}
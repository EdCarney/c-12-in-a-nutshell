<Query Kind="Statements" />


public class Stock
{
	private decimal currentPrice;	// the BACKING FIELD
	private decimal sharesOwned;
	
	// PROPERTIES
	//
	// properties are declared like fields, but with get/set blocks; these are the property ACCESSORS;
	// note the set block has an implicit 'value' parameter containing the caller's value
	//
	// this gives the implementer total control over the getting/setting of a value without needing to
	// create dedicated get/set methods (see Java)
	//
	// read-only properties only define a get method; write-only properties only define a set method
	// (write-only properties are rarely used)
	
	public decimal CurrentPrice
	{
		get { return currentPrice; }
		set { currentPrice = value; }
	}
	
	// write-only property
	public decimal SharesOwned
	{
		set { sharesOwned = value; }
	}
	
	// read-only property
	public decimal TotalWorth
	{
		get { return currentPrice * sharesOwned; }
	}
	
	// EXPRESSION-BODIES PROPERTIES
	//
	// you can replace some syntax if you have only a single expression to execute for the get/set
	
	// read-only expression-bodied property
	public decimal TotalWorth_Expression => currentPrice * sharesOwned;
	
	// read/write expression-bodied property
	public decimal CurrentPrice_Expresion
	{
		get => currentPrice;
		set => currentPrice = value;
	}
	
	// AUTOMATIC PROPERTIES
	//
	// introduced in c#3, for simple property implementations where you just need a backing private field
	// that is get/set, you can use the compiler to generate an automatic property
	//
	// note that the set accessor can be private/protected if you want the property to be read-only to
	// other types
	
	public decimal CurrentPrice_AutoProperty { get; private set; }
	
	// PROPERY INITIALIZERS
	//
	// you can add property initializers to automatic properties similar to fields
	
	public int MaxAvailable { get; } = 1_000;	// read-only field w/ initial value
}
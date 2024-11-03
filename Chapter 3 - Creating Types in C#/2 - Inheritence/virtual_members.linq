<Query Kind="Statements" />



// VIRTUAL FUNCTION MEMBERS
//
// can be overridden by subclasses; methods, properties, indexers, and events can all be virtual;
// note that fields can NOT be virtual, in that case you would need to use a property
//
// an overridden method can call the base class implementation via the 'base' keyword
//
// note that calling a virtual method from a ctor is potentially dangerous; consider if a subclass
// decides to override the virtual method at some point, but they are unaware that the base class
// calls the virtual method; their overridden implementation would be called during the base class
// ctor but it's not likely that the subclass authors are aware of this and they could make assumptions
// about the state of the class that are not true since it hasn't been fully initialized


// COVARIANT RETURN TYPES
//
// from c#9, you can overrid a method or property get to return a more derived type (i.e. a subclass of the
// type returned by the virtual method
//
// consider the example in Asset and House below; House's Clone() is allowed to return a derived type (House)
// because it doesn't break the contract; Asset requires Clone() to return an Asset type, House's Clone() returns
// a House type which derives from Asset (so it returns an Asset type + some extra stuff)

var msft = new Stock { Name = "MSFT", SharesOwned = 100 };
var house = new House { Name = "Lil' Green", Mortgage = 360_000 };

Console.WriteLine(msft.Liability);
Console.WriteLine(house.Liability);

public class Asset
{
	public string Name;
	public virtual decimal Liability => 0;				// virtual property
	public virtual Asset Clone()						// virtual method to demo covariant return types
		=> new Asset { Name = Name };
}

public class Stock : Asset
{
	public long SharesOwned;							// stock doesn't need to override this (no liability, uses Asset's implementation)
	public override Stock Clone()						// override w/ covariant return types (returns Stock instead of Asset)
		=> new Stock
		{
			Name = Name,
			SharesOwned = SharesOwned
		};
}

public class House : Asset
{
	public decimal Mortgage;
	public override decimal Liability => Mortgage;		// House overrides this with the value of the Mortgage
	public override House Clone()
		=> new House
		{
			Name = Name,
			Mortgage = Mortgage 
		};
}
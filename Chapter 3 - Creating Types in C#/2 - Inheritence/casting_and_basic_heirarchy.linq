<Query Kind="Statements" />


// basic class inheritence

var msft = new Stock { Name = "MSFT", SharedOwned = 60 };
var house = new House { Name = "Lil' Green", Mortgage = 350_000 };

// polymorphic calls to display; note only reference types are polymorphic
Display(msft);
Display(house);

// CASTING and REFERENCE CONVERSIONS
//
// can implicitly upcast to a base class (up the heirarchy) or explicitly downcast
// to a subclass reference (down the heirarchy)
//
// this performs a reference conversion; a new reference is created that points to the
// same object
//
// if a downcast fails it generates an InvalidCastException at runtime (an example of
// runtime type checking)

Asset a = msft;						// upclass to Asset
Console.WriteLine(a == msft);		// true since both references point to the same object

Stock s = (Stock)a;					// downcast to Stock
Console.WriteLine(s == a);			// still true, we are still pointing to the same object

// method taking base class; asset can refer to any object that
// subclasses Asset
static void Display(Asset asset)
{
	Console.WriteLine(asset.Name);
}

public class Asset
{
	public string Name;
}

public class Stock : Asset
{
	public long SharedOwned;
}

public class House : Asset
{
	public decimal Mortgage;
}
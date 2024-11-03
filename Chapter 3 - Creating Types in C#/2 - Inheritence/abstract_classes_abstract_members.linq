<Query Kind="Statements" />



// ABSTRACT CLASSES and ABSTRACT MEMBERS
//
// abstract classes can never be instantiated, only its concrete subclasses can be instantiated;
// abstract classes can define abstract members, which are similar to virtual members except that
// they have no default implementation (must be provided by the subclass)
//
// abstract members are implemented in subclasses via the override keyword; subclasses MUST implement
// the abstract members of their base class


public abstract class Asset
{
	// note no implementation
	public abstract decimal NetValue { get; }
}

public class Stock : Asset
{
	public long SharesOwned;
	public decimal CurrentPrice;
	
	// override just like a virtual method
	public override decimal NetValue => SharesOwned * CurrentPrice;
}
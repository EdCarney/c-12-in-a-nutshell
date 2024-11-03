<Query Kind="Statements" />



// BASE KEYWORD
//
// allows you to both access overridden function members from within the subclass AND allows you to
// call the base class ctor
//
// when used to get a base class's implementation of a virtual member that is overridden in the subclass,
// we will always get the base class's implementation regardless of the runtime
//
// this works the same even if the member is hidden (although in that case you could also cast to the base
// class before invoking the member to get the base class implementation)

// CTORS AND INHERITANCE
//
// base class ctors are accessible to a derived class, but they are never automatically inherited; derived
// classes must redefine and ctors they want to expose
//
// base class ctors can be called with the base() keyword; note that base class ctors will always execute
// first when this is done
//
// note that if the subclass ctor omits the 'base', then the base type's parameterless ctor is called implicitly;
// if the base class doesn't have one, then subclasses are forced to use 'base' in their ctors; this means that
// if your base class only has a multiparameter ctor, then any derived class MUST use it

public class Asset
{
	public string Name;
	public virtual decimal Liability => 0;
	public virtual Asset Clone()
		=> new Asset { Name = Name };
}

public class House : Asset
{
	public decimal Mortgage;
	
	public override decimal Liability		// uses base to get Asset's implementation of Liability
		=> base.Liability + Mortgage;
	
	public override House Clone()
		=> new House
		{
			Name = Name,
			Mortgage = Mortgage 
		};
}

public class BaseClass
{
	public int X;
	public BaseClass() { }
	public BaseClass(int x) => X = x;
}

public class SubClass : BaseClass
{
	public int Y;
	public SubClass(int x, int y) : base(x) => Y = y;
}
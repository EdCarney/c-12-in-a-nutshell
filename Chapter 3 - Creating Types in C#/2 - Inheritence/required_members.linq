<Query Kind="Statements" />


// REQURIED MEMBERS
//
// the requirement for a subclass to invoke a base class ctor base become annoying, especially
// if their are many ctors w/ many params; sometimes object initializers are preferred
//
// from c#11 you can mark a field/property as required to require that it be set via an obj
// initializer when constructed
//
// if you also want to have ctors, then you can use the [SetsRequiredMembers] attribute to bypass
// the required member restriction


var a1 = new Asset
{
	Name = "a1",
	Liability = 4.0m
};

// var a2 = new Asset();				// compiler error
var a2 =  new Asset("a2");				// note this is allowed due to the property, but it doesn't actually set Liability

public class Asset
{
	public required string Name;		// Name must be populated via an obj initializer
	public required decimal Liability;
	
	public Asset() { }					// will need to set Name in obj init
	
	[System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
	public Asset(string name)			// up to the programmer to make sure ALL required members are actually set here
	{
		Name = name;
	}
}
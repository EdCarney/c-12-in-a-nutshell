<Query Kind="Statements" />


// HIDING INHERITED MEMBERS
//
// a base and subclass can define identical members; the member in the subclass is said to HIDE
// the member in the base class
//
// typically this happens by accident when the superclass defines a new member that has already
// been defined in a subclass; the compiler will generate a warning in this case
//
// if you want to intentionally hide a member in your base class, then you can apply the NEW
// MEMBER MODIFIER to signal the intent (this simply hides the warning that would otherwise appear)



// NEW vs OVERRIDE
//
// overridden members will take effect even if the subclass is upcast to its superclass; however,
// new members will not, if a subclass hides a superclass' implementation and the subclass is
// upcast to its superclass then the superclass' implementation is used

var over_1 = new Override();
var new_2 = new New();

var base_1 = over_1 as Base;
var base_2 = new_2 as Base;

over_1.Foo();	// Override.Foo()
base_1.Foo();	// Override.Foo()

new_2.Foo();	// New.Foo()
base_2.Foo();	// Base.Foo()

public class A { public int Counter = 1; }
public class B : A { public int Counter = 2; }		// the compiler generates a warning here

public class C { public int Counter = 1; }
public class D : C { public new int Counter = 2; }	// no compiler warning here



public class Base
{
	public virtual void Foo() => Console.WriteLine("Base.Foo()");
}

public class Override : Base
{
	public override void Foo() => Console.WriteLine("Override.Foo()");
}

public class New : Base
{
	public new void Foo() => Console.WriteLine("New.Foo()");
}
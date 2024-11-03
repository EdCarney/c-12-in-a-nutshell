<Query Kind="Statements" />



// SEALING
//
// you can seal a class or a class member to prevent any overriding in subclasses; this includes sealing
// a member that you are overriding (i.e. House could seal its overridden implementation of Asset's
// virtual Liability() method to prevent further overriding)
//
// note without sealing, a virtual member can continue to be overridden by further subclasses; a sealed
// member can't be overridden, but it can be hidden
//
// interestingly, if a sealed overridden member is hidden in a subclass (e.g. Mansion's TotalLiability)
// but then that subclass is upcast past the point where the member was sealed (e.g. Mansion is upcase
// to an Asset and the TotalLiability was sealed in House), the sealed overridden member is still used

Mansion m = new Mansion { Name = "Big Green", Mortgage = 1_000_000, MansionTaxRate = 0.345 };
House h = m;
Asset a1 = m;
Asset a2 = h;

Console.WriteLine($"My: {m.MyLiability}, Total: {m.TotalLiability}");		// uses the overridden and new members
Console.WriteLine($"My: {h.MyLiability}, Total: {h.TotalLiability}");		// uses the overridden and sealed members
Console.WriteLine($"My: {a1.MyLiability}, Total: {a1.TotalLiability}");		// uses the overridden and sealed
Console.WriteLine($"My: {a2.MyLiability}, Total: {a2.TotalLiability}");		// uses the overridden and sealed members

public class Asset
{
	public string Name;
	public virtual decimal MyLiability => 0;
	public virtual decimal TotalLiability => 0;
}

public class House : Asset
{
	public decimal Mortgage;
	public override decimal MyLiability => Mortgage / 2;      		// non-sealed overridden member
	public sealed override decimal TotalLiability => Mortgage;		// sealed overridden member
}

public class Mansion : House
{
	public double MansionTaxRate = 0.25;
	public override decimal MyLiability								// non-sealed overridden member can be further overridden
		=> Mortgage * (decimal)(1 + MansionTaxRate) / 2;
	public new decimal TotalLiability								// can't use or override the sealed member, but can hide it
		=> Mortgage * (decimal)(1 + MansionTaxRate);
}
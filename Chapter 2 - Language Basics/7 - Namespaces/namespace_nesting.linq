<Query Kind="Statements" />


// NAME SCOPING dictates that names declared in outer namespaces can be used within
// inner namespaces unqualified

namespace Outer
{
	class Class1 { }
	
	namespace Inner
	{
		// using Class1 unqualified
		class Class2 : Class1 { }
	}
}

// you can use a PARITIALLY QUALIFIED NAME to refer to a different branch in your heirarchy

namespace MyTradingCompany
{
	namespace Common
	{
		class ReportBase { }
	}
	
	namespace ManagementReporting
	{
		// partial namespace
		class SalesReport : Common.ReportBase { }
	}
}

// NAME HIDING occurs when an inner and outer namespace have the same type name; in this case
// the inner name wins; the name must be qualified if you want to use the outer type name; note
// that all type names are converted to their FQN at compile time (there are no unqualified or
// partially qualified names in IL)

namespace Outer
{
	class Foo { }
	
	namespace Inner
	{
		class Foo { }
		
		class Test
		{
			Foo f1;			// Inner.Foo instance
			Outer.Foo f2;	// Outer.Foo instance
		}
	}
}
<Query Kind="Statements" />



// EXTERN
//
// extern aliases allow you to reference two types that have the same FQNs; this can only
// happen when the namespaces and types are defined in two separate assemblies

// to resolve the ambiguity, first you need to modify the project's csproj file and assign
// unique aliases to each reference

// then you use the 'extern alias' directive to reference your new aliases



// NAMESPACE ALIAS QUALIFIERS
//
// inner namespaces hide outer namespace types; this can typically be resolved by using the FQN
// but sometimes this still doesn't work, e.g.

namespace N
{
	class A
	{
		// is Run() creating a new instance of the nested class B, or an instance of class B
		// contained in namespace A?
		//
		// in this case the compiler gives higher precedence to the current namespace, so it
		// will use the nested class B
		//
		// but, generally, there are two ways to resolve this conflict:
		//	- the global namespace
		//	- the set of extern aliases
		
		static void Run() => new A.B();		
		public class B { }
	}
}

namespace A
{
	class B { }
}

// let's try again

namespace N_1
{
	class A_1
	{
		static void Run()
		{
			Console.WriteLine(new A_1.B_1());
			
			// this refers to the namespace A_1
			Console.WriteLine(new global::A_1.B_1());
		}
		
		public class B_1 { }
	}
}

namespace A_1
{
	class B_1 { }
}

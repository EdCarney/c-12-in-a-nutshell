<Query Kind="Statements" />

using Outer.Middle.Inner;

// namespaces are heirarchical and form an integral part of a type's name; note that they are
// independent of the assemblies (DLL files) that are the units of deployment, they also have
// no impact on member visibility

// 'namespace' keyword defines a namespace for types within the enclosing block

namespace Outer.Middle.Inner
{
	class Class1 { }
	class Class2 { }
}

// the dots here represent heirarchy; the above is the same as

namespace Outer
{
	namespace Middle
	{
		namespace Inner
		{
			class Class3 { }
		}
	}
}

// types that are not defined in any namespace are said to reside in the GLOBAL NAMESPACE; this
// is technically where the Outer namespace above resides

// c#10 let's you define FILE-SCOPED NAMESPACES that define the namespace for all types within a file;
// this is defined by specifying the namespace at the top of the file

// namespaces are imported via the USING DIRECTIVE; note this can be done within a namespace to reduce
// the scope of the directive
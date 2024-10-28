<Query Kind="Statements" />


// importing a namespace can result in a type name conflict; you can import just the specific
// types you need to help resolve this, giving each type an alias

using SysPropertyInfo = System.Reflection.PropertyInfo;		// ALIASING a type
using R = System.Reflection;								// ALIASING a whole namespace

// from c#12, the using directive can be used to alias ANY type (e.g. arrays)

using NumberList = double[];								// ALIASING any type
NumberList nl = [ 2.4, 118.9 ];

class Program
{
	SysPropertyInfo p1;
	R.PropertyInfo p2;
}
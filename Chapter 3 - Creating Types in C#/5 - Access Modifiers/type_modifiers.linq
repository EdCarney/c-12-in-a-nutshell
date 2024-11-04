<Query Kind="Statements" />


// ACCESS MODIFIERS
/*
	- PUBLIC
		- fully accessible
		- implicit accessibility for enums and interfaces
	- INTERNAL
		- accessible only within the current assembly OR friend assemblies
		- default accessibility for non-nested types
	- PRIVATE
		- accessible only within the containing type
		- default for members of a class or struct
	- PROTECTED
		- accessible only within the containing type or subclasses
	- PROTECTED INTERNAL
		- union of protected and internal
		- accessible to current/friend assemblies and to subclasses
	- PRIVATE PROTECTED 
		- intersection of protected and internal
		- accessible to the containing type or from a subclass in the SAME ASSEMBLY
		- less accessible than just protected or just internal
	- FILE
		- since c#11
		- accessible only from within the same file
		- intended for use by source generators
*/


namespace MyNamespace
{
	class Class1 { }							// internal to assembly (by default)
	public class Class2 { }						// visible outside of assembly
	
	
	class ClassA { int x; }						// x is private (by default)
	class ClassB { internal int x; }			// x is visible to other types in the same/friend assemblies
	
	
	class Base
	{
		void Foo() { }
		protected void Bar() { }
	}
	
	class Subclass : Base
	{
		private void Test1()
		{
			// Foo();							// compiler error; Foo() is private
		}
		
		private void Test2()
		{
			Bar();								// fine, since Base.Bar() is protected
		}
	}
}
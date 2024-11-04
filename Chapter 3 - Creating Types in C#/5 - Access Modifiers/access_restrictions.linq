<Query Kind="Statements" />


/*
ACCESS RESTRICTIONS

accessibility must be identical when overriding a base class function; the only exception is when
overriding a 'protected internal' member in another assembly, in which case the override is just
'protected'

subclasses are allowed to be MORE restrictive than their base classes, but not less

a type CAPS the accessibiilty of its members (e.g., if a type is marked internal, which is the default,
then its members will be at most internal even if they are marked public)
*/


[assembly: InternalsVisibleTo("Friend")]                // allows internal visibility to friend assemblies
namespace Mine
{
	class Base { protected virtual void Foo() { } }
	class Sub : Base
	{
		protected override void Foo() { }				// must be protected
	}
}
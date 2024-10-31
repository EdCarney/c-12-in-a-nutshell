<Query Kind="Statements" />


// CLR PROPERTY IMPLEMENTATION
//
// c# property accessors interally compile to get_<property_name> and set_<property_name> methods;
// init accessors are compiled like set accessors, but they have an extra flag
//
// simple nonvirtual properties are INLINED by the JIT compiler so that their perf is the same as
// a field (inlining meaning that the property method call is replaced with the method body at the
// calling sight

var note_1 = new Note { Pitch = 200, Duration = 500 };

public class Note
{
	// GET/SET ACCESSIBILITY
	//
	// get and set can have different access levels; typical use case is for the getter to be
	// public and the setter to be protected/private; note in this case the property itself is
	// still public
	
	string _owner;
	readonly int _pitch;
	
	public string Owner
	{
		get { return string.IsNullOrWhiteSpace(_owner) ? "Nobody" : _owner; }
		private set { _owner = $"{value} - since {DateTime.UtcNow}"; }
	}
	
	// INIT-ONLY SETTERS
	//
	// since c#9 you can declare a property accessor with init instead of set; these act like
	// read-only properties, except they can also be set via an object initializer
	//
	// the alternative to this is to have read-only (get only) properties that are populated
	// via a ctor and possibly optional parameters, but recall this breaks binary compatibility
	// if you were to add/modify an optional parameter in the future
	//
	// adding a new init-only property breaks nothing
	
	public long Duration { get; init; } = 100;

	// init-only accessors get also provide more detailed implementations
	//
	// note here that _pitch is readonly, init-only setters are allowed to modify internal readonly
	// fields; this is required since otherwise the backing field (_pitch) could be updated in the
	// class and thus the property (Pitch) would fail to be internally immutable

	public int Pitch
	{
		get => _pitch;
		init => _pitch = value > 0 ? value : 0;
	}
}
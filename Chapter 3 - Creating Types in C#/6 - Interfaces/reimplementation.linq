<Query Kind="Statements" />


/* REIMPLEMENTING AN INTERFACE

a subclass can reimplement any interface member already implemented by a base class; this hijacks the
implementation regardless of whether the member is marked as virtual or not

this will also work regardless of if the member is implemented implicitly or explicitly, but typically
you only want to use this for explicit implementation

if the interface member you are reimplementing was IMPLICITLY implemented in the base class, then you
are able to cast to the base class, call the member, and get the base class implementation (which breaks
the usability of the type)

if the interface member is EXPLICITLY implemented in the base, then you can only call the member by casting
to the interface, and this will always call the subclass implementation
*/


/* ALTERNATIVES

reimplementation is still undesireable, because the subclass has no way to call the base class implementation,
and the base class may not have written the implementation anticipating reimplementation

generally, reimplementation is a last resort, if possible you should design your base class such that it is
never required; two suggestions:
	- for implicit implementation, mark the members as virtual
	- for explicit implementation, use the pattern in TextBox_Prepared below if you think
	  subclasses may need to override your logic; the explicit implementation calls a virtual
	  protected method that can be overridden

if you don't anticipate subclassing will be required, you can mark the member as sealed
*/


var r_e = new RichTextBox_Explicit();
r_e.Undo();										// rich text box Undo()
((IUndoable)r_e).Undo();						// rich text box Undo()
//((TextBox_Explicit)r_e).Undo();				// not allowed, since Undo() is explicitly implemented in the base class here


var r_i = new RichTextBox_Implicit();
r_i.Undo();										// rich text box Undo()
((IUndoable)r_i).Undo();						// rich text box Undo()
((TextBox_Implicit)r_i).Undo();					// allowed due to implicit implementation; calls text box Undo()

public interface IUndoable
{
	void Undo();
}

// explicit, reimplementation

public class TextBox_Explicit : IUndoable
{
	void IUndoable.Undo() => Console.WriteLine("TextBox_Explicit.Undo()");
}

public class RichTextBox_Explicit : TextBox_Explicit, IUndoable
{
	public void Undo() => Console.WriteLine("RichTextBox_Explicit.Undo()");
}

// implicit, reimplementation

public class TextBox_Implicit : IUndoable
{
	public void Undo() => Console.WriteLine("TextBox_Implicit.Undo()");
}

public class RichTextBox_Implicit : TextBox_Implicit, IUndoable
{
	public new void Undo() => Console.WriteLine("RichTextBox_Implicit.Undo()");
}

// explicit, no reimplemenation required

public class TextBox_Prepared : IUndoable
{
	void IUndoable.Undo() 		  => Undo();
	protected virtual void Undo() => Console.WriteLine("TextBox_Prepared.Undo()");
}

public class RichTextBox_Prepared : TextBox_Prepared
{
	protected sealed override void Undo() => Console.WriteLine("RichTextBox_Prepared.Undo()");
}
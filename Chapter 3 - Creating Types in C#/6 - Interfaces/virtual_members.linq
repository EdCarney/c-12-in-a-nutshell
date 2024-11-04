<Query Kind="Statements" />


/*
VIRTUAL MEMBERS

an implicitly implemented interface member is sealed by default; the member must be
marked as abstract or virtual in the base class to be overridden

as expected, casting the overriding subclass to its base or to the interface that the
base implements and calling the member will yield the subclass' implementation

note that an explicitly implemented interface member CANNOT be marked virtual; but it
can be reimplemented
*/

var rtb = new RichTextBox();

rtb.Undo();							// rich text box implementation
((IUndoable)rtb).Undo();			// rich text box implementation
((TextBox)rtb).Undo();				// rich text box implementation

public interface IUndoable
{
	void Undo();
}

public class TextBox : IUndoable
{
	public virtual void Undo()
	{
		Console.WriteLine("TextBox.Undo()");
	}
}

public class RichTextBox : TextBox
{
	public override void Undo()
	{
		Console.WriteLine("RichTextBox.Undo()");
	}
}
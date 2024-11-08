<Query Kind="Statements" />


/* SELF-REFERENCING GENERICS

a type can name itself as the concrete type when closing type argument

*/

public interface IEquatable<T>
{
	public bool Equals(T other);
}

public class Balloon : IEquatable<Balloon>          // self-referencing type
{
	public string Color { get; set; }
	public double Size { get; set; }

	public bool Equals(Balloon other)
	{
		return this.Color == other.Color
			&& this.Size == other.Size;
	}
}

// these are also legal definitions

public class Foo<T> where T : IComparable<T> { }
public class Bar<T> where T : Bar<T> { }
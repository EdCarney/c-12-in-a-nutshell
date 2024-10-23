<Query Kind="Statements" />

using System.Collections;

// bool values technically only need a single bit, but they
// are represented with a full byte due to internal limitations

// the System.Collections.BitArray optimizes this storage for a
// collection of bool values


// recall the reference equality only checks if the references are equal

var p1 = new Person("Ed");
var p2 = new Person("Ed");
var p3 = p1;

Console.WriteLine(p1 == p2);
Console.WriteLine(p1 == p3);

class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
	
	public Person(string name)
	{
		Name = name;
	}
}
<Query Kind="Statements" />



// GET TYPE
//
// can use GetType() or typeof() to get the type of an object; GetType() is evaluated at
// runtime and typeof() is evaluated statically at compile time


var p = new Point();
Console.WriteLine(p.GetType().Name);
Console.WriteLine(p.GetType().FullName);
Console.WriteLine(typeof(Point).Name);
Console.WriteLine(p.X.GetType().Name);
Console.WriteLine(p.X.GetType().FullName);


public class Point
{
	public int X, Y;
}
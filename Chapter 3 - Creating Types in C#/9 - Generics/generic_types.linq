<Query Kind="Statements" />



/* GENERIC TYPES

these declare TYPE PARAMETERS (placeholder types to be filled in by the consumer)

using the stack definition below, we say that Stack<T> is an OPEN TYPE and Stack<int> is a CLOSED TYPE; at runtime
all generic instances are closed and their placeholder types filled in

generics allow us to write general purpose code without the need for a lot of downcasting and boxing; e.g. we could
technically write a generic stack by making it a stack of objects that we then resolve at runtime; however this is more
error-prone and requires expensive boxing/unboxing for value types

*/

var stack = new Stack<int>();
stack.Push(5);
stack.Push(10);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());

public class Stack<T>
{
	private int position;
	private T[] data = new T[100];

	public void Push(T item) => data[position++] = item;
	public T Pop() => data[--position];
} 
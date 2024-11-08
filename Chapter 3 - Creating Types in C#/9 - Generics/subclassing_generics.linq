<Query Kind="Statements" />


/* SUBCLASSING GENERICS

generic classes can be subclassed just like nongeneric classes; the base generic class' type parameters can
either be left open, or closed

*/

class Stack<T> { }
class SpecialStack<T> : Stack<T> { }					// base class type params left open
class IntStack<T> : Stack<int> { }						// base class type params closed

class List<T> { }
class KeyedList<TKey, TValue> : List<TValue> { }		// superclass adds new type param args
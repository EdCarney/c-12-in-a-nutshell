<Query Kind="Statements" />



/* STATIC INTERFACE MEMBERS

interface members can also be static; there are two types:
	- static nonvirtual members
	- static virutal/abstract members

static interface members are NONVIRTUAL by default (in contrast to instance interface members which are
virtual by default); they must be marked with 'abstract' or 'virtual'

*/


/* STATIC NONVIRTUAL INTERFACE MEMBERS

these are mainly to help with writing default interface member implementations

they are not implemented by classes or structs implementing the interface, they are consumed directly

these can be normal function interface types (methods, properties, events, indexers) but also fields,
which would typically be accessed from code inside of a default member implementation

these members are public by default, so they can be accessed from outside the interface; they can be
marked private/internal/protected as needed

*/


/* STATIC VIRTUAL/ABSTRACT INTERFACE MEMBERS

from c#11, allows STATIC POLYMORPHISM; marked as either 'static virtual' or 'static abstract'

any class implementing the interface must implement any static abstract members, and can optionally
implement static virtual members

supports methods/properties/events (like normal interface members), but static virtual interface
members can also be operators or conversions

(will demo these types of interfaces later in the book)

*/

var logger_default = new Logger_Default();
var logger_custom = new Logger_Custom();

string msg = "hello world";

((ILogger)logger_default).Log(msg);						// uses default implementation with the default prefix
logger_custom.Log(msg);									// uses custom implemenation with default prefix

ILogger.Prefix = "new value: ";

((ILogger)logger_default).Log(msg);						// uses default implementation with the updated prefix
logger_custom.Log(msg);									// uses custom implementation with the updated prefix

public interface ILogger
{
	static string Prefix = "";

	void Log(string msg) => Console.WriteLine($"{Prefix}{msg}");
}

public class Logger_Custom : ILogger
{
	public void Log(string msg) => Console.WriteLine($"Logger: {ILogger.Prefix} {msg}");
}

public class Logger_Default : ILogger
{
}

public interface ITypeDescribable
{
	static abstract string Description { get; }
	static virtual string Category => null;
}

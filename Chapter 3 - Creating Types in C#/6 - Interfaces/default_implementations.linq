<Query Kind="Statements" />


/* DEFAULT INTERFACE MEMBERS

since c#8, you can add default implementation to an interface member; this makes it optional
to implement

this is useful if you want to add a new member to a popular interface without breaking all
existing implementations; this way those implementations would just get the default 

default implementations are always EXPLICIT; so if you want to call a default implementation
you must do so explicitly
*/

var logger = new Logger();

// logger.Log();							// compiler error; cannot call default member implicitly
((ILogger)logger).Log("hello world");		// allowed

interface ILogger
{
	void Log(string text) => Console.WriteLine(text);
}

class Logger : ILogger
{
	
}
<Query Kind="Statements" />


/* MULTICAST DELEGATES

all delegates can be multicast, that is, they can point to multiple target methods (not just one);
the += operator is used to combine

note that delegates are IMMUTABLE; when you call +=/-= you are actually creating new instances

if the multicast delegate has a nonvoid return type, then the caller only recieves the return value
from the LAST method; all methods are still called; note most of the time for multicast delegates the
methods will return void

also, all delegates derive from System.MulticastDelegate (which inherits from System.Delegate); the
+= and -= are compiled to the static Combine() and Remove() methods of System.Delegate

*/

var myDel = new MyDelegate(SayHello);
myDel += SayGoodbye;		// adds another method to the delegate

myDel("Ed");				// invokes both methods

myDel -= SayGoodbye;		// removes the method from the delegate

myDel("Brandi");

myDel = null;				// essentially empties the delegate

myDel?.Invoke("Kit");


// example of using a delegate to report something back to the caller for long-running operations

var myProgressReporter = new ProgressReporter(WriteProgressToConsole);
myProgressReporter += WriteProgressToFile;
Util.DoWork(myProgressReporter);			// both delegate methods are executed to report progress


void SayHello(string name) => Console.WriteLine($"Hello {name}!");
void SayGoodbye(string name) => Console.WriteLine($"Goodbye {name}!");

void WriteProgressToConsole(int percentComplete)
	=> Console.WriteLine($"{percentComplete}% done, {100 - percentComplete}% remaining");
void WriteProgressToFile(int percentComplete)
{
	string progressFile = @"R:\Projects\c#12_in_a_nutshell\Chapter 4 - Advanced C#\1 - Delegates\progress.txt";
	System.IO.File.WriteAllText(progressFile, percentComplete.ToString());
}


class Util
{
	public static void DoWork(ProgressReporter p)
	{
		for (int i = 0; i < 10; i++)
		{
			p(i * 10);
			System.Threading.Thread.Sleep(100);
		}
		p(100);
	}
}

delegate void MyDelegate(string msg);
delegate void ProgressReporter(int percentComplete);
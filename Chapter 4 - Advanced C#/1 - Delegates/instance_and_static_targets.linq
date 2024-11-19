<Query Kind="Statements" />



/* INSTANCE and STATIC METHOD TARGETS

delegate target methods must be local, static, or instance

for an instance method, the delegate object maintains a reference to the method and the specific instance
to which that method belongs; you can see this in the delegate's 'Target' property; this also means the
instance's lifetime is extended to at least as long as the delegate's lifetime

*/

var test = new Test();

Transformer t_static = Test.StaticSquare;				// delegate to a static method
Transformer t_instance = test.InstanceSquare;			// delegate to an instance method

var reporter = new CompletionReporter();
reporter.Prefix = "% Complete: ";
var p = new ProgressReporter(reporter.ReportProgress);

p(98);
Console.WriteLine(p.Target == reporter);
Console.WriteLine(p.Method);

reporter.Prefix = "new way! => ";
p(99);


class Test
{
	public static int StaticSquare(int x) => x * x;
	
	public int InstanceSquare(int x) => x * x;
}

class CompletionReporter
{
	public string Prefix = "";
	
	public void ReportProgress(int percentComplete) => Console.WriteLine(Prefix + percentComplete);
}

delegate int Transformer(int x);
delegate void ProgressReporter(int percent);
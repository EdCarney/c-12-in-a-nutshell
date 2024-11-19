<Query Kind="Statements" />


/* GENERIC DELEGATE TYPE COMPATILITY

recall co/contra-variance for generic types in chapter 3: covariance => going from a more specific to
a more general type going 'out'; contravariance => going from a more specific type to a more general
type going 'in'

same thing can be done for delegates; generally, the following is best practice:
	- make the return type covariant (out)
	- make all input parameters contravariant (in)
this is what Func and Action do

*/

Func<string> a = MyStrMethod;
Func<object> b = a;							// covariant TResult; object is more general

var a_test = a();
var b_test = b();

Action<object> c = MyVoidMethod;
Action<string> d = c;						// contravariant T; string is more specific

c(new object());
d(new string("hello"));

string MyStrMethod() => "hello";
void MyVoidMethod(object s) => Console.WriteLine(s);

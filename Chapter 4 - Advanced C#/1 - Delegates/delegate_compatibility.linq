<Query Kind="Statements" />


/* TYPE COMPATIBILITY

delegate types are ALWAYS incompatible with one another, even if their signatures match exactly

delegate instances are considered equal if they point to the SAME method; multicast delegates are
considered equal if they point to the same methods in the SAME ORDER; note that the compared
delegates must be of the same type

*/

Del1 d1 = SomeMethod;
//Del2 d2 = d1;					// compile-time error

// this however is fine

Del2 d2 = new Del2(d1);			// now we have two levels of indirection
Del1 d3 = SomeMethod;

Console.WriteLine(d1 == d3);


/* PARAMETER COMPABILITY

when you call a method you can provide args that are more specific than the type args of the method
(normal polymorphic behavior); this can similarly be done for delegates

a delegate just calls the underlying method(s); if your delegate signature specifies a more specific
type, then it will just be implicitly upcast to the more general type at runtime

this is CONTRAVARIANCE for delegates

this is how the event pattern works for frameworks like XAML and WinForms; there is a common 'EventArgs'
base that can then be commonly used; you can hook up an event that supplies a more specific version of
these args (e.g. 'MouseEventArgs') and the delegate will still work as expected

*/

var sa = new StringAction(ObjectAction);
sa.Invoke("Hello world!");

/* RETURN TYPE COMPABILITY

if you call a method, you might get back a type that is more specific than the method return type (again,
normal polymorphic behavior); you can also do this for delegates

delegate return types are COVARIANT

*/

var og = new ObjectGetter(StringGetter);
var obj = og.Invoke();

Console.WriteLine(obj);

//

void SomeMethod() { }
void ObjectAction(object o) => Console.WriteLine(o);
string StringGetter() => "Hello world";

delegate void Del1();
delegate void Del2();

delegate void StringAction(string s);
delegate object ObjectGetter();
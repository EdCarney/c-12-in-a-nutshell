<Query Kind="Statements" />



// PRIMARY CTORS
//
// from c#12 you can include a parameter list directly after a class declaration; this tells the compiler to
// automatically build a primary ctor using the ctor params; note that this replaces the default/emtpy ctor
// that the compiler would automatically generate
//
// these ctors are called 'primary' because any other ctors that you explicitly define must call the primary
// ctor; this ensures that the primary ctor fields are always populated
//
// note that record types also support primary ctors, but they take another step where they auto-generate an
// init-only property for each primary ctor parameter
//
// best suited for simple/prototyping use cases since you can't add any additional init code in a primary
// ctor, and you can't add more validation logic on the properties

var person = new Person("John", "Doe");
person.PrintName();

var person2 = new Person2("Kit", "Doofus");
person2.PrintName();
person2.LastName = "NotDoofus";		// this won't change PrintName() since that method uses the primary ctor param
person2.PrintName();

try
{	        
	var person3 = new Person3("Ed", null);	// should throw null ref
}
catch (Exception ex)
{
	Console.WriteLine($"Exception: {ex.Message}");
}

// firstName and lastName can be used anywhere within the class; primary ctor params are special c# concepts,
// they are not fields, although the compiler does end up generating hidden fields

public class Person(string firstName, string lastName)
{
	private int age;
	
	// the primary ctor params can be used for fields and properties
	public readonly string FirstName = firstName;
	public string LastName => lastName;
	
	// explicit ctor that calls the primary ctor
	public Person(string firstName, string lastName, int age) : this(firstName, lastName) => this.age = age;
	
	public void PrintName() => Console.WriteLine(firstName + " " + lastName);
}


public class Person2(string firstName, string lastName)
{
	// MASKING
	//
	// note that you can mask the primary ctor params by creating fields/properties with the same
	// type and name
	//
	// in this case, the field/property will take precedence EXCEPT on the righthand side of the
	// field/property initializers
	readonly string firstName = firstName + "_extra";
	
	public string LastName { get; set; } = lastName;
	
	// so here, the firstName field and the lastName property are actually being used
	public void PrintName() => Console.WriteLine(firstName + " " + lastName);
}

public class Person3(string firstName, string lastName)
{
	// VALIDATION
	//
	// note that we can validate the primary ctor params as part of our masking
	readonly string lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
	readonly string firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));

}




<Query Kind="Statements" />



// AS OPERATOR
//
// the 'as' operator performs a downcast that will evaluate to null if the cast is unsuccessful
// instead of throwing an exception
//
// note that sometimes the invalid cast exception can be useful though since it is more
// descriptive; essentially with a direct downcast you are telling the compiler that you
// are sure the cast will succeed and if it doesn't something has gone wrong, with 'as' you
// are likely testing a case where you will branch based on if the cast is successful
//
// 'as' cannot perform custom conversions or numeric conversions (long x = 3 as long) probably
// because numeric types aren't reference types


Asset a = new Asset();
Stock s = a as Stock;					// downcast from Asset to Stock

long shares;
shares = ((Stock)a).SharesOwned;		// this one may be more useful here if we are sure a is a Stock type
shares = (a as Stock).SharesOwned;		// this will generate a null ref if the cast fails...less helpful


// IS OPERATOR
//
// 'is' tests whether a variable matches a PATTERN; there are several types of patterns, with the
// most fundamental being the TYPE PATTERN
//
// for a type pattern, 'is' tests whether a reference conversion would succeed (i.e., whether an
// object derives from a specified class or implements an interface
//
// 'is' will also evaluate to true if an UNBOXING CONVERSION would succeed, but it doesn't consider
// custom/numeric conversions

if (a is Stock)
{
	Console.WriteLine(((Stock)a).SharesOwned);
}

// PATTERN VARIABLE
//
// can introduce when using 'is'; will be available for immediate use (in the same statement as
// the 'is') and will remain in scope in the current block

if (a is Stock a_stock && a_stock.SharesOwned > 100_000)		// in scope in the 'if' condition
{
	Console.WriteLine("many shares");
}
else
{
	a_stock = new Stock();										// in scope in the 'else' block
}

Console.WriteLine(a_stock.SharesOwned);							// still in scope


public class Asset
{
	public string Name;
}

public class Stock : Asset
{
	public long SharesOwned;
}

public class House : Asset
{
	public decimal Mortgage;
}
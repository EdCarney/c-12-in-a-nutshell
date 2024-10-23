<Query Kind="Statements">
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>


int a = 1_000_000;
int b = 1_000_000;

// checked operation generates an exception
try
{
	int c = checked (a * b);
	Console.WriteLine($"Result is: {c}");
}
catch (OverflowException ex)
{
	Console.WriteLine($"Overflow exception: {ex.Message}");
}

// non-checked operation does not
try
{
	int c = (a * b);
	Console.WriteLine($"Result is: {c}");
}
catch (OverflowException ex)
{
	Console.WriteLine($"Overflow exception: {ex.Message}");
}

// compile-time constants are always checked for overflow

/*
int x = int.MaxValue + 1;	// compile-time error
*/

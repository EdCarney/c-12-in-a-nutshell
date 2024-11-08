<Query Kind="Statements" />



/* DEFAULT GENERIC VALUES

you can use 'default' to get the default value for a generic type; default reference type value is null and
default value type value is the bitwise-zeroing of the type's field

*/

static void Zap<T>(T[] array)
{
	for (int i = 0; i < array.Length; i++)
	{
		array[i] = default(T);			// set to default value
		array[i] = default;				// can omit the type since c#7
	}
}
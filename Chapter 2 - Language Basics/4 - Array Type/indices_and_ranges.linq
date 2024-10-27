<Query Kind="Statements" />


// INDICES let you refer to elements relative to the END of an array with the ^
// note that ^0 equals the length of the array and would generate an exception

var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

char lastVowel = vowels[^1];
char secondToLast = vowels[^2];

// indices are implemented with the Index type, so you can also do this

Index first = 0;
Index last = ^1;

char firstVowel = vowels[first];
char lastVowel_1 = vowels[last];

// RANGES let you slice an array using the ..
// note that the second number in the range is exclusive

char[] firstTwo = vowels[..2];		// 'a' and 'e'
char[] lastThree = vowels[^3..];	// 'i', 'o', 'u'
char[] middleOne = vowels[2..3];	// 'i'

Console.WriteLine(firstTwo);
Console.WriteLine(lastThree);
Console.WriteLine(middleOne);

// ranges are implemented with the Range type, so you can also do this

Range firstTwoRange = 0..2;
char[] firstTwo_1 = vowels[firstTwoRange];
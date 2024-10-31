<Query Kind="Statements" />



var s = new Sentence();

Console.WriteLine(s[1]);
s[1] = "slow";
Console.WriteLine(s[1]);

Console.WriteLine(s[0, 3]);

public class Sentence
{
	string[] words = "the quick brown fox".Split();
	
	// INDEXERS
	//
	// indexers allow us to index our class with any type (string, int, custom class, etc.)
	//
	// a type can declare multiple indexers, each with params of different type; also, an indexer
	// can take more than one parameter
	
	public string this [int wordNum]
	{
		get => words[wordNum];
		set => words[wordNum] = value;
	}
	
	// read-only indexer taking two properties
	public string this [int wordNum1, int wordNum2] => words[wordNum1] + " " + words[wordNum2];
}
<Query Kind="Statements" />


// raw string literals are a feature of c# 11
// create them by wrapping your string in triple double quotes

string rsl1 = """This is some text "within quotes" with no escape""";
Console.WriteLine(rsl1);

// if you need to have triple double quotes in your string, then use
// quadruple double quotes to wrap the string literal

string rsl2 = """"Here I """really""" need 3 double quotes"""";
Console.WriteLine(rsl2);

// you can multi-line raw string literal text easily

string rsl3 = """
Line 1
Line2
""";
Console.WriteLine(rsl3);

// for the multi-line case, there are two special rules:
//	1. whitespace after the opening """ is ignored
//	2. whitespace before the closing """ is treated as common, and removed from each line
// rule 2 allows you to maintain indentation for source readability
// without adding unnecessary indentation to your string literal

bool b = true;
while (b)
{
	Console.WriteLine("""
	{
		"name": "Ed"
	}
	""");
	b = false;
}
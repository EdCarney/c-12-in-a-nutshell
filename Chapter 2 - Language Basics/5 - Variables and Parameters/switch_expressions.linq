<Query Kind="Statements" />


// starting in c#8 you can use SWITCH EXPRESSIONS, which are generally more compact and
// can be used in LINQ queries

int cardNumber = 11;
string suite = "spades";

string cardName = cardNumber switch
{
	13 => "King",
	12 => "Queen",
	11 => "Jack",
	_ => "Pip card"		// _ is equivalent to 'default'
};

// note if the expression cases fail to match and there is no default expression, then an
// exception is thrown

// you can also switch on multiple values (the TUPLE PATTERN)

string suitedCardName = (cardNumber, suite) switch
{
	(13, "spades") => "King of spades",
	(13, "clubs") => "King of clubs",
};
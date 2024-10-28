<Query Kind="Statements" />


// ITERATION STATEMENTS are the while, do-while, for, and foreach

// WHILE and DO-WHILE
//
// while loops test before the statement block has executed, do-while loops perform a check only
// after the statement block has executed once

// FOR
//
// like while loops but have special clauses for initialization and iteration of the loop variable
//	- initialization clause: execute before loop starts; initializes one or more iteration variables
//	- condition clause: bool expression; body will execute while true
//	- iteration clause: executed after each iteration

// this for loop is an interesting way to compute a set of fibonacci numbers

for (int i = 0, prevFib = 1, currFib = 1; i < 10; i++)
{
	Console.WriteLine(prevFib);
	int newFib = prevFib + currFib;
	prevFib = currFib;
	currFib = newFib;
}

// FOREACH
<Query Kind="Expression" />


// an EXPRESSION basically denotes a value, with the simpliest expressions just being
// constants and variables; expressions can be transformed using OPERATORS, which take
// one or more OPERANDS to create a new expression

12				// a CONSTANT EXPRESSION

(12 * 30)		// the * operator acting on two literal expressions

1 + (12 * 30)	// the expression (12 * 30) is now an operand

// operators are either UNARY, BINARY, or TERNARY; binary operators always use INFIX notation
// where the operator is placed in-between the two operands

// PRIMARY EXPRESSIONS include expressions composed of operators that are intrinsic to the
// basic plumbing of the language (e.g. the dot (.) or method call (()) operators)

Math.Log(1)

// VOID EXPRESSIONS are expressions that have no value, and as such cannot be used to build
// more complex expressions

Console.WriteLine(1)	// returns void, so can't so something like (1 + Console.WriteLine(1))

// ASSIGNMENT EXPRESSIONS use the = operator to assign the result of another expression to a variable;
// note that these are NOT void expressions, these expressions have a value of whatever was assigned

x = x * 5			// assignment expression
y = 5 * (x = 2)		// x gets 2, y gets 10
a = b = c = 0		// also valid to init multiple values

// COMPOUND ASSIGNMENT OPERATORS are shortcuts to combine assignment with some other operator

x *= 5		// same as x = x * 5
x <<= 1		// same as x = x << 1

// when there are multiple operators, PRECEDENCE and ASSOCIATIVITY determine the order of
// evaluation; precedence is as mathematically expected, associativity depends on the operator
// type

// binary operators (except for lambda, assignment, and null-coalescing operators) are LEFT-ASSOCIATIVE,
// meaning they execute left-to-right

8 / 4 / 2		// evaluated as (8 / 4) / 2

// assignment, lambda, null-coalescing, and conditional operators are RIGHT-ASSOCIATIVE

x = y = 2		// right associativity allows this to compile

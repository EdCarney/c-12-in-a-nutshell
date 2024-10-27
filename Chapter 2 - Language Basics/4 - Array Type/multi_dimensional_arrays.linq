<Query Kind="Statements" />



// RECTANGULAR arrays are an n-dimensional block of memory; use commas to separate the dimensions
// the GetLength() method on an arary returns the length for a specified dimension

int[,] m1 = new int[3,3];

for (int i = 0; i < m1.GetLength(0); i++)
	for (int j = 0; j < m1.GetLength(1); j++)
		m1[i,j] = i * 3 + j;

// a rectangular array can be intialized similar to a normal array

int[,] m2 = new int[,]
{
	{ 0, 1, 2},
	{ 3, 4, 5},
	{ 6, 7, 8}
};

// jagged arrays are arrays of arrays; use successive square brackets to represent each dimension

int[][] m3 = new int[3][];	// note that this is a 'matrix' of 3 rows, each of arbitrary length

for (int i = 0; i < m3.Length; i++)
{
	// the inner dimensions of the jagged array are initialized to null
	m3[i] = new int[3];
	for (int j = 0; j < m3[i].Length; j++)
		m3[i][j] = i * 3 + j;
}

// jagged arrays can also be initialized with explicit values

int[][] m4 = new int[][]
{
	new int[] { 0, 1, 2 },
	new int[] { 3, 4, 5 },
	new int[] { 6, 7, 8, 9 }
}
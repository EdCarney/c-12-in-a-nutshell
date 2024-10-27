<Query Kind="Statements" />


// array bounds are automatically checked by the runtime

int[] arr = new int[3];
arr[3] = 1;		// throws an IndexOutOfRangeException

// the perf hit from this is small, and you can bypass the check if desired
// with the 'usafe' keyword
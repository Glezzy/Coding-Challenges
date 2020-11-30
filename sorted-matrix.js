// Greg Glesener
// Dynogas interview question 1

// You're given a two-dimensional array of distinct integers and a target integer.
// Each row in the matrix is sorted, and each column is also sorted; the matrix doesn't
// necessarily have the same height and width. 

// The goal is to write a function that returns an array of the row and column indices of the 
// target integer if it's contained in the matrix, otherwise return [-1,1].

function searchInSortedMatrix(matrix, target) {
	let row = 0;
	let col = matrix[0].length - 1;           			// start at the last value of first row
	while (row < matrix.length && col >= 0) {			// while in a valid position in the matrix
		if (matrix[row][col] > target) {				// if greater
			col --;										// then eliminate numbers below it by decrementing a column
		} else if (matrix[row][col] < target) {			// now if less than target
			row++;										// move down a row, we are only moving down and left
		} else {										// else return the matrix position of the target value
			return [row, col];
		}
	}
	return[-1, 1]										// if not found then return [-1,1] because the while loop will
}														// end once we are no longer in a valid position in the matrix. 


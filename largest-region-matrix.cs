// Greg Glesener
// Dynogas Code interview question 2

// C# program to find the length of
// the largest region in boolean 2D-matrix

// Consider a matrix with rows and columns, where each cell contains either a ‘0’ or a ‘1’ and any cell containing a 1 is  // called a filled cell. Two cells are said to be connected if they are adjacent to each other horizontally, vertically, // or diagonally. If one or more filled cells are also connected, they form a region. find the length of the largest region.

using System;
 
class GFG 
{
    static int ROW, COL, count;
 
																// A function to check if a given cell
																// (row, col) can be included in DFS
    static Boolean isSafe(int[, ] M, int row, int col,
                          Boolean[, ] visited)
    {
																// row number is in range, column number is in
																// range and value is 1 and not yet visited
        return (
            (row >= 0) && (row < ROW) && (col >= 0)
            && (col < COL)
            && (M[row, col] == 1 && !visited[row, col]));
    }
 
																// A utility function to do DFS for a 2D boolean
																// matrix. It only considers the 8 neighbours as
																// adjacent vertices
    static void DFS(int[, ] M, int row, int col,
                    Boolean[, ] visited)
    {
																// These arrays are used to get row and column
																// numbers of 8 neighbours of a given cell
        int[] rowNbr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] colNbr = { -1, 0, 1, -1, 1, -1, 0, 1 };
 
																// Mark this cell as visited
        visited[row, col] = true;
 
																// Recur for all connected neighbours
        for (int k = 0; k < 8; k++) 
        {
            if (isSafe(M, row + rowNbr[k], 
                       col + colNbr[k],
                       visited)) 
            {
																// increment region length by one
                count++;
                DFS(M, row + rowNbr[k], col + colNbr[k],
                    visited);
            }
        }
    }
 
																// The main function that returns
																// largest length region of
																// a given boolean 2D matrix
    static int largestRegion(int[, ] M)
    {
																// Make a boolean array to mark visited cells.
																// Initially all cells are unvisited
        Boolean[, ] visited = new Boolean[ROW, COL];
 
																// Initialize result as 0 and traverse
																// through the all cells of given matrix
        int result = 0;
        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++) 
            {
																// If a cell with value 1 is not
                if (M[i, j] == 1 && !visited[i, j]) 
                {
																// visited yet,
																// then new region found
                    count = 1;
                    DFS(M, i, j, visited);
 
																// maximum region
                    result = Math.Max(result, count);
                }
            }
        }
        return result;
    }
 
																// Driver code
    public static void Main(String[] args)
    {
        int[, ] M = { { 0, 0, 1, 1, 0 },
                      { 1, 0, 1, 1, 0 },
                      { 0, 1, 0, 0, 0 },
                      { 0, 0, 0, 0, 1 } };
        ROW = 4;
        COL = 5;
       
																// Function call
        Console.WriteLine(largestRegion(M));
    }
}
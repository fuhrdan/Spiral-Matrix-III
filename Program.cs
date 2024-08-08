//*****************************************************************************
//** 885. Spiral Matrix III  leetcode                                        **
//** Build a two-dimensional array, loop it around to find the correct       **
//** answer and return that.  It was time consuming.                 -Dan    **
//*****************************************************************************


/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int** spiralMatrixIII(int rows, int cols, int rStart, int cStart, int* returnSize, int** returnColumnSizes) {
    int totalCells = rows * cols;
    *returnSize = totalCells;

    // Allocate memory for result and returnColumnSizes
    int** result = (int**)malloc(totalCells * sizeof(int*));
    *returnColumnSizes = (int*)malloc(totalCells * sizeof(int));
    
    for (int i = 0; i < totalCells; ++i) {
        result[i] = (int*)malloc(2 * sizeof(int));
        (*returnColumnSizes)[i] = 2;
    }

    int r = rStart, c = cStart;
    int d = 0, step = 1, idx = 0;

    // Direction vectors: right, down, left, up
    int directions[4][2] = { {0, 1}, {1, 0}, {0, -1}, {-1, 0} };

    // Add the starting position
    result[idx][0] = r;
    result[idx][1] = c;
    idx++;

    // Spiral walk
    while (idx < totalCells) {
        for (int i = 0; i < 2; ++i) {  // Each direction will go 'step' times
            int dirR = directions[d][0];
            int dirC = directions[d][1];
            for (int j = 0; j < step; ++j) {
                r += dirR;
                c += dirC;

                // Check if the current position is within grid bounds
                if (r >= 0 && r < rows && c >= 0 && c < cols) {
                    result[idx][0] = r;
                    result[idx][1] = c;
                    idx++;
                }
                if (idx == totalCells) break; // Exit if all cells are filled
            }
            d = (d + 1) % 4;  // Change direction
            if (idx == totalCells) break; // Exit if all cells are filled
        }
        step++;
    }

    return result;
}

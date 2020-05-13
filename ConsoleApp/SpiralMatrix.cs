using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SpiralMatrix
    {

        // -https://leetcode.com/problems/spiral-matrix/

        /*
             Example 1:
                Input:
                [
                    [ 1, 2, 3 ],
                    [ 4, 5, 6 ],
                    [ 7, 8, 9 ]
                ]
                Output: [1,2,3,6,9,8,7,4,5]

            Example 2:
                Input:
                [
                    [1, 2, 3, 4],
                    [5, 6, 7, 8],
                    [9,10,11,12]
                ]
                Output: [1,2,3,4,8,12,11,10,9,5,6,7] 
         * */

        public List<int> CallSpiralOrderWithInput()
        {
            int[][] matrix = new int[][] {
                        new int[] {1, 2, 3 },
                        new int[] {4, 5, 6 },
                        new int[] {7, 8, 9 }
                    };

            int[][] matrix3by4 = new int[][] {
                        new int[] { 1, 2, 3, 4 },
                        new int[] { 5, 6, 7, 8 },
                        new int[] { 9, 10, 11, 12 }
                    };

            List<List<int>> matrix2 = new List<List<int>>() {
                    new List<int>() {1, 2, 3 },
                    new List<int>() {4, 5, 6 },
                    new List<int>() {7, 8, 9 }
                    };

            List<List<int>> matrix2_3by4 = new List<List<int>>() {
                    new List<int>() { 1, 2, 3, 4 },
                    new List<int>() { 5, 6, 7, 8 },
                    new List<int>() { 9, 10, 11, 12 }
                    };

            //return SpiralOrder(matrix);
            return SpiralOrder(matrix3by4);
            //return SpiralOrder2(matrix2);
            //return SpiralOrder2(matrix2_3by4);
        }

        public List<int> SpiralOrder(int[][] matrix)
        {
            List<int> ans = new List<int>();
            if (matrix.Length == 0) return ans;
            int R = matrix.Length;
            int C = matrix[0].Length;
            bool[,] seen = new bool[R, C];
            int[] dr = { 0, 1, 0, -1 };
            int[] dc = { 1, 0, -1, 0 };
            int r = 0, c = 0, di = 0;
            for (int i = 0; i < R * C; i++)
            {
                ans.Add(matrix[r][c]);
                seen[r, c] = true;
                int cr = r + dr[di];
                int cc = c + dc[di];
                if (0 <= cr && cr < R && 0 <= cc && cc < C && !seen[cr, cc])
                {
                    r = cr;
                    c = cc;
                }
                else
                {
                    di = (di + 1) % 4;
                    r += dr[di];
                    c += dc[di];
                }
            }
            return ans;

        }

        public List<int> SpiralOrder2(List<List<int>> matrix)
        {

            List<int> ans = new List<int>();

            int m = matrix.Count;

            if (m == 0)
                return ans;

            int n = matrix[0].Count;


            int T = 0, B = m - 1, L = 0, R = n - 1;

            int dir = 0;

            while (T <= B && L <= R)
            {

                if (dir == 0)
                {
                    for (int i = L; i <= R; i++)
                        ans.Add(matrix[T][i]);

                    dir = 1;
                    T++;
                }
                else if (dir == 1)
                {
                    for (int i = T; i <= B; i++)
                        ans.Add(matrix[i][R]);

                    R--;
                    dir = 2;
                }
                else if (dir == 2)
                {
                    for (int i = R; i >= L; i--)
                        ans.Add(matrix[B][i]);

                    dir = 3;
                    B--;
                }
                else
                {
                    for (int i = B; i >= T; i--)
                        ans.Add(matrix[i][L]);

                    dir = 0;
                    L++;
                }

            }

            return ans;
        }
    }
}

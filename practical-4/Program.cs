class program
{
    static void Main() 
    {
        int[][] dungeon = new int[][] {
        new int[] {-2, -3, 3},
        new int[] {-5, -10, 1},
        new int[] {10, 30, -5}
};

        int minHp = MinimumHP(dungeon);
        Console.WriteLine(minHp); // Вывод: 
    }
   static public int MinimumHP(int[][] dungeon)
    {
        int m = dungeon.Length;
        int n = dungeon[0].Length;

        int[,] dp = new int[m, n];

        dp[m - 1, n - 1] = Math.Max(1, 1 - dungeon[m - 1][n - 1]);

        for (int i = m - 2; i >= 0; i--)
            dp[i, n - 1] = Math.Max(dp[i + 1, n - 1] - dungeon[i][n - 1], 1);

        for (int j = n - 2; j >= 0; j--)
            dp[m - 1, j] = Math.Max(dp[m - 1, j + 1] - dungeon[m - 1][j], 1);

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                int minHp = Math.Min(dp[i + 1, j], dp[i, j + 1]);
                dp[i, j] = Math.Max(minHp - dungeon[i][j], 1);
            }
        }

        return dp[0, 0];
    }
}

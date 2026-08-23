using System;
using System.Data;

namespace SimulationCore.Helpers
{
    public static class RandomGenerator
    {
        public static Random random = new Random();
        public static List<float> GenerateRandomNumbers(int count)
        {
            List<float> numbers = new List<float>();
            for (int i = 0; i < count; i++)
                numbers.Add((float)random.NextDouble());
            return numbers;
        }
        public static int LookupValueByRandomNumber(DataTable dt, string valueColumn, float randomNumber)
        {
            foreach (DataRow row in dt.Rows)
            {
                float cumulative = Convert.ToSingle(row["Cumulative Probability"]);
                if (randomNumber <= cumulative)
                    return Convert.ToInt32(row[valueColumn]);
            }
            DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
            return Convert.ToInt32(lastRow[valueColumn]);
        }

    }
}

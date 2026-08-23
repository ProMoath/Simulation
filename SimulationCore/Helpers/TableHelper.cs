using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SimulationCore.Helpers
{
    public static class TableHelper
    {
        static Random random = new Random();  
        public static bool GenerateTable(DataTable dt, string InputText,out string errorMessage,int begining,int increaseAmount)
        {
            errorMessage = "";
            if (string.IsNullOrEmpty(InputText))
            {
                errorMessage="Please Enter Number First";
                return false;
            }
            if (!int.TryParse(InputText.ToString(), out int val))
            {
                errorMessage = "Please enter a valid number!";
                InputText = "0";
                return false;
            }
            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("First Column", typeof(int));
            dt.Columns.Add("Probability", typeof(float));
            dt.Columns.Add("Cumulative Probability", typeof(float));
            dt.Columns.Add("Random Number Assignment", typeof(string));
            for (int i = begining; i <= int.Parse(InputText); i+=increaseAmount)
            {
                DataRow row = dt.NewRow();
                row["First Column"] = i;
                row["Probability"] = 0.0;
                row["Cumulative Probability"] = 0.0;
                row["Random Number Assignment"] = "";

                dt.Rows.Add(row);
            }
           return true;
        }
        public static void CalculateTableData(DataTable dt)
        {
            float cumulativeProbability = 0.0f;
            float previousCumulativeProbability = 0.0f;
            foreach (DataRow row in dt.Rows)
            {
                float probability = Convert.ToSingle(row["Probability"]);
                previousCumulativeProbability = cumulativeProbability;
                cumulativeProbability += probability;
                row["Cumulative Probability"] = cumulativeProbability;
                row["Random Number Assignment"] = $"{(previousCumulativeProbability):F2} - {(cumulativeProbability):F2}";
            }

        }
        public static bool ValidateProbabilitySum(DataTable dt, int editedRowIndex, out string errorMessage)
        {
            errorMessage = "";
            float total = dt.AsEnumerable().Sum(row => Convert.ToSingle(row["Probability"]));

            bool allRowsFilled = !dt.AsEnumerable()
                .Any(row => Convert.ToSingle(row["Probability"]) == 0.0f);

            if (total > 1.0001f)
            {
                errorMessage = "Sum Of Probablity Over 1! Correct the Value";
                dt.Rows[editedRowIndex]["Probability"] = 0.0f;
                CalculateTableData(dt);
                return false;
            }

            if (Math.Abs(total - 1.0f) <= 0.0001f && !allRowsFilled)
            {
                errorMessage = "Sum Of Probablity now is 1 , you can't enter values in the rest row.";
            }

            return true;
        }
        public static bool GenerateRandomProbablity(DataTable dt, string InputText,out string errorMessage)
        {
            errorMessage="";
            float sum = 0.0f;
            int rowCount =dt.Rows.Count;
            List<float> randomNumbers = new List<float>();

            if (string.IsNullOrEmpty(InputText))
            {
                errorMessage = "Please Enter Number First";
                return false;
            }

            if (!int.TryParse(InputText, out int maxVal))
            {
                errorMessage = "Please enter a valid number!";
                return false;
            }

            if (dt == null || rowCount==0)
            {
                errorMessage = "Table is empty! Please click 'Input' first.";
                return false;
            }

            for (int i = 1; i <= rowCount; i++)
            {
                float NewRandom = (float)random.NextDouble();
                randomNumbers.Add(NewRandom);
                sum += NewRandom;
            }
            if (sum == 0)
            {
                errorMessage = "Sum is zero, cannot normalize!";
                return false;
            }
            float NormalizationFactor = 1.0f / sum;
            for (int i = 1; i <= rowCount; i++)
            {
                float randomProbablity = randomNumbers[i - 1] * NormalizationFactor;
                dt.Rows[i - 1]["Probability"] = randomProbablity;
            }
            CalculateTableData(dt);
            return true;
        }
    }
}

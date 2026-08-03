using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form2 : Form
    {
        public DataTable Cal_TBA { get; private set; } = new DataTable();
        public DataTable Cal_ST { get; private set; } = new DataTable();
        Random random = new Random();
        public Form2()
        {
            InitializeComponent();
        }

        private void GenerateTable(DataTable dt, DataGridView dgv, TextBox InputText)
        {
            if (string.IsNullOrEmpty(InputText.Text))
            {
                MessageBox.Show("Please Enter Number First");
                return;
            }
            else if (!int.TryParse(InputText.Text.ToString(), out int val))
            {
                MessageBox.Show("Please enter a valid number!");
                InputText.Text = "0";
                return;
            }
            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("Time", typeof(int));
            dt.Columns.Add("Probability", typeof(float));
            dt.Columns.Add("Cumulative Probability", typeof(float));
            dt.Columns.Add("Random Number Assignment", typeof(string));
            for (int i = 1; i <= int.Parse(InputText.Text); i++)
            {
                DataRow row = dt.NewRow();
                row["Time"] = i;
                row["Probability"] = 0.0;
                row["Cumulative Probability"] = 0.0;
                row["Random Number Assignment"] = "";

                dt.Rows.Add(row);
            }
            dgv.DataSource = dt;
            dgv.Columns["Time"].ReadOnly = true;
            dgv.Columns["Cumulative Probability"].ReadOnly = true;
            dgv.Columns["Random Number Assignment"].ReadOnly = true;

        }
        private void CalculateTableData(DataTable dt)
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
        private bool ValidateProbabilitySum(DataTable dt, int editedRowIndex)
        {
            float total = dt.AsEnumerable().Sum(row => Convert.ToSingle(row["Probability"]));

            bool allRowsFilled = !dt.AsEnumerable()
                .Any(row => Convert.ToSingle(row["Probability"]) == 0.0f);

            if (total > 1.0001f)
            {
                MessageBox.Show("Sum Of Probablity Over 1! Correct the Value");
                dt.Rows[editedRowIndex]["Probability"] = 0.0f;
                CalculateTableData(dt);
                return false;
            }

            if (Math.Abs(total - 1.0f) <= 0.0001f && !allRowsFilled)
            {
                MessageBox.Show("Sum Of Probablity now is 1 , you can't enter values in the rest row.");
            }

            return true;
        }
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv?.Columns[e.ColumnIndex].Name == "Probability")
            {
                
               float probability = float.Parse(dgv.CurrentCell.Value.ToString());
                if (!float.TryParse(dgv.CurrentCell.Value.ToString(), out float val) || (probability > 1 || probability < 0))
                {
                    MessageBox.Show("Please entenr a valid number!");
                    dgv.CurrentCell.Value = 0.0;
                    return;
                }
                DataTable? targetTable = null;
                if (dgv == dataGridView1)
                {
                    targetTable = Cal_TBA;
                }
                else if (dgv == dataGridView2)
                {
                    targetTable = Cal_ST;
                }
                if (targetTable != null)
                {
                    CalculateTableData(targetTable);
                    ValidateProbabilitySum(targetTable, e.RowIndex);
                }
                if (e.RowIndex == targetTable.Rows.Count - 1)
                {
                    float totalProbability = targetTable.AsEnumerable().Sum(row => Convert.ToSingle(row["Probability"]));
                    if (Math.Abs(totalProbability - 1.0f) > 0.0001f)
                    {
                        MessageBox.Show("The summition must be 1!");
                    }
                }
            }
        }
        private void GenerateRandomProbablity(DataTable dt, TextBox InputText)
        {
            float sum = 0.0f;
            List<float> randomNumbers = new List<float>();
            for (int i = 1; i <= int.Parse(InputText.Text); i++)
            {
                float NewRandom = (float)random.NextDouble();
                randomNumbers.Add(NewRandom);
                sum += NewRandom;
            }
            if (sum == 0)
            {
                MessageBox.Show("Sum is zero, cannot normalize!");
                return;
            }
            float NormalizationFactor = 1.0f / sum;
            for (int i = 1; i <= int.Parse(InputText.Text); i++)
            {
                float randomProbablity = randomNumbers[i - 1] * NormalizationFactor;
                dt.Rows[i - 1]["Probability"] = randomProbablity;
            }
            CalculateTableData(dt);
        }

        private bool PreventEmptyClick(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Please Enter Value In The Text Filed First!");
                return true;
            }
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateTable(Cal_TBA, dataGridView1, maxTBA);
        }  
        private void button2_Click(object sender, EventArgs e)
        {
            GenerateTable(Cal_ST, dataGridView2, maxST);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (PreventEmptyClick(maxTBA))
                return;
            GenerateRandomProbablity(Cal_TBA, maxTBA);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(PreventEmptyClick(maxST))
                return;
            else
            GenerateRandomProbablity(Cal_ST, maxST);
        }
    }
}
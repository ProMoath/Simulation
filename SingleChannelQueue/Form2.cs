using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulation;
using SimulationCore.Helpers;

namespace Simulation
{
    public partial class Form2 : Form
    {
        public DataTable Cal_TBA { get; set; } = new DataTable();
        public DataTable Cal_ST { get; private set; } = new DataTable();
        Random random = new Random();
        public Form2()
        {
            InitializeComponent();
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
                    TableHelper.CalculateTableData(targetTable);
                    if (!TableHelper.ValidateProbabilitySum(targetTable, e.RowIndex, out string errorMessage))
                        MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else 
                        TableHelper.ValidateProbabilitySum(targetTable, e.RowIndex, out string errorMessage2);
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
        private bool PreventEmptyClick(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Please Enter Value In The Text Filed First!");
                return true;
            }
            else return false;
        }
        private void tba_Input(object sender, EventArgs e)
        {
            if(TableHelper.GenerateTable(Cal_TBA, maxTBA.Text,out string errorMessage,1,1))
            {
                dataGridView1.DataSource = Cal_TBA;
                dataGridView1.Columns["First Column"].ReadOnly = true;
                dataGridView1.Columns["Cumulative Probability"].ReadOnly = true;
                dataGridView1.Columns["Random Number Assignment"].ReadOnly = true;

                dataGridView1.Columns["First Column"].HeaderText = "Time Between Arrivals";
            }
            else
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (errorMessage.Contains("valid number")) maxTBA.Text = "0";
            }
        }  
        private void st_Input(object sender, EventArgs e)
        {
            if (TableHelper.GenerateTable(Cal_ST, maxST.Text, out string errorMessage,1,1))
            {
                dataGridView2.DataSource = Cal_ST;
                dataGridView2.Columns["First Column"].ReadOnly = true;
                dataGridView2.Columns["Cumulative Probability"].ReadOnly = true;
                dataGridView2.Columns["Random Number Assignment"].ReadOnly = true;

                dataGridView2.Columns["First Column"].HeaderText = "Service Time";
            }
            else
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (errorMessage.Contains("valid number")) maxTBA.Text = "0";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
                if (PreventEmptyClick(maxTBA))
                    return;
            else if (!TableHelper.GenerateRandomProbablity(Cal_TBA, maxTBA.Text, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (errorMessage.Contains("valid number")) maxTBA.Text = "0";
            }
            else
           TableHelper.GenerateRandomProbablity(Cal_TBA, maxTBA.Text,out string errorMessage2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (PreventEmptyClick(maxST))
                return;
            else if (!TableHelper.GenerateRandomProbablity(Cal_ST, maxST.Text, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (errorMessage.Contains("valid number")) maxST.Text = "0";
            }
            else 
                TableHelper.GenerateRandomProbablity(Cal_ST, maxST.Text, out string errorMessage2);
        }
    }
}
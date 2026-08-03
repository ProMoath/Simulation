using System.Data;

namespace Simulation
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        private Form2 setupForm;

        public Form1()
        {
            InitializeComponent();
        }
        private List<float> GenerateRandomNumbers(int count)
        {
            List<float> numbers = new List<float>();
            for (int i = 0; i < count; i++)
                numbers.Add((float)random.NextDouble());
            return numbers;
        }
        private void OpenSetup(object sender, EventArgs e)
        {
            setupForm = new Form2();     
            setupForm.ShowDialog();    
        }

        public int LookupValueByRandomNumber(DataTable dt, string valueColumn, float randomNumber)
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
        private void RunSimulation(object sender, EventArgs e)
        {
            if (setupForm == null)
            {
                MessageBox.Show("Please open the Setup Form first!");
                return;
            }
            DataTable tbaTable = setupForm.Cal_TBA;
            DataTable stTable = setupForm.Cal_ST;
            if (tbaTable.Rows.Count == 0 || stTable.Rows.Count == 0)
            {
                MessageBox.Show("Please enter table of cumulative from seconed form");
                return;
            }
            if(string.IsNullOrEmpty(customers.Text))
            {
                MessageBox.Show("Enter Number Of Customers First!");
                return;
            }    
            int customerCount = int.Parse(customers.Text);
            List<float> randomForIT = GenerateRandomNumbers(customerCount);
            List<float> randomForST = GenerateRandomNumbers(customerCount);
            DataTable resultsTable = new DataTable();
            resultsTable.Columns.Add("Customers Numbers", typeof(string));
            resultsTable.Columns.Add("InterArrival Time", typeof(float));
            resultsTable.Columns.Add("Arraival Time", typeof(float));
            resultsTable.Columns.Add("Service Time", typeof(float));
            resultsTable.Columns.Add("Start Of Service", typeof(int));
            resultsTable.Columns.Add("End Of Service", typeof(float));
            resultsTable.Columns.Add("Time In Queue", typeof(float));
            resultsTable.Columns.Add("Time In System", typeof(float));
            resultsTable.Columns.Add("Idle Time Of Server", typeof(float));

            int previousArrivalTime = 0;
            int previousEndOfService = 0;
            for (int i =0; i < customerCount; i++)
            {
                int interarrivalTime = LookupValueByRandomNumber(tbaTable, "Time", randomForIT[i]);
                int serviceTime = LookupValueByRandomNumber(stTable, "Time", randomForST[i]);
                int arrivalTime = previousArrivalTime + interarrivalTime;
                int startOfService = Math.Max(arrivalTime, previousEndOfService);
                int endOfService = startOfService + serviceTime;
                int timeInQueue = startOfService - arrivalTime;
                int timeInSystem = timeInQueue + serviceTime;
                int idleTime = (i == 0) ? 0 : startOfService - previousEndOfService;

                DataRow row = resultsTable.NewRow();
                row["Customers Numbers"] = i+1 ;
                row["InterArrival Time"] = interarrivalTime;
                row["Arraival Time"] = arrivalTime;
                row["Service Time"] = serviceTime;
                row["Start Of Service"] = startOfService;
                row["End Of Service"] = endOfService;
                row["Time In Queue"] = timeInQueue;
                row["Time In System"] = timeInSystem;
                row["Idle Time Of Server"] = idleTime;
                resultsTable.Rows.Add(row);

                previousArrivalTime = arrivalTime;
                previousEndOfService = endOfService;
            }

            int sumInterArrivalTime = 0;
            int sumServiceTime = 0;
            int sumTimeInQueue = 0;
            int sumTimeInSystem = 0;
            int sumIdleTime = 0;
            int sumOfCustomersInQue = 0;

            foreach (DataRow dataRow in resultsTable.Rows)
            {
                sumInterArrivalTime += Convert.ToInt32(dataRow["InterArrival Time"]);
                sumServiceTime += Convert.ToInt32(dataRow["Service Time"]);
                sumTimeInQueue += Convert.ToInt32(dataRow["Time In Queue"]);
                sumTimeInSystem += Convert.ToInt32(dataRow["Time In System"]);
                sumIdleTime += Convert.ToInt32(dataRow["Idle Time Of Server"]);
                if (Convert.ToInt32(dataRow["Time In Queue"]) > 0)
                    sumOfCustomersInQue++;
            }

            float averageInterArrivalTime = (float)sumInterArrivalTime / customerCount;
            float averageServiceTime = (float)sumServiceTime / customerCount;
            float averageTimeInQueue = (float)sumTimeInQueue / customerCount;
            float averageTimeInSystem = (float)sumTimeInSystem / customerCount;
            float averageIdleTime = (float)sumIdleTime / customerCount;
            float averageNumberOfCustomersInQueue = (float)sumOfCustomersInQue / customerCount;
            float averageTimeInQueCustomer = 0;
            if(sumOfCustomersInQue > 0)
                averageTimeInQueCustomer += (float)sumTimeInQueue / sumOfCustomersInQue;
            float serverUtilization = 1 - ((float)sumIdleTime / previousEndOfService);

            DataRow totalRow = resultsTable.NewRow();
    
            totalRow["Customers Numbers"] = "Total";
            totalRow["InterArrival Time"] = sumInterArrivalTime;
            totalRow["Service Time"] = sumServiceTime;
            totalRow["Time In Queue"] = sumTimeInQueue;
            totalRow["Time In System"] = sumTimeInSystem;
            totalRow["Idle Time Of Server"] = sumIdleTime;
            resultsTable.Rows.Add(totalRow);

            DataRow avgRow = resultsTable.NewRow();
            avgRow["Customers Numbers"] = "Average";
            avgRow["InterArrival Time"] = averageInterArrivalTime;
            avgRow["Service Time"] = averageServiceTime;
            avgRow["Time In Queue"] = averageTimeInQueue;
            avgRow["Time In System"] = averageTimeInSystem;
            avgRow["Idle Time Of Server"] = averageIdleTime;
            resultsTable.Rows.Add(avgRow);


            string statsText =
                $"Average Number of Customers in Queue: {averageNumberOfCustomersInQueue:F2}\n" +
                $"Average Time in Queue per Customer: {averageTimeInQueCustomer:F2}\n" +
                $"Server Utilization: {serverUtilization:P2}";
            resultLabel.Text = statsText;
            resultLabel.Visible = true;
            resultLabel.Font = new Font(resultLabel.Font, FontStyle.Bold);
            resultLabel.ForeColor = Color.DarkBlue;

            dataGridView1.DataSource = resultsTable;
            dataGridView1.AllowUserToAddRows = false;

            int totalIndex = resultsTable.Rows.Count - 2;
            int avgIndex = resultsTable.Rows.Count - 1;
            dataGridView1.Rows[totalIndex].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Rows[totalIndex].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);

            dataGridView1.Rows[avgIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Rows[avgIndex].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);                
        }    
    }
}

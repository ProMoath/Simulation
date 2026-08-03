namespace Simulation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            customers = new TextBox();
            label1 = new Label();
            setUp = new Button();
            Simulate = new Button();
            label2 = new Label();
            resultLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1201, 599);
            dataGridView1.TabIndex = 0;
            // 
            // customers
            // 
            customers.Location = new Point(248, 46);
            customers.Name = "customers";
            customers.Size = new Size(125, 27);
            customers.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 9);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 2;
            label1.Text = "Number Of Customers";
            // 
            // setUp
            // 
            setUp.AutoSize = true;
            setUp.Location = new Point(12, 46);
            setUp.Name = "setUp";
            setUp.Size = new Size(101, 30);
            setUp.TabIndex = 5;
            setUp.Text = "Set Up Form";
            setUp.UseVisualStyleBackColor = true;
            setUp.Click += OpenSetup;
            // 
            // Simulate
            // 
            Simulate.Location = new Point(265, 93);
            Simulate.Name = "Simulate";
            Simulate.Size = new Size(94, 29);
            Simulate.TabIndex = 5;
            Simulate.Text = "Simulate";
            Simulate.UseVisualStyleBackColor = true;
            Simulate.Click += RunSimulation;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 9);
            label2.Name = "label2";
            label2.Size = new Size(156, 20);
            label2.TabIndex = 2;
            label2.Text = "Open Setup Form First";
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(504, 29);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(53, 20);
            resultLabel.TabIndex = 2;
            resultLabel.Text = "resault";
            resultLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 726);
            Controls.Add(Simulate);
            Controls.Add(setUp);
            Controls.Add(label2);
            Controls.Add(resultLabel);
            Controls.Add(label1);
            Controls.Add(customers);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox customers;
        private Label label1;
        private Button setUp;
        private Button Simulate;
        private Label label2;
        private Label resultLabel;
    }
}

namespace Simulation
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            TimeBetweenArrival = new TabPage();
            button3 = new Button();
            button1 = new Button();
            label1 = new Label();
            maxTBA = new TextBox();
            ServiceTime = new TabPage();
            button4 = new Button();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            maxST = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            TimeBetweenArrival.SuspendLayout();
            ServiceTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1158, 456);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellEndEdit += dataGridView_CellEndEdit;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TimeBetweenArrival);
            tabControl1.Controls.Add(ServiceTime);
            tabControl1.Location = new Point(-5, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1172, 599);
            tabControl1.TabIndex = 0;
            // 
            // TimeBetweenArrival
            // 
            TimeBetweenArrival.Controls.Add(button3);
            TimeBetweenArrival.Controls.Add(button1);
            TimeBetweenArrival.Controls.Add(dataGridView1);
            TimeBetweenArrival.Controls.Add(label1);
            TimeBetweenArrival.Controls.Add(maxTBA);
            TimeBetweenArrival.Location = new Point(4, 29);
            TimeBetweenArrival.Name = "TimeBetweenArrival";
            TimeBetweenArrival.Padding = new Padding(3);
            TimeBetweenArrival.Size = new Size(1164, 566);
            TimeBetweenArrival.TabIndex = 0;
            TimeBetweenArrival.Text = "Time Between Arrival";
            TimeBetweenArrival.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Location = new Point(482, 37);
            button3.Name = "button3";
            button3.Size = new Size(155, 30);
            button3.TabIndex = 4;
            button3.Text = "Generate Probability";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(291, 37);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "input";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(359, 20);
            label1.TabIndex = 1;
            label1.Text = "Enter Max Number Of InetrArrival Times From Notice";
            // 
            // maxTBA
            // 
            maxTBA.Location = new Point(94, 37);
            maxTBA.Name = "maxTBA";
            maxTBA.Size = new Size(125, 27);
            maxTBA.TabIndex = 0;
            // 
            // ServiceTime
            // 
            ServiceTime.Controls.Add(button4);
            ServiceTime.Controls.Add(button2);
            ServiceTime.Controls.Add(dataGridView2);
            ServiceTime.Controls.Add(maxST);
            ServiceTime.Controls.Add(label2);
            ServiceTime.Location = new Point(4, 29);
            ServiceTime.Name = "ServiceTime";
            ServiceTime.Padding = new Padding(3);
            ServiceTime.Size = new Size(1164, 566);
            ServiceTime.TabIndex = 1;
            ServiceTime.Text = "Service Time";
            ServiceTime.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.Location = new Point(477, 46);
            button4.Name = "button4";
            button4.Size = new Size(155, 30);
            button4.TabIndex = 6;
            button4.Text = "Generate Probability";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(305, 47);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "input";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(-2, 82);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1175, 407);
            dataGridView2.TabIndex = 4;
            dataGridView2.CellEndEdit += dataGridView_CellEndEdit;
            // 
            // maxST
            // 
            maxST.Location = new Point(98, 49);
            maxST.Name = "maxST";
            maxST.Size = new Size(125, 27);
            maxST.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 14);
            label2.Name = "label2";
            label2.Size = new Size(327, 20);
            label2.TabIndex = 2;
            label2.Text = "Enter Max Number Of Service Time From Notice";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 600);
            Controls.Add(tabControl1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            TimeBetweenArrival.ResumeLayout(false);
            TimeBetweenArrival.PerformLayout();
            ServiceTime.ResumeLayout(false);
            ServiceTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TimeBetweenArrival;
        private TabPage ServiceTime;
        private Label label1;
        private TextBox maxTBA;
        private Label label2;
        private DataGridView dataGridView1;
        private TextBox maxST;
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
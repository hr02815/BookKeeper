namespace project
{
    partial class Sale_Purchase_Details
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LotNumSPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameSPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantitySPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateSPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PaymentIDSPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeORCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LotNumSPD,
            this.NameSPD,
            this.QuantitySPD,
            this.RateSPD,
            this.AmountSPD});
            this.dataGridView1.Location = new System.Drawing.Point(28, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // LotNumSPD
            // 
            this.LotNumSPD.HeaderText = "Lot#";
            this.LotNumSPD.Name = "LotNumSPD";
            // 
            // NameSPD
            // 
            this.NameSPD.HeaderText = "Name";
            this.NameSPD.Name = "NameSPD";
            // 
            // QuantitySPD
            // 
            this.QuantitySPD.HeaderText = "Quantity";
            this.QuantitySPD.Name = "QuantitySPD";
            // 
            // RateSPD
            // 
            this.RateSPD.HeaderText = "Rate";
            this.RateSPD.Name = "RateSPD";
            // 
            // AmountSPD
            // 
            this.AmountSPD.HeaderText = "Amount";
            this.AmountSPD.Name = "AmountSPD";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentIDSPD,
            this.DateSPD,
            this.ChequeORCash,
            this.Payment});
            this.dataGridView2.Location = new System.Drawing.Point(28, 256);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(446, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // PaymentIDSPD
            // 
            this.PaymentIDSPD.HeaderText = "PaymentID";
            this.PaymentIDSPD.Name = "PaymentIDSPD";
            // 
            // DateSPD
            // 
            this.DateSPD.HeaderText = "Date";
            this.DateSPD.Name = "DateSPD";
            // 
            // ChequeORCash
            // 
            this.ChequeORCash.HeaderText = "Cheque/Cash";
            this.ChequeORCash.Name = "ChequeORCash";
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Amount";
            this.Payment.Name = "Payment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(247, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(434, 31);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(55, 432);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bill";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(258, 432);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Payment";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add Payment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Sale_Purchase_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 475);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Sale_Purchase_Details";
            this.Text = "Sale_Purchase_Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNumSPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameSPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantitySPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateSPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountSPD;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentIDSPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeORCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}
namespace SQLiteDBMS
{
    partial class ChangeDebt
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
            this.LoanPeaker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PersonBox = new System.Windows.Forms.ComboBox();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.UpdateDebt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoanPeaker
            // 
            this.LoanPeaker.Location = new System.Drawing.Point(334, 53);
            this.LoanPeaker.Name = "LoanPeaker";
            this.LoanPeaker.Size = new System.Drawing.Size(118, 20);
            this.LoanPeaker.TabIndex = 18;
            this.LoanPeaker.Value = new System.DateTime(2020, 4, 27, 19, 8, 3, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(331, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "On loan from:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(174, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Person id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(21, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Amount:";
            // 
            // PersonBox
            // 
            this.PersonBox.FormattingEnabled = true;
            this.PersonBox.Location = new System.Drawing.Point(177, 53);
            this.PersonBox.Name = "PersonBox";
            this.PersonBox.Size = new System.Drawing.Size(118, 21);
            this.PersonBox.TabIndex = 14;
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(24, 53);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(118, 20);
            this.AmountBox.TabIndex = 13;
            this.AmountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VerifyType);
            // 
            // UpdateDebt
            // 
            this.UpdateDebt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateDebt.Location = new System.Drawing.Point(344, 89);
            this.UpdateDebt.Name = "UpdateDebt";
            this.UpdateDebt.Size = new System.Drawing.Size(108, 28);
            this.UpdateDebt.TabIndex = 12;
            this.UpdateDebt.Text = "Принять";
            this.UpdateDebt.UseVisualStyleBackColor = true;
            this.UpdateDebt.Click += new System.EventHandler(this.UpdateDebt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Изменить запись в таблице Debts:";
            // 
            // ChangeDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 124);
            this.Controls.Add(this.LoanPeaker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PersonBox);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.UpdateDebt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(493, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(493, 163);
            this.Name = "ChangeDebt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeDebt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker LoanPeaker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PersonBox;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.Button UpdateDebt;
        private System.Windows.Forms.Label label1;
    }
}
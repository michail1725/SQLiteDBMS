namespace SQLiteDBMS
{
    partial class AddDebt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDebt));
            this.label1 = new System.Windows.Forms.Label();
            this.InsertDebt = new System.Windows.Forms.Button();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.PersonBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoanPeaker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // InsertDebt
            // 
            resources.ApplyResources(this.InsertDebt, "InsertDebt");
            this.InsertDebt.Name = "InsertDebt";
            this.InsertDebt.UseVisualStyleBackColor = true;
            this.InsertDebt.Click += new System.EventHandler(this.InsertDebt_Click);
            // 
            // AmountBox
            // 
            resources.ApplyResources(this.AmountBox, "AmountBox");
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VerifyType);
            // 
            // PersonBox
            // 
            this.PersonBox.FormattingEnabled = true;
            resources.ApplyResources(this.PersonBox, "PersonBox");
            this.PersonBox.Name = "PersonBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // LoanPeaker
            // 
            resources.ApplyResources(this.LoanPeaker, "LoanPeaker");
            this.LoanPeaker.Name = "LoanPeaker";
            this.LoanPeaker.Value = new System.DateTime(2020, 4, 27, 0, 0, 0, 0);
            // 
            // AddDebt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoanPeaker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PersonBox);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.InsertDebt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDebt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InsertDebt;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.ComboBox PersonBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker LoanPeaker;
    }
}
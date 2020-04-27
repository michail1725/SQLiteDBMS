namespace SQLiteDBMS
{
    partial class ChangePerson
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
            this.label3 = new System.Windows.Forms.Label();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.UpdatePerson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Phone number:";
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(200, 65);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(136, 20);
            this.PhoneBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(27, 65);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(136, 20);
            this.NameBox.TabIndex = 9;
            // 
            // UpdatePerson
            // 
            this.UpdatePerson.Location = new System.Drawing.Point(228, 100);
            this.UpdatePerson.Name = "UpdatePerson";
            this.UpdatePerson.Size = new System.Drawing.Size(108, 28);
            this.UpdatePerson.TabIndex = 8;
            this.UpdatePerson.Text = "Принять";
            this.UpdatePerson.UseVisualStyleBackColor = true;
            this.UpdatePerson.Click += new System.EventHandler(this.UpdatePerson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Изменить запись в таблице Person: ";
            // 
            // ChangePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 142);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.UpdatePerson);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(375, 181);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 181);
            this.Name = "ChangePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button UpdatePerson;
        private System.Windows.Forms.Label label1;
    }
}
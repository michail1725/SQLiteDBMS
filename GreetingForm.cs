using System;
using System.Windows.Forms;

namespace SQLiteDBMS
{
    public partial class GreetingForm : Form
    {
        public GreetingForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Program.Context.MainForm = new MainForm();
            this.Close();
            Program.Context.MainForm.Show();
        }
    }
}

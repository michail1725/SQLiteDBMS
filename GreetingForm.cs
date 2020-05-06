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
            if (checkBox1.Checked == true) {
                var settings = Properties.Settings.Default;
                settings.greetingNecessity = false;
                settings.Save();
            }
            Program.Context.MainForm = new MainForm();
            this.Close();
            Program.Context.MainForm.Show();
        }
    }
}

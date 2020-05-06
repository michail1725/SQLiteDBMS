using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;

namespace SQLiteDBMS
{
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
        }

        private void InsertPerson_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "" || PhoneBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены, добавление невозможно. Проверьте заполенение полей и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            SQLiteCommand command = Connect.CreateCommand();
            command.CommandText = "INSERT INTO Person([Name], [Phone number]) VALUES (@Name,@Phone)";
            command.Parameters.Add(new SQLiteParameter("@Name", NameBox.Text));
            command.Parameters.Add(new SQLiteParameter("@Phone", PhoneBox.Text));
            Connect.Open();
            command.ExecuteNonQuery();
            Connect.Close();
            MessageBox.Show("Успешно добавлено!");
            ActiveForm.Close();
        }
        private void ValidateNumber(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)) return;
            else
                e.Handled = true;
        }
    }
    
}

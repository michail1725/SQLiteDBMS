using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
namespace SQLiteDBMS
{
    public partial class ChangePerson : Form
    {
        int updID;
        public ChangePerson(int id)
        {
            InitializeComponent();
            updID = id;
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            DataTable table = new DataTable();
            SQLiteDataAdapter adt = new SQLiteDataAdapter("select [Name], [Phone number] from Person where [id] =" + updID, Connect);
            adt.Fill(table);
            NameBox.Text = Convert.ToString(table.Rows[0].ItemArray[0]);
            PhoneBox.Text = Convert.ToString(table.Rows[0].ItemArray[1]);
        }

        private void UpdatePerson_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "" || PhoneBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены, изменение невозможно. Проверьте заполенение полей и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            SQLiteCommand command = Connect.CreateCommand();
            command.CommandText = "UPDATE Person SET [Name] = @Name,[Phone number] = @Phone WHERE [id] ="+ updID;
            command.Parameters.Add(new SQLiteParameter("@Name", NameBox.Text));
            command.Parameters.Add(new SQLiteParameter("@Phone", PhoneBox.Text));
            Connect.Open();
            command.ExecuteNonQuery();
            Connect.Close();
            MessageBox.Show("Успешно изменено!");
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

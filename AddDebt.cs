using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace SQLiteDBMS
{
    public partial class AddDebt : Form
    {
        public AddDebt()
        {
            InitializeComponent();
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            DataTable table = new DataTable();
            SQLiteDataAdapter adt = new SQLiteDataAdapter("select * from Person", Connect);
            adt.Fill(table);
            PersonBox.DataSource = table;
            PersonBox.DisplayMember = "id";
            PersonBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void InsertDebt_Click(object sender, EventArgs e)
        {
            if (AmountBox.Text == "" || PersonBox.Text == "" || LoanPeaker.Value == null) {
                MessageBox.Show("Не все поля заполнены, добавление невозможно. Проверьте заполенение полей и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            SQLiteCommand command = Connect.CreateCommand();
            command.CommandText = "INSERT INTO Debts([Amount], [Person_id], [On loan from]) VALUES (@Amount,@id,@Loan)";
            command.Parameters.Add(new SQLiteParameter("@Amount", AmountBox.Text));
            command.Parameters.Add(new SQLiteParameter("@id", PersonBox.Text));
            command.Parameters.Add(new SQLiteParameter("@Loan", LoanPeaker.Value));
            Connect.Open();
            command.ExecuteNonQuery();
            Connect.Close();
            MessageBox.Show("Успешно добавлено!");
            ActiveForm.Close();
        }

        private void VerifyType(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)) return;
            else
                e.Handled = true;
        }
    }
}

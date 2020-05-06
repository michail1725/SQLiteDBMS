using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace SQLiteDBMS
{
    public partial class AddDebt : Form
    {
        DataTable table = new DataTable();
        public AddDebt()
        {
            InitializeComponent();
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            
            SQLiteDataAdapter adt = new SQLiteDataAdapter("select * from Person", Connect);
            adt.Fill(table);
            PersonBox.DataSource = table;
            PersonBox.DisplayMember = "Name";
            PersonBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LoanPeaker.Value = DateTime.Now;
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
            string currId = "";
            foreach (DataRow tmp in table.Rows) {
                if (tmp.ItemArray[1].ToString() == PersonBox.Text) {
                    currId = tmp.ItemArray[0].ToString();
                }
            }
            command.Parameters.Add(new SQLiteParameter("@id", currId));
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

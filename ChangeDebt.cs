using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace SQLiteDBMS
{
    public partial class ChangeDebt : Form
    {
        int updID;
        public ChangeDebt(int id)
        {
            InitializeComponent();
            updID = id;
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            DataTable table = new DataTable();
            SQLiteDataAdapter adt = new SQLiteDataAdapter("select * from Person", Connect);
            adt.Fill(table);
            PersonBox.DataSource = table;
            PersonBox.DisplayMember = "id";
            adt = new SQLiteDataAdapter("select [Amount], [Person_id], [On loan from] from Debts where [id] =" + updID, Connect);
            table = new DataTable();
            adt.Fill(table);
            AmountBox.Text = Convert.ToString(table.Rows[0].ItemArray[0]);
            PersonBox.Text = Convert.ToString(table.Rows[0].ItemArray[1]);
            PersonBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LoanPeaker.Text = Convert.ToDateTime(table.Rows[0].ItemArray[2]).ToString("dd.MM.yyyy");
        }

        private void UpdateDebt_Click(object sender, EventArgs e)
        {
            if (AmountBox.Text == "" || PersonBox.Text == "" || LoanPeaker.Value == null)
            {
                MessageBox.Show("Не все поля заполнены, изменение невозможно. Проверьте заполенение полей и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = ConfigurationManager.AppSettings.Get("DataBasePath");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + path);
            SQLiteCommand command = Connect.CreateCommand();
            command.CommandText = "UPDATE Debts SET [Amount] = @Amount, [Person_id] = @id, [On loan from] = @Loan WHERE[id] = "+ updID;
            command.Parameters.Add(new SQLiteParameter("@Amount", AmountBox.Text));
            command.Parameters.Add(new SQLiteParameter("@id", PersonBox.Text));
            command.Parameters.Add(new SQLiteParameter("@Loan", LoanPeaker.Value));
            Connect.Open();
            command.ExecuteNonQuery();
            Connect.Close();
            MessageBox.Show("Успешно изменено!");
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

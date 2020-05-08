using System.Configuration;
using System;
using System.Data;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;


namespace SQLiteDBMS
{
    public partial class MainForm : Form
    {
        DataSet ds;
        SQLiteDataAdapter adapter;
        SQLiteCommandBuilder commandBuilder;
        SQLiteConnection connect;
        SQLiteCommand cmd;
        string path;
        public MainForm()
        {
            InitializeComponent();
            path = ConfigurationManager.AppSettings.Get("DataBasePath");
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path); 
            }
            
            using (connect = new SQLiteConnection(@"Data Source=" + path)) {
                string commandText = "CREATE TABLE IF NOT EXISTS [Person] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Name] VARCHAR(45), [Phone number] VARCHAR(45))";
                SQLiteCommand Command = new SQLiteCommand(commandText, connect);
                connect.Open();
                Command.ExecuteNonQuery();
                connect.Close();
                connect.Open();
                commandText = "CREATE TABLE IF NOT EXISTS [Debts] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,[Amount] INTEGER,[Person_id] INTEGER NOT NULL,[On loan from] DATE, FOREIGN KEY ([Person_id]) REFERENCES [Person]([id]))";
                Command = new SQLiteCommand(commandText, connect);
                Command.ExecuteNonQuery();
                connect.Close();
            }
            TableChoice.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void SaveAll(object sender, EventArgs e)
        {
            using (connect = new SQLiteConnection(@"Data Source=" + path))
            {
                try
                {
                    connect.Open();
                    cmd = connect.CreateCommand();
                    cmd.CommandText = string.Format("SELECT * FROM {0}", TableChoice.Text);
                    adapter = new SQLiteDataAdapter(cmd);
                    commandBuilder = new SQLiteCommandBuilder(adapter);
                    adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    adapter.Update(ds.Tables[0]);
                    connect.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            GetTableSet(sender,e);
        }

        private void GetTableSet(object sender, EventArgs e)
        {
            Export.Enabled = true;
            string sql;
            if (TableChoice.Text == "Люди") {
                sql = "SELECT [id],[Name] AS [Имя],[Phone number] AS [Номер телефона],(SELECT SUM(Amount) From Debts Where Person.id = Debts.Person_id Group by Person_id) AS [Суммарный долг] FROM Person";
                
            }
            else{
                sql = "SELECT [id],[Amount] AS [Размер долга],[Person_id] AS [id Должника],[On loan from] AS [Долг взят] FROM Debts";
            }
            using (connect = new SQLiteConnection(@"Data Source=" + path))
            {
                connect.Open();
                adapter = new SQLiteDataAdapter(sql, connect);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                
            }
            if (checkBox1.Checked == false) {
                Add.Enabled = true;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                DeleteButton.Enabled = false;
                ChangeData.Enabled = false;
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[0] != null)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
            if (dataGridView1.Rows.Count == 0) {
                DeleteButton.Enabled = false;
                ChangeData.Enabled = false;
            }

            SaveAll(sender,e);
        }

        private void UseTypeChange(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DeleteButton.Enabled = false;
                ChangeData.Enabled = false;
                Add.Enabled = false;
            }
            else { 
                if (TableChoice.Text != "") {
                    Add.Enabled = true;
                }
                AllowChangeContent(sender,e);
            }
        }



    
        private void Add_Click(object sender, EventArgs e)
        {
            if (TableChoice.Text == "Люди")
            {
                AddPerson addPerson = new AddPerson();
                addPerson.ShowDialog();
                GetTableSet(sender,e);
            }
            else
            {
                SQLiteConnection connect = new SQLiteConnection(@"Data Source=" + path);
                DataTable table = new DataTable();
                SQLiteDataAdapter adt = new SQLiteDataAdapter("select * from Person", connect);
                adt.Fill(table);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Невозможно создать запись о долге, так как список потенциальных должников пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AddDebt addDebt = new AddDebt();
                addDebt.ShowDialog();
                GetTableSet(sender,e);
            }
        }

        private void ChangeData_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            if (TableChoice.Text == "Люди")
            {
                ChangePerson changePerson = new ChangePerson(id);
                changePerson.ShowDialog();
                GetTableSet(sender, e);
            }
            else
            {
                ChangeDebt changeDebt = new ChangeDebt(id);
                changeDebt.ShowDialog();
                GetTableSet(sender, e);
            }
        }

        private void AllowChangeContent(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && checkBox1.Checked == false)
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    ChangeData.Enabled = true;
                    DeleteButton.Enabled = true;
                }
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}

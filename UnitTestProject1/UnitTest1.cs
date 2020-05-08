using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.IO;
using System.Data.SQLite;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        SQLiteConnection connect;
        
        string path = ConfigurationManager.AppSettings.Get("DataBasePath");

        [TestMethod]
        public void AddTest()
        {
            connect = new SQLiteConnection(@"Data Source=" + path);
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }
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
                DataTable table = new DataTable();
                SQLiteDataAdapter adt = new SQLiteDataAdapter("select [Name], [Phone number] from Person", connect);
                adt.Fill(table);
                int expRowCount = table.Rows.Count;
                SQLiteCommand command = connect.CreateCommand();
                command.CommandText = "INSERT INTO Person([Name], [Phone number]) VALUES (@Name,@Phone)";
                command.Parameters.Add(new SQLiteParameter("@Name", "Николай"));
                command.Parameters.Add(new SQLiteParameter("@Phone", "5920834"));
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                table = new DataTable();
                adt = new SQLiteDataAdapter("select [Name], [Phone number] from Person", connect);
                adt.Fill(table);
                Assert.AreEqual(expRowCount+1, table.Rows.Count);
        }

        [TestMethod]
        public void EditTest()
        {
            SQLiteConnection connect = new SQLiteConnection(@"Data Source=" + path);
            SQLiteCommand command = connect.CreateCommand();
            command.CommandText = "UPDATE Person SET [Name] = @Name,[Phone number] = @Phone WHERE [id] =" + 1;
            command.Parameters.Add(new SQLiteParameter("@Name", "Евгений"));
            command.Parameters.Add(new SQLiteParameter("@Phone", "6433892"));
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            DataTable table = new DataTable();
            SQLiteDataAdapter adt = new SQLiteDataAdapter("select [Name], [Phone number] from Person", connect);
            adt.Fill(table);
            Assert.AreEqual("Евгений",table.Rows[0].ItemArray[0]);
            Assert.AreEqual("6433892", table.Rows[0].ItemArray[1]);
        }
        
        
    }
}

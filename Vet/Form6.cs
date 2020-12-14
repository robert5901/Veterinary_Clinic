using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ветклиника
{
    public partial class Form6 : Form
    {
        SqlConnection sqlConnection;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)  //подключение бд
        {
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rober\Desktop\Проекты\Ветклиника\Ветклиника\Database.mdf;Integrated Security=True");
            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string query = "SELECT * FROM [Врачи]";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())  //для прочтения всех строк
            {
                data.Add(new string[1]); //на каждой итерации добавление новой строки в список

                data[data.Count - 1][0] = reader[0].ToString(); //в первый элемент заносится значение первого столбца
            }
            reader.Close();
            sqlConnection.Close();

            foreach (string[] s in data)    //вывод полученных данных в dataGridView
                dataGridView1.Rows.Add(s);
        }
    }
}

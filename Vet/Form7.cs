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
    public partial class Form7 : Form
    {
        SqlConnection sqlConnection;
        public Form7()
        {
            InitializeComponent();
        }

        private async void Form7_Load(object sender, EventArgs e)  //подключение бд
        {
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rober\Desktop\Проекты\Ветклиника\Ветклиника\Database.mdf;Integrated Security=True");
            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string query = "SELECT * FROM [Животные]";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())  //для прочтения всех строк
            {
                data.Add(new string[6]); //на каждой итерации добавление новой строки в список

                data[data.Count - 1][0] = reader[0].ToString(); //в первый элемент заносится значение первого столбца
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }
            reader.Close();
            sqlConnection.Close();

            foreach (string[] s in data)    //вывод полученных данных в dataGridView
                dataGridView1.Rows.Add(s);
        }    
    }
}

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
    public partial class Form8 : Form
    {
        SqlConnection sqlConnection;

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rober\Desktop\Проекты\Ветклиника\Ветклиника\Database.mdf;Integrated Security=True");
            sqlConnection = new SqlConnection(connectionString);

            if (label4.Visible)
                label4.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&        //проверка на заполнение всех строк
                    !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(comboBox1.Text) &&
                    !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) &&
                    !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                sqlConnection.Open();
                SqlCommand update = new SqlCommand("UPDATE [Животные] SET [вид]=@вид,[порода]=@порода," +
                        "[кличка]=@кличка,[пол]=@пол,[ФИОхозяина]= @ФИОхозяина WHERE [Idкарточки]=@Idкарточки", sqlConnection);
                update.Parameters.AddWithValue("Idкарточки", textBox10.Text);
                update.Parameters.AddWithValue("вид", textBox1.Text);
                update.Parameters.AddWithValue("порода", textBox3.Text);
                update.Parameters.AddWithValue("кличка", textBox2.Text);
                update.Parameters.AddWithValue("пол", comboBox1.Text);
                update.Parameters.AddWithValue("ФИОхозяина", textBox6.Text);
                await update.ExecuteNonQueryAsync();
                SqlCommand update1 = new SqlCommand("UPDATE [Клиенты] SET [ФИО]=@ФИО,[номертелефона]=@номертелефона" +
                " WHERE [ФИО]=@ФИО", sqlConnection);
                update1.Parameters.AddWithValue("ФИО", textBox6.Text);
                update1.Parameters.AddWithValue("номертелефона", textBox7.Text);
                await update1.ExecuteNonQueryAsync();
                SqlCommand update2 = new SqlCommand("UPDATE [Посещения] SET [Диагноз]=@Диагноз WHERE [Idкарточки]=@Idкарточки", sqlConnection);
                update2.Parameters.AddWithValue("Idкарточки", textBox10.Text);
                update2.Parameters.AddWithValue("Диагноз", textBox8.Text);
                await update2.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            else
            {
                label4.Visible = true;
            }
        }

        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rober\Desktop\Проекты\Ветклиника\Ветклиника\Database.mdf;Integrated Security=True");
            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Животные] WHERE [ФИОхозяина] = @ФИОхозяина ", sqlConnection);
            command.Parameters.AddWithValue("ФИОхозяина", textBox4.Text);

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

            foreach (string[] s in data)       //удаление всех данных из dataGridView
                dataGridView1.Rows.Clear();

            foreach (string[] s in data)    //вывод полученных данных в dataGridView
                dataGridView1.Rows.Add(s);  
        }
    }
}


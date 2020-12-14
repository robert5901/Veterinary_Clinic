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
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        public Form3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rober\Desktop\Проекты\Ветклиника\Ветклиника\Database.mdf;Integrated Security=True");
            sqlConnection = new SqlConnection(connectionString);

            if (label4.Visible)
                label4.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&        //проверка на заполнение всех строк
                    !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(comboBox1.Text) &&
                    !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) && 
                    !string.IsNullOrEmpty(textBox8.Text))
              {
                await sqlConnection.OpenAsync();
                SqlCommand insert1 = new SqlCommand("INSERT INTO [Животные](вид,порода,кличка,пол,ФИОхозяина) " +
                    "VALUES (@вид,@порода,@кличка,@пол,@ФИОхозяина)", sqlConnection);
                insert1.Parameters.AddWithValue("вид", textBox1.Text);
                insert1.Parameters.AddWithValue("порода", textBox3.Text);
                insert1.Parameters.AddWithValue("кличка", textBox2.Text); 
                insert1.Parameters.AddWithValue("пол", comboBox1.Text);
                insert1.Parameters.AddWithValue("ФИОхозяина", textBox6.Text);
                await insert1.ExecuteNonQueryAsync();
                SqlCommand insert2 = new SqlCommand("INSERT INTO [Клиенты](ФИО,номертелефона) VALUES (@ФИО,@номертелефона)", sqlConnection);
                insert2.Parameters.AddWithValue("ФИО", textBox6.Text);
                insert2.Parameters.AddWithValue("номертелефона", textBox7.Text);
                await insert2.ExecuteNonQueryAsync();
              SqlCommand insert3 = new SqlCommand("INSERT INTO [Посещения](Диагноз) VALUES (@Диагноз)", sqlConnection);
                insert3.Parameters.AddWithValue("Диагноз", textBox8.Text);
                await insert3.ExecuteNonQueryAsync();
              textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox8.Text = null;
                comboBox1.Text = null;
            }
            else
            {
                label4.Visible = true;
            }
        }
   
    }  
}

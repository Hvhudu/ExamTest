using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTest
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""|| textBox2.Text != ""|| textBox3.Text != ""|| textBox4.Text != ""){

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("DriverAdd", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@First_Name", SqlDbType.NVarChar, 50));
                        sqlCommand.Parameters["@First_Name"].Value = textBox1.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Last_Name", SqlDbType.NVarChar, 50));
                        sqlCommand.Parameters["@Last_Name"].Value = textBox3.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Midle_Name", SqlDbType.NVarChar, 50));
                        sqlCommand.Parameters["@Midle_Name"].Value = textBox2.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Rating", SqlDbType.Float));
                        sqlCommand.Parameters["@Rating"].Value = textBox4.Text;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Error!!!");
                        }
                        finally
                        {
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Отсутствуют данные");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    
}

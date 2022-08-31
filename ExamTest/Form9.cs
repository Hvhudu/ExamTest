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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox4.Text != "")
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("AddAuto", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@Fabricator", SqlDbType.NVarChar, 50));
                        sqlCommand.Parameters["@Fabricator"].Value = textBox1.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.NVarChar, 50));
                        sqlCommand.Parameters["@Model"].Value = textBox2.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@ReliaseDate", SqlDbType.DateTime));
                        sqlCommand.Parameters["@ReliaseDate"].Value = dateTimePicker1.Value;

                        sqlCommand.Parameters.Add(new SqlParameter("@StateNumber", SqlDbType.NVarChar, 15));
                        sqlCommand.Parameters["@StateNumber"].Value = textBox4.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@DriverId", SqlDbType.Int));
                        sqlCommand.Parameters["@DriverId"].Value = Convert.ToInt32(textBox5.Text);


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
    }
}

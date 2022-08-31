using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ExamTest
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "")
            {

                using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using(SqlCommand sqlCommand = new SqlCommand("AddClient",connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@First_Name", SqlDbType.NVarChar, 50);
                        sqlCommand.Parameters["@First_Name"].Value = textBox1.Text;

                        sqlCommand.Parameters.Add("@Last_Name", SqlDbType.NVarChar);
                        sqlCommand.Parameters["@Last_Name"].Value = textBox2.Text;

                        sqlCommand.Parameters.Add("@Midle_Name", SqlDbType.NVarChar, 50);
                        sqlCommand.Parameters["@Midle_Name"].Value = textBox3.Text;

                        sqlCommand.Parameters.Add("@Rating", SqlDbType.Float);
                        sqlCommand.Parameters["@Rating"].Value = Convert.ToDouble(textBox4.Text);

                        sqlCommand.Parameters.Add("@Phone_Number", SqlDbType.NVarChar, 50);
                        sqlCommand.Parameters["@Phone_Number"].Value = maskedTextBox1.Text;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Erroe!!!");
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
                MessageBox.Show("Данные отсутствуют");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

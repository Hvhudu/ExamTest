using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamTest
{
    public partial class Form2 : Form
    {
        //string cs = @"Data Source = LAPTOP - QJJL49PJ\SQLEXPRESS; Initial Catalog = Exam1; ";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Adress_From_tb.Text != "" || Adress_Where_tb.Text != "" || textBox1.Text != ""
                || textBox2.Text != "" || textBox3.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using(SqlCommand sqlCommand = new SqlCommand("AddOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@Adress_From", SqlDbType.NVarChar, 70));
                        sqlCommand.Parameters["@Adress_From"].Value = Adress_From_tb.Text;
    
                        sqlCommand.Parameters.Add(new SqlParameter("@Adress_Where", SqlDbType.NVarChar, 70));
                        sqlCommand.Parameters["@Adress_Where"].Value = Adress_Where_tb.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Time", SqlDbType.DateTime));
                        sqlCommand.Parameters["@Time"].Value = dateTimePicker1.Value;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                        sqlCommand.Parameters["@Price"].Value = Price_tb.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Auto_Id", SqlDbType.Int));
                        sqlCommand.Parameters["@Auto_Id"].Value = textBox3.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Driver_Id", SqlDbType.Int));
                        sqlCommand.Parameters["@Driver_Id"].Value = textBox2.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Client_Id", SqlDbType.Int));
                        sqlCommand.Parameters["@Client_Id"].Value = textBox1.Text;

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

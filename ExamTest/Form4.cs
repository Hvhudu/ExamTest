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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@orderId", SqlDbType.Int));
                        command.Parameters["@orderId"].Value = Convert.ToInt32(textBox1.Text);
                        try
                        {
                            connection.Open();

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                DataTable table = new DataTable();
                                table.Load(dataReader);
                                this.dataGridView1.DataSource = table;
                                dataReader.Close();
                            }

                        }
                        catch
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Отсутствуют данные");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("OrderAll", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(dataReader);
                            this.dataGridView1.DataSource = table;
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error!!!");
                    }
                    
                }
            }
        }
    }
}

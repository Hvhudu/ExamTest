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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("DriverById",connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@driverId", SqlDbType.Int));
                        command.Parameters["@driverId"].Value = Convert.ToInt32(textBox1.Text);

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
            Form5 form = new Form5();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
            {
                using(SqlCommand sqlCommand = new SqlCommand("DriverAll",connection))
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("AutoById", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@autoId", SqlDbType.Int));
                        sqlCommand.Parameters["@autoId"].Value = Convert.ToInt32(textBox1.Text);

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

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("AutoAll", connection))
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

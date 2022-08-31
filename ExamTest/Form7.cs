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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("ClientById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@clientId", SqlDbType.Int));
                        command.Parameters["@clientId"].Value = Convert.ToInt32(textBox1.Text);

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

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exam"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ClientAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

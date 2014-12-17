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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.database1DataSet.student);

        }

        private void showAllToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.ShowAll(this.database1DataSet.student);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.Database1ConnectionString);
            try
            {
                string sql = "insert into student (id, name) values("+idTextBox.Text+",'"+nameTextBox.Text+"')";
                var exeSql = new SqlCommand(sql,cn);
                cn.Open();
                exeSql.ExecuteNonQuery();
                
                MessageBox.Show("Done", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.studentTableAdapter.Fill(this.database1DataSet.student);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.database1DataSet.student);
        }
    }
}

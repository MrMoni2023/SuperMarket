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

namespace SuperMarket
{
    public partial class NaheedCategoryForm : Form
    {
        DBConnection DBconnect = new DBConnection();

        public NaheedCategoryForm()
        {
            InitializeComponent();
        }
        //Select Querey and displaing it on grid view Table
        private void GetTable()
        {
            string SelectQuerey = "Select * From NaheedCategory";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_categoryNAH.DataSource = table;
        }
        private void NaheedCategoryForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }
        private void Clear()
        {
            TextBox_id.Clear();
            CatTextBox_nameNAH.Clear();
            CAtTextBox_descripNAH.Clear();
        }

        private void Catbutton_addNAH_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuery = "INSERT INTO NaheedCategory  VALUES("+TextBox_id.Text+",'" + CatTextBox_nameNAH.Text + "','" + CAtTextBox_descripNAH.Text + "')";
                SqlCommand Command = new SqlCommand(InsertQuery, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Category ADDED Successfully", "Added information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_categoryNAH_Click(object sender, EventArgs e)
        {
            TextBox_id.Text = DataGridView_categoryNAH.SelectedRows[0].Cells[0].Value.ToString();
            CatTextBox_nameNAH.Text = DataGridView_categoryNAH.SelectedRows[0].Cells[1].Value.ToString();
            CAtTextBox_descripNAH.Text = DataGridView_categoryNAH.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button_updateNAH_Click(object sender, EventArgs e)
        {
            try
            {
                if ( TextBox_id.Text == "" ||CatTextBox_nameNAH.Text == "" || CAtTextBox_descripNAH.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string UpdateQuerey = "UPDATE NaheedCategory SET CategoryName =' " + CatTextBox_nameNAH.Text + " ',CategoryDsecription = '" + CAtTextBox_descripNAH.Text + "' WHERE CategoryId = '" + TextBox_id.Text + "'";
                SqlCommand Command = new SqlCommand(UpdateQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Category Updated Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button_deleteNAH_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                        string DeleteQuery = "DELETE FROM NaheedCategory WHERE CategoryId = " + TextBox_id.Text + "";
                        SqlCommand Command = new SqlCommand(DeleteQuery, DBconnect.GetCon());
                        DBconnect.OpenCon();
                        Command.ExecuteNonQuery();
                        MessageBox.Show("Category Deleted Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DBconnect.Closecon();
                        GetTable();
                        Clear();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void NAHbutton_seller_Click(object sender, EventArgs e)
        {
            NaheedSellerForm form = new NaheedSellerForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_product_Click(object sender, EventArgs e)
        {
            NaheedProductForm form = new NaheedProductForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_selling_Click(object sender, EventArgs e)
        {
            NaheedSellingForm form = new NaheedSellingForm();
            form.Show();
            this.Hide();
        }

        private void label_exit_NAH_MouseEnter(object sender, EventArgs e)
        {
            label_exit_NAH.ForeColor = Color.AliceBlue;
        }

        private void label_exit_NAH_MouseLeave(object sender, EventArgs e)
        {
            label_exit_NAH.ForeColor = Color.Crimson;
        }

        private void label_exit_NAH_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logoutNAH_MouseEnter(object sender, EventArgs e)
        {
            label_logoutNAH.ForeColor = Color.AliceBlue;
        }

        private void label_logoutNAH_MouseLeave(object sender, EventArgs e)
        {
            label_logoutNAH.ForeColor = Color.Crimson;
        }

        private void label_logoutNAH_Click(object sender, EventArgs e)
        {
            LoginForm_Naheed_cs form = new LoginForm_Naheed_cs();
            form.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

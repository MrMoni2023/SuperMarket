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
using System.Data.SqlClient;

namespace SuperMarket
{
    public partial class ImtiazCategoryForm : Form
    {
        public ImtiazCategoryForm()
        {
            InitializeComponent();
        }
        DBConnection DBconnect = new DBConnection();

        //Select Querey and displaing it on grid view Table
        private void GetTable()
        {
            string SelectQuerey = "Select * From ImtiazCategory";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_category.DataSource = table;
        }
        //Insert Querey
        private void Catbutton_add_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuery = "INSERT INTO ImtiazCategory  VALUES("+TextBox_id.Text+",'"+CatTextBox_name.Text+"','"+CAtTextBox_descrip.Text+"')";
                SqlCommand Command  = new SqlCommand(InsertQuery,DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Category ADDED Successfully","Added information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable(); 
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //calling informtion display on drid view table
        private void ImtiazCategoryForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }
        // Update querey
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ( TextBox_id.Text == "" || CatTextBox_name.Text == "" || CAtTextBox_descrip.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string UpdateQuerey = "UPDATE ImtiazCategory SET CategoryName ='" + CatTextBox_name.Text + "',CategoryDescription =  '" + CAtTextBox_descrip.Text + "' WHERE CategoryId = '" + TextBox_id.Text + "'";
                SqlCommand Command = new SqlCommand(UpdateQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Category Updated Successfully","Updated Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable();
                Clear();
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        //showing value when we click on the values i the data gris view tavle
        private void DataGridView_category_Click(object sender, EventArgs e)
        {
            TextBox_id.Text = DataGridView_category.SelectedRows[0].Cells[0].Value.ToString();
            CatTextBox_name.Text = DataGridView_category.SelectedRows[0].Cells[1].Value.ToString();
            CAtTextBox_descrip.Text = DataGridView_category.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void Clear()
        {
           TextBox_id.Clear();
            CatTextBox_name.Clear();
            CAtTextBox_descrip.Clear();
        }

        private void imtaizbutton_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                        string DeleteQuery = "DELETE FROM ImtiazCategory WHERE CategoryId = " + TextBox_id.Text + "";
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

        private void label_exit_imt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_exit_imt_MouseEnter(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Red;
        }

        private void label_exit_imt_MouseLeave(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.CadetBlue;
        }

       

        private void label_logout_MouseEnter(object sender, EventArgs e)
        {
           
           
        }

        private void label_logout_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void Imtiazlabel_logout_MouseEnter(object sender, EventArgs e)
        {
            Imtiazlabel_logout.ForeColor = Color.Red;
        }

        private void Imtiazlabel_logout_MouseLeave(object sender, EventArgs e)
        {
            Imtiazlabel_logout.ForeColor = Color.CadetBlue;
        }

        private void Imtiazlabel_logout_Click(object sender, EventArgs e)
        {
            UIForm form = new UIForm();
            form.Show();
            this.Hide();
        }

        private void imtiazbutton_product_Click(object sender, EventArgs e)
        {
            ImtiazProductForm Product = new ImtiazProductForm();
            Product.Show();
            this.Hide();
        }

        private void imtiazbutton_seller_Click(object sender, EventArgs e)
        {
            ImtiazSellerForm sellerForm = new ImtiazSellerForm();   
            sellerForm.Show();
            this.Hide();
        }

        private void imtiazbutton_selling_Click(object sender, EventArgs e)
        {
            ImtiazSellingForm form = new ImtiazSellingForm();
            form.Show();
            this.Hide();
        }

        private void DataGridView_category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CAtTextBox_descrip_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

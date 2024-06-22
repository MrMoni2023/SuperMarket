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
    public partial class NaheedSellerForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        public NaheedSellerForm()
        {
            InitializeComponent();
        }
        private void GetTable()
        {
            string SelectQuerey = "Select * From NaheedSeller";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_sellerNAH.DataSource = table;
        }
        private void Clear()
        {
            NAHTextBox_id.Clear();
            NAHTextBox_name.Clear();
            NAHTextBox_age.Clear();
            NAHTextBox_phone.Clear();
            NAHTextBox_pass.Clear();
        }

        private void NaheedSellerForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void NAHbutton_add_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuerey = "INSERT INTO NaheedSeller VALUES (" + NAHTextBox_id.Text + ",'" + NAHTextBox_name.Text + "','" + NAHTextBox_age.Text + "','" + NAHTextBox_phone.Text + "','" + NAHTextBox_pass.Text + "' )";
                SqlCommand Command = new SqlCommand(InsertQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Seller ADDED Successfully", "Added information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable();
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void NAHbutton_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (NAHTextBox_id.Text == "" || NAHTextBox_name.Text == "" || NAHTextBox_age.Text == "" || NAHTextBox_phone.Text == "" || NAHTextBox_pass.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string UpdateQuerey = "UPDATE NaheedSeller SET SellerName = '" + NAHTextBox_name.Text + "',SellerAge = '" + NAHTextBox_age.Text + "',SellerPhone = '" + NAHTextBox_phone.Text + "',SellerPass = '" + NAHTextBox_pass.Text + "' WHERE SellerId = '" + NAHTextBox_id.Text + "'";
                    SqlCommand Command = new SqlCommand(UpdateQuerey, DBconnect.GetCon());
                    DBconnect.OpenCon();
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Seller  Updated Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DataGridView_sellerNAH_Click(object sender, EventArgs e)
        {
            NAHTextBox_id.Text = DataGridView_sellerNAH.SelectedRows[0].Cells[0].Value.ToString();
            NAHTextBox_name.Text = DataGridView_sellerNAH.SelectedRows[0].Cells[1].Value.ToString();
            NAHTextBox_age.Text = DataGridView_sellerNAH.SelectedRows[0].Cells[2].Value.ToString();
            NAHTextBox_phone.Text = DataGridView_sellerNAH.SelectedRows[0].Cells[3].Value.ToString();
            NAHTextBox_pass.Text = DataGridView_sellerNAH.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void NAHbutton_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (NAHTextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string DeleteQuery = "DELETE FROM NaheedSeller WHERE SellerId = " + NAHTextBox_id.Text + "";
                    SqlCommand Command = new SqlCommand(DeleteQuery, DBconnect.GetCon());
                    DBconnect.OpenCon();
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void NAHbutton_product_Click(object sender, EventArgs e)
        {
            NaheedProductForm form = new NaheedProductForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_category_Click(object sender, EventArgs e)
        {
            NaheedCategoryForm form = new NaheedCategoryForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_selling_Click(object sender, EventArgs e)
        {
            NaheedSellingForm form = new NaheedSellingForm();
            form.Show();
            this.Hide();
        }

        private void label_exit_NAH_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_exit_NAH_MouseEnter(object sender, EventArgs e)
        {
            label_exit_NAH.ForeColor = Color.AliceBlue;
        }

        private void label_logout_NAH_MouseEnter(object sender, EventArgs e)
        {
            label_logout_NAH.ForeColor = Color.AliceBlue;
        }

        private void label_logout_NAH_Click(object sender, EventArgs e)
        {
            LoginForm_Naheed_cs loginForm_ = new LoginForm_Naheed_cs();
            loginForm_.Show();
            this.Hide();
        }

        private void label_logout_NAH_MouseLeave(object sender, EventArgs e)
        {
            label_logout_NAH.ForeColor = Color.Crimson;
        }

        private void label_exit_NAH_MouseLeave(object sender, EventArgs e)
        {
            label_exit_NAH.ForeColor= Color.Crimson;
        }
    }
}

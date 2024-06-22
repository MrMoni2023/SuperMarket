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
using DGVPrinterHelper;

namespace SuperMarket
{
    public partial class ImtiazSellingForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        DGVPrinter Printer = new DGVPrinter();
        public ImtiazSellingForm()
        {
            InitializeComponent();
        }

        private void label_exit_imt_MouseEnter(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Red;
        }

        private void label_exit_imt_MouseLeave(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.CadetBlue;
        }

        private void label_exit_imt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logout_imt_MouseEnter(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor = Color.Red;
        }

        private void label_logout_imt_MouseLeave(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor = Color.CadetBlue;
        }

        private void label_logout_imt_Click(object sender, EventArgs e)
        {
            UIForm form = new UIForm();
            form.Show();
            this.Hide();
        }

        private void GetCategory()
        {

            string SelectQuerey = "Select * From ImtiazCategory";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            ImtiazcomboBox_categories.DataSource = table;
            ImtiazcomboBox_categories.ValueMember = "CategoryName";
           
        }
        private void GetTable()
        {
            string SelectQuerey = "Select ProductName,ProductPrice From ImtiazProduct";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_products.DataSource = table;
        }
        private void GetSellTable()
        {
            string SelectQuerey = "Select *  From ImtiazCustomer";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_sells_list.DataSource = table;
        }
        private void ImtiazSellingForm_Load(object sender, EventArgs e)
        {
            label_date.Text = DateTime.Today.ToShortDateString();
            label_seller.Text = UIForm.SellerName;
            
            GetTable();
            GetCategory();
            GetSellTable();
        }

        private void DataGridView_products_Click(object sender, EventArgs e)
        {
            TextBox_name.Text = DataGridView_products.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_price.Text = DataGridView_products.SelectedRows[0].Cells[1].Value.ToString();
        }
        int GrandTotal = 0, n=0;

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuerey = "INSERT INTO ImtiazCustomer VALUES (" + TextBox_id.Text + ",'" + label_seller.Text + "','" + label_date.Text + "','" + GrandTotal.ToString() + "' )";
                SqlCommand Command = new SqlCommand(InsertQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Order ADDED Successfully", " Order information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetSellTable(); 
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void imtaizbutton_print_Click(object sender, EventArgs e)
        {
            //Using DGVpirinter Help for Printing with Pdf File
            Printer.Title = "Multi Vender SuperMarket List";
            Printer.SubTitle = String.Format("Date : {0}", DateTime.Now);
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = true;
            Printer.HeaderCellAlignment = StringAlignment.Near;
            Printer.Footer = "PAF KIET";
            Printer.FooterSpacing = 15;
            Printer.printDocument.DefaultPageSettings.Landscape = true;
            Printer.PrintDataGridView(DataGridView_sells_list);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            GetTable();
        }

        private void ImtiazcomboBox_categories_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string SelectQuerey = "Select ProductName,ProductPrice From ImtiazProduct WHERE ProductCat = '" + ImtiazcomboBox_categories.SelectedValue.ToString() + "'";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table); 
            DataGridView_products.DataSource = table;
        }

        private void button_addorder_Click(object sender, EventArgs e)
        {
            if (TextBox_name.Text == "" || TextBox_Qty.Text == "")
            {
                MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int Total = Convert.ToInt32(TextBox_price.Text) * Convert.ToInt32(TextBox_Qty.Text);
                DataGridViewRow addrow = new DataGridViewRow();
                addrow.CreateCells(DataGridView_order);
                addrow.Cells[0].Value = ++n;
                addrow.Cells[1].Value = TextBox_name.Text;
                addrow.Cells[2].Value = TextBox_price.Text;
                addrow.Cells[3].Value = TextBox_Qty.Text;
                addrow.Cells[4].Value = Total;
                DataGridView_order.Rows.Add(addrow);
                GrandTotal += Total;
                label_Amoun.Text = " Rs  " + GrandTotal;
            }
        }
    }
}

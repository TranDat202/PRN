using EX5;
using System.Data;
using System.Xml.Linq;

namespace PT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        DataProvider d = new DataProvider();

        private void LoadData()
        {
            try
            {
                string strSelect = "select p.ProductId,p.ProductName,s.CompanyName,p.UnitsInStock from Products p,Suppliers s where p.SupplierID = s.SupplierID";
                DataTable dt = d.executeQuery(strSelect);
                dataGridView1.DataSource = dt;
               string strSelect2 = "select TypeName from WordType";

                //cách 2

                //using (IDataReader dr = d.executeQuery2(strSelect2))
                //{
                //    cboType.Items.Clear();
                //    while (dr.Read())
                //    {

                //        string code = dr.GetString(0);
                //        if (!cboType.Items.Contains(code))
                //            cboType.Items.Add(code);
                //    }
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("Load error:" + ex.Message);
            }
        }
        //MySaleDBContext context = new MySaleDBContext();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //var data = context.Products
            //     .Select(p => new
            //     {
            //         ProductId = p.ProductId,
            //         ProductName = p.ProductName.ToUpper(),

            //         UnitsInStock = p.UnitsInStock,
            //         CategoryName = p.Category.CategoryName,
            //         Image = p.Image
            //     }).Where(p => p.ProductName.Contains(textBox1.Text))
            //     .ToList();
            //dataGridView1.DataSource = data;

            string strSearch = "select p.ProductId,p.ProductName,s.CompanyName,p.UnitsInStock from Products p,Suppliers s where p.SupplierID = s.SupplierID and p.ProductName like '%" + textBox1.Text + "%'";
            
            var data = d.executeQuery(strSearch);
            dataGridView1.DataSource= data;
            //string strSearch = "insert into Customers " +
            //        "(CustomerName,Birthdate,Gender,Address) " +
            //        "values(N'" + txtName.Text + "'," +
            //        "'" + txtDOB.Text + "'," +
            //        "'" + gender + "'," +
            //        "N'" + txtAddress.Text + "')";
            //string s_name = textBox1.Text;
            //string strSelect = "select p.ProductId,p.ProductName,s.CompanyName,p.UnitsInStock from Products p,Suppliers s where (ProductId = '"+s_name+"')";

        }
    }
}
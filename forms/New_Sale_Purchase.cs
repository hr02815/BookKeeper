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

namespace project
{
    public partial class New_Sale_Purchase : Form
    {
        private const string con = "Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True";


        customer choice = new customer();
        public New_Sale_Purchase(customer data)
        {
            InitializeComponent();
            choice = data; 
        }

        private void New_Sale_Purchase_Load(object sender, EventArgs e)
        {
            if (choice.id == 1)
            {
                label1.Text = "SaleID";
                SqlConnection conn = new SqlConnection(con);
                //SqlCommand getIdentityvalue = new SqlCommand(string.Format("IDENT_CURRENT('sale')"), conn);
                //MessageBox.Show(label1.Text);
                //using (SqlConnection conn1 = new SqlConnection(con))
                //{
                    //conn1.Open();
                    SqlCommand cmd = new SqlCommand(
                        string.Format("IDENT_CURRENT('sale')"), conn);
                    object result5 = (Int32)cmd.ExecuteScalar();
                    int name1 = Convert.ToInt32(result5);
                    MessageBox.Show(name1.ToString());
                    textBox2.Text = name1.ToString();
                    

                   // conn1.Close();
               // }
            }
            
        }
    }

}

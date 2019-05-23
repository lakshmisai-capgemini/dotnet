using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MiniProjectNew
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        string strcon = ConfigurationManager.ConnectionStrings["sqlprac"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        public static string sendcustid;
        public AddCustomer()
        {
            InitializeComponent();
            int id=sq.Customers.Max(x => x.CustId);
            id++;
            txtCustid.Text = id.ToString();
        }
        
        public bool ValidateCustomer( )
        {
            bool isValidate = true;
            if (txtName.Text == string.Empty)
            {
                isValidate = false;
            }
            if (txtAddress.Text == string.Empty)
            {
                isValidate = false;
            }
            if (txtCustid.Text == string.Empty)
            {
                isValidate = false;
            }
            if (txtHobbies.Text == string.Empty)
            {
                isValidate = false;
            }
            if (txtTelephone.Text == string.Empty)
            {
                isValidate = false;
            }
            if(btnFemale.IsChecked==false && btnMale.IsChecked == false)
            {
                isValidate = false;
            }
            return isValidate;
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con = new SqlConnection(strcon);
                cmd = new SqlCommand("prcInsertCust", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", Convert.ToInt32(txtCustid.Text));
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@Hobbies", txtHobbies.Text);
                cmd.Parameters.AddWithValue("@Dob", dpDob.Text);
                if (btnMale.IsChecked == true)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Male");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Gender", "Female");
                }
                if (btnSmoker.IsChecked == true)
                {
                    cmd.Parameters.AddWithValue("@Smoker", "Smoker");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Smoker", "NonSmoker");
                }
                con.Open();
                int st=0;
                if (ValidateCustomer())
                {
                    st = cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("All fields are Mandatory");
                }
                if (st > 0)
                {
                    MessageBox.Show("Added Successfully");
                    sendcustid = txtCustid.Text;
                    this.Close();
                    AddLogin al = new AddLogin();
                    al.Show();
                    

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}

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

namespace MiniProjectNew
{
    /// <summary>
    /// Interaction logic for AddLogin.xaml
    /// </summary>
    public partial class AddLogin : Window
    {
        public AddLogin()
        {
            InitializeComponent();
            txtCustId.Text = AddCustomer.sendcustid;
        }
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        public bool ValidateLogin()
        {
            bool valid = true;
            if (txtPass.Text == string.Empty)
            {
                valid = false;
            }
            if (txtUser.Text == string.Empty)
            {
                valid = false;
            }
            return valid;
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            Login lo = new Login();
            try
            {
                lo.CustomerId = Convert.ToInt32(txtCustId.Text);
                lo.LoginId = txtUser.Text;
                lo.Password = txtPass.Text;
                if (ValidateLogin())
                {
                    sq.Logins.Add(lo);
                    sq.SaveChanges();
                    this.Close();
                    AdminAccess ad = new AdminAccess();
                    ad.gridCus.DataContext = sq.Customers.ToList();
                    ad.Show();
                }
                else
                {
                    MessageBox.Show("All Fields Are Mandatory");
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

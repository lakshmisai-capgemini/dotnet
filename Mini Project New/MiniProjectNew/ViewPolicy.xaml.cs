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
    /// Interaction logic for ViewPolicy.xaml
    /// </summary>
    public partial class ViewPolicy : Window
    {
        public ViewPolicy()
        {
            InitializeComponent();
        }
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Endorsement end = new Endorsement();
            try
            {
                DateTime dt = Convert.ToDateTime(txtDob.Text);
                Customer customer = sq.Customers.Where(x => x.Dob == dt).Select(x => x).FirstOrDefault();
                end.CustId = customer.CustId;
                end.Policynumber = txtPolicyNumber.Text;
                InsuranceProduct product = sq.InsuranceProducts.Where(x => x.Products == txtProductName.Text).Select(x => x).FirstOrDefault();
                end.ProductId = product.ProductId;
                end.InsuredName = txtInsuredName.Text;
                end.InsuredAge = Convert.ToInt32(txtAge.Text);
                end.Dob = Convert.ToDateTime(txtDob.Text);
                end.Nominee = txtNominee.Text;
                end.Relation = txtRelation.Text;
                end.Address = txtAddress.Text;
                end.Telephone = txtTelephone.Text;
                end.PremiumPaymentFrequency = txtPaymentFrequency.Text;
                if (btnMale.IsChecked == true)
                {
                    end.Gender = "Male";
                }
                else
                {
                    end.Gender = "Female";
                }
                if (btnSmoker.IsChecked == true)
                {
                    end.Smoker = "Smoker";
                }
                else
                {
                    end.Smoker = "NonSmoker";
                }
                sq.Endorsements.Add(end);
                sq.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            MessageBox.Show("Request Sent");
        }
    }
}

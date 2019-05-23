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
    /// Interaction logic for ViewEndorsementChanges.xaml
    /// </summary>
    public partial class ViewEndorsementChanges : Window
    {
        public ViewEndorsementChanges()
        {
            InitializeComponent();
        }
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        sqlpracticeEntities2 sq1 = new sqlpracticeEntities2();
        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Policy p1 = sq.Policys.Single(x => x.PolicyNumber == txtPolicyNumber.Text);
                Policy p2 = sq1.Policys.Single(x => x.PolicyNumber == txtPolicyNumber.Text);
                p2.InsuredName = txtInsuredName.Text;
                p2.InsuredAge = Convert.ToInt32(txtAge.Text);
                p2.Nominee = txtNominee.Text;
                p2.Relation = txtRelation.Text;
                p2.PremiumPaymentFrequency = txtPaymentFrequency.Text;
                sq1.SaveChanges();

                Customer c1 = sq.Customers.Single(x => x.CustId == p1.Customerno);
                c1.Dob = Convert.ToDateTime(txtDob.Text);
                if (btnMale.IsChecked == true)
                {
                    c1.Gender = "Male";
                }
                else
                {
                    c1.Gender = "Female";
                }
                c1.Address = txtAddress.Text;
                c1.Telephone = txtTelephone.Text;
                if (btnSmoker.IsChecked == true)
                {
                    c1.Smoker = "Smoker";
                }
                else
                {
                    c1.Smoker = "NonSmoker";
                }

                MessageBox.Show("Records Accepted");
                sq.SaveChanges();
                Endorsement end = sq.Endorsements.Where(x => x.Policynumber == txtPolicyNumber.Text).OrderByDescending(x => x.TransactionId).First();
                end.EndorsementStatus = "Changes Accepted";
                sq.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Records Rejected");
            Endorsement end = sq.Endorsements.Where(x => x.Policynumber == txtPolicyNumber.Text).OrderByDescending(x => x.TransactionId).First();
            end.EndorsementStatus = "Changes Rejected";
            sq.SaveChanges();
        }
    }
}

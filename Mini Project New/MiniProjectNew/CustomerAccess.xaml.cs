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
    /// Interaction logic for CustomerAccess.xaml
    /// </summary>
    public partial class CustomerAccess : Window
    {
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        
        public CustomerAccess()
        {
            InitializeComponent();
            cmbSearch.Items.Add("Policy Number");
            cmbSearch.Items.Add("CustomerID");
            cmbSearch.Items.Add("Name and DOB");
            string id = MainWindow.sendtext;           
            var v1 = from e1 in sq.prcShowLogin() where e1.LoginId==id select e1;
            foreach(var p in v1)
            {
                Customer cus = sq.Customers.Single(x => x.CustId == p.CustomerId);
                lblName.Content = cus.Name;
            }
            var v2= from e1 in sq.Logins where e1.LoginId == id select e1;
            foreach (var v in v2)
            {
                            
                grid1.DataContext = sq.prcShowPolicy().Where(x=>x.Customerno==v.CustomerId).Select(x=>x).ToList();  
                
            }
           
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewPolicy vp = new ViewPolicy();
            try
            {
                object item = grid1.SelectedItem;
                vp.txtPolicyNumber.Text = (grid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                vp.txtInsuredName.Text = (grid1.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                vp.txtNominee.Text = (grid1.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                vp.txtRelation.Text = (grid1.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                vp.txtPaymentFrequency.Text = (grid1.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                vp.txtAge.Text = (grid1.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                int custid = Convert.ToInt32((grid1.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                var v5 = sq.prcShowCustomer().Where(x => x.CustId == custid).Select(x => x).FirstOrDefault();
                vp.txtDob.Text = v5.Dob.ToString();
                vp.txtAddress.Text = v5.Address;
                vp.txtTelephone.Text = v5.Telephone;

                string gen = v5.Gender;
                string smoke = v5.Smoker;
                if (gen.ToUpper() == "MALE")
                {
                    vp.btnMale.IsChecked = true;
                }
                else
                {
                    vp.btnFemale.IsChecked = true;
                }
                if (smoke.ToUpper() == "SMOKER")
                {
                    vp.btnSmoker.IsChecked = true;
                }
                else
                {
                    vp.btnNonSmoker.IsChecked = true;
                }

                int proid = Convert.ToInt32((grid1.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                var v6 = sq.prcShowInsuranceProduct().Where(x => x.ProductId == proid).Select(x => x).FirstOrDefault();
                vp.txtProductName.Text = v6.Products;
                string type = v6.ProductType;
                if (type.ToUpper() == "LIFE")
                {
                    vp.btnLife.IsChecked = true;
                }
                else
                {
                    vp.btnNonLife.IsChecked = true;
                }
                vp.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("Click an item in the grid and then proceed");
            }
            
        }

        private void BtnViewStatus_Click(object sender, RoutedEventArgs e)
        {
            ViewStatus vs = new ViewStatus();
            try
            {
                object item = grid1.SelectedItem;
                string policyno = (grid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                vs.grid1.DataContext = sq.Endorsements.Where(x => x.Policynumber == policyno).Select(x => x).ToList();
                vs.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Click an item in the grid and then proceed");
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = MainWindow.sendtext;

                if (cmbSearch.SelectedIndex == 2)
                {
                    DateTime dt = Convert.ToDateTime(dpDob.Text);
                    string nam = txtSearch.Text;
                    var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;

                    foreach (var v in v1)
                    {

                        var v2 = from e2 in sq.prcShowCustomer() where e2.CustId == v.CustomerId select e2;

                        foreach (var v3 in v2)
                        {
                            grid1.DataContext = sq.prcShowPolicy().Where(x => x.Customerno == v.CustomerId && v3.Name == nam && v3.Dob == dt).Select(x => x).ToList();
                        }


                    }


                }
                if (cmbSearch.SelectedIndex == 1)
                {
                    int num = Convert.ToInt32(txtSearch.Text);
                    var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;
                    foreach (var v in v1)
                    {

                        grid1.DataContext = sq.prcShowPolicy().Where(x => x.Customerno == v.CustomerId && x.Customerno == num).Select(x => x).ToList();


                    }
                }
                if (cmbSearch.SelectedIndex == 0)
                {
                    var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;
                    foreach (var v in v1)
                    {

                        grid1.DataContext = sq.prcShowPolicy().Where(x => x.Customerno == v.CustomerId && x.PolicyNumber == txtSearch.Text).Select(x => x).ToList();


                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Enter all details");
            }
        }

     
    }
}

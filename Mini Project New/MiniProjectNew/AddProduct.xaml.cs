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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        public AddProduct()
        {
            InitializeComponent();
            int id = sq.InsuranceProducts.Max(x => x.ProductId);
            id++;
            txtProdId.Text = id.ToString();
        }
       public bool ValidateProduct()
        {
            bool validate = true;
            if (txtName.Text == string.Empty)
            {
                validate = false;
            }
            if (btnLife.IsChecked == false && btnNonLife.IsChecked == false)
            {
                validate = false;
            }
            return validate;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsuranceProduct ip = new InsuranceProduct();
            try
            {
                ip.ProductId = Convert.ToInt32(txtProdId.Text);
                ip.Products = txtName.Text;
                if (btnLife.IsChecked == true)
                {
                    ip.ProductType = "Life";
                }
                else
                {
                    ip.ProductType = "NonLife";
                }
                if (ValidateProduct())
                {
                    sq.InsuranceProducts.Add(ip);
                    sq.SaveChanges();
                    this.Close();
                    AdminAccess ad = new AdminAccess();
                    ad.gridProducts.DataContext = sq.InsuranceProducts.ToList();
                    ad.Show(); 
                }
                else
                {
                    MessageBox.Show("All Fields are Mandatory");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
    /// Interaction logic for AdminAccess.xaml
    /// </summary>
    public partial class AdminAccess : Window
    {
       
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();
        public AdminAccess()
        {
            InitializeComponent();
            grid2.DataContext = sq.Endorsements.ToList();
            gridCus.DataContext = sq.prcShowCustomer().ToList();
            gridPolicy.DataContext = sq.prcShowPolicy().ToList();
            gridProducts.DataContext = sq.prcShowInsuranceProduct().ToList();
         
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewEndorsementChanges vec = new ViewEndorsementChanges();
            try
            {
                object item = grid2.SelectedItem;
                vec.txtPolicyNumber.Text = (grid2.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtInsuredName.Text = (grid2.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtAge.Text = (grid2.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtDob.Text = (grid2.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtNominee.Text = (grid2.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtRelation.Text = (grid2.SelectedCells[13].Column.GetCellContent(item) as TextBlock).Text;
                string gen = (grid2.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                if (gen.ToUpper() == "MALE")
                {
                    vec.btnMale.IsChecked = true;
                }
                else
                {
                    vec.btnFemale.IsChecked = true;
                }
                string smoker = (grid2.SelectedCells[14].Column.GetCellContent(item) as TextBlock).Text;
                if (smoker.ToUpper() == "SMOKER")
                {
                    vec.btnSmoker.IsChecked = true;
                }
                else
                {
                    vec.btnNonSmoker.IsChecked = true;
                }
                vec.txtAddress.Text = (grid2.SelectedCells[15].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtTelephone.Text = (grid2.SelectedCells[16].Column.GetCellContent(item) as TextBlock).Text;
                vec.txtPaymentFrequency.Text = (grid2.SelectedCells[17].Column.GetCellContent(item) as TextBlock).Text;
                vec.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("Click on the Endorsement grid and then proceed");
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer adc = new AddCustomer();           
            this.Close();
            adc.Show();
        }

        private void BtnAddProducts_Click(object sender, RoutedEventArgs e)
        {
            AddProduct ap = new AddProduct();
            
            this.Close();
            ap.Show();
        }

        private void BtnInsertPolicy_Click(object sender, RoutedEventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["sqlprac"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                object item = gridPolicy.SelectedItem;
                int policyNum = Convert.ToInt32((gridPolicy.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                int custNo = Convert.ToInt32((gridPolicy.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                int prodId = Convert.ToInt32((gridPolicy.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                string name = (gridPolicy.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                int age = Convert.ToInt32((gridPolicy.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);
                string nominee = (gridPolicy.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                string relation = (gridPolicy.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                string payment = (gridPolicy.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                
                SqlCommand cmd = new SqlCommand("prcInsertPolicy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@policynum", policyNum.ToString());
                cmd.Parameters.AddWithValue("@custno", custNo);
                cmd.Parameters.AddWithValue("@prodId", prodId);
                cmd.Parameters.AddWithValue("@insuName", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@nominee", nominee);
                cmd.Parameters.AddWithValue("@relation", relation);
                cmd.Parameters.AddWithValue("@payFreq", payment);
                con.Open();
                int sta = cmd.ExecuteNonQuery();
                if (sta > 0)
                {
                    MessageBox.Show("Added Successfully");
                }
                else
                {
                    MessageBox.Show("Not added");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("First write the details in the policy grid  then select that newly entered item and click on insert ") ;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

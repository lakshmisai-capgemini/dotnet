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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PMS.BusinessLayer;

namespace MiniProjectNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string sendtext ;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        sqlpracticeEntities2 sq = new sqlpracticeEntities2();

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            //Admin Login
            if ((txtUsername.Text.ToUpper() == "ADMIN") && (txtpass.Password == "admin"))
            {
                AdminAccess ad = new AdminAccess();
                ad.Show();
            }

            //customer login from data base
            else if (txtUsername.Text.ToUpper() != "ADMIN")
            {
                try
                {               
                var v1 = from e1 in sq.prcShowLogin() where e1.LoginId == (txtUsername.Text) select e1;
                if (v1 != null)
                {
                    foreach (var v in v1)
                    {
                        if (v.Password == txtpass.Password)
                        {
                            sendtext = txtUsername.Text;
                            CustomerAccess ca = new CustomerAccess();
                            ca.Show();

                        }

                    }

                }

            } 
                catch (Exception)
            {

                MessageBox.Show("Invalid credentials");
            }
        }
            

        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            txtpass.Password = "";
            txtUsername.Text = "";
        }
    }
}

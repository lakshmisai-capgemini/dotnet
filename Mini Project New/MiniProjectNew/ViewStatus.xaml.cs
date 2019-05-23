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
    /// Interaction logic for ViewStatus.xaml
    /// </summary>
    public partial class ViewStatus : Window
    {
        public ViewStatus()
        {
            InitializeComponent();
                     
        }

        private void BtnViewStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = grid1.SelectedItem;
                string st = (grid1.SelectedCells[18].Column.GetCellContent(item) as TextBlock).Text;
                if (st == "Changes Accepted")
                {
                    lblstatus.Content = "Accepted";
                }
                else if (st == "Changes Rejected")
                {
                    lblstatus.Content = "Rejected";
                }
                else
                {
                    lblstatus.Content = "Pending";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Click on grid and then proceed");
            }
        }
    }
}

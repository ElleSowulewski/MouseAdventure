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

namespace MouseAdventure.PresentationLayer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Win2 : Window
    {
        public Win2()
        {
            InitializeComponent();
            win.Content = "You turned back to bring the shiny gem to Charles and Alfred. \nThey were very relived to have thir sacred object back. \n" +
                          "As thanks they made you a feast from their stored food!";
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

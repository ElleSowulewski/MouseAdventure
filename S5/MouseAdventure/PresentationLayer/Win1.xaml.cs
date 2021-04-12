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
    public partial class Win1 : Window
    {
        public Win1()
        {
            InitializeComponent();
            win.Content = "You make it to the other side of the basin and to the plate of food. \nAt long last, delicious food!";
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

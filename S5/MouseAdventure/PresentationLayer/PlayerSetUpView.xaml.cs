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
using MouseAdventure.Models;

namespace MouseAdventure.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetUpView.xaml
    /// </summary>
    public partial class PlayerSetUpView : Window
    {
        private Player _player;

        public PlayerSetUpView(Player player)
        {
            _player = player;

            InitializeComponent();

        }

        /// <summary>
        /// event handler for the OK button
        /// </summary>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                _player.Name = name_box.Text;
                Visibility = Visibility.Hidden;
            }
            else
            {
                feedback_label.Content = errorMessage;
            }
        }

        /// <summary>
        /// validate user input and generate appropriate error messages
        /// </summary>
        /// <param name="errorMessage">user feedback</param>
        /// <returns>is user input valid</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (name_box.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = name_box.Text;
            }

            return errorMessage == "" ? true : false;
        }
    }
}

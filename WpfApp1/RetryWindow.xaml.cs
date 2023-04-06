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

namespace YetAnotherFlappyBird
{
    /// <summary>
    /// Interaction logic for RetryWindow.xaml
    /// </summary>
    public partial class RetryWindow : Window
    {
        public RetryWindow(ulong score)
        {
            InitializeComponent();

            ScoreLabel.Content = $"SCORE: {score}";
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new();
            gameWindow.Show();

            RetryButton.Click -= RetryButton_Click;

            Close();
        }
    }
}

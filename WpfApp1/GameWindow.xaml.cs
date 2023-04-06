using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private WorldManager _worldManager;
        private PlayerController _playerController;

        public GameWindow()
        {
            InitializeComponent();

            _playerController = new PlayerController(PlayerCharacter);

            // Start game
            _worldManager = new WorldManager(this, GameCanvas, _playerController);
            _worldManager.OnPlayerCollide += EndGame;
        }

        public void EndGame(object sender, OnPlayerCollideEventArgs e)
        {
            _worldManager.OnPlayerCollide -= EndGame;

            RetryWindow retryWindow = new RetryWindow(1);
            retryWindow.Show();

            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            _playerController.Jump();
        }
    }
}

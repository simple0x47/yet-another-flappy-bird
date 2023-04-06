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

        public GameWindow()
        {
            InitializeComponent();

            // Start game
            _worldManager = new WorldManager(this, GameCanvas);
            _worldManager.OnPlayerCollide += EndGame;
            _worldManager.SpawnPipeObject(250, 0.2);
        }

        public void EndGame(object sender, OnPlayerCollideEventArgs e)
        {
            _worldManager.OnPlayerCollide -= EndGame;

            RetryWindow retryWindow = new RetryWindow(1);
            retryWindow.Show();

            Close();
        }
    }
}

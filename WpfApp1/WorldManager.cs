using System.Collections.Generic;
using System.Windows.Controls;

namespace YetAnotherFlappyBird
{
    internal class WorldManager
    {
        private GameWindow _gameWindow;
        private Canvas _gameCanvas;

        private List<PipeObject> _pipeObjects;

        public WorldManager(GameWindow gameWindow, Canvas gameCanvas)
        {
            _gameWindow = gameWindow;
            _gameCanvas = gameCanvas;
            _pipeObjects = new List<PipeObject>();
        }

        public void SpawnPipeObject()
        {
            PipeObject pipeObject = new PipeObject();
            Canvas.SetLeft(pipeObject, 250);
            Canvas.SetTop(pipeObject, 0);

            _gameCanvas.Children.Add(pipeObject);
            _pipeObjects.Add(pipeObject);

            pipeObject.Width = 200;
            pipeObject.Height = _gameWindow.Height;
            pipeObject.DivisionOffset = 0.8;
            pipeObject.DivisionHeight = 100;
        }
    }
}

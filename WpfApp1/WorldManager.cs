using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace YetAnotherFlappyBird
{
    internal class WorldManager
    {
        private const ulong MAX_SPEED_AFTER_TICKS = 50000;
        private const double REMOVE_PIPE_OBJECTS_AFTER_LEFT_POSITION = -200;

        private GameWindow _gameWindow;
        private Canvas _gameCanvas;

        private List<PipeObject> _pipeObjects;
        private List<PipeObject> _pipesToBeRemoved;

        private ulong _tick = 0;
        private double _speed = 1;

        public WorldManager(GameWindow gameWindow, Canvas gameCanvas)
        {
            _gameWindow = gameWindow;
            _gameCanvas = gameCanvas;
            _pipeObjects = new List<PipeObject>();
            _pipesToBeRemoved = new List<PipeObject>();

            CompositionTarget.Rendering += Update;
        }

        public void SpawnPipeObject(double leftPosition, double divisionOffset)
        {
            PipeObject pipeObject = new PipeObject();
            Canvas.SetLeft(pipeObject, leftPosition);
            Canvas.SetTop(pipeObject, 0);

            _gameCanvas.Children.Add(pipeObject);
            _pipeObjects.Add(pipeObject);

            pipeObject.Width = 200;
            pipeObject.Height = _gameWindow.Height;
            pipeObject.DivisionOffset = divisionOffset;
            pipeObject.DivisionHeight = 100;
        }

        private void Tick()
        {
            _tick++;

            if (_tick == ulong.MaxValue)
            {
                _tick = 0;
            }
        }

        private void AdjustSpeed()
        {
            if (_speed >= 4.999999)
            {
                return;
            }

            _speed = 1.0 + ((_tick / MAX_SPEED_AFTER_TICKS) * 4);
        }

        private void DisplacePipeObjects()
        {
            foreach (var pipeObject in _pipeObjects)
            {
                double leftPosition = Canvas.GetLeft(pipeObject) - _speed;

                if (leftPosition < REMOVE_PIPE_OBJECTS_AFTER_LEFT_POSITION)
                {
                    _pipesToBeRemoved.Add(pipeObject);
                }

                Canvas.SetLeft(pipeObject, leftPosition);
            }

            foreach (var pipeObjectBeingRemoved in _pipesToBeRemoved)
            {
                _pipeObjects.Remove(pipeObjectBeingRemoved);
                _gameCanvas.Children.Remove(pipeObjectBeingRemoved);
            }

            _pipesToBeRemoved.Clear();
        }

        public void Update(object sender, EventArgs e) 
        {
            Tick();

            AdjustSpeed();

            DisplacePipeObjects();
        }
    }
}

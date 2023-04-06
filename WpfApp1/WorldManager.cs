using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace YetAnotherFlappyBird
{
    internal class WorldManager : IDisposable
    {
        private const ulong MAX_SPEED_AFTER_TICKS = 50000;
        private const double REMOVE_PIPE_OBJECTS_AFTER_LEFT_POSITION = -200;

        private GameWindow _gameWindow;
        private Canvas _gameCanvas;

        private List<PipeObject> _pipeObjects;
        private List<PipeObject> _pipesToBeRemoved;

        private ulong _tick = 0;
        private double _speed = 1;

        private CollisionDetector _collisionDetector;
        private double _playerRadius = 0;

        private ulong _score = 0;

        public delegate void OnPlayerCollideEventHandler(object sender, OnPlayerCollideEventArgs e);
        public event OnPlayerCollideEventHandler OnPlayerCollide;

        public WorldManager(GameWindow gameWindow, Canvas gameCanvas)
        {
            _gameWindow = gameWindow;
            _gameCanvas = gameCanvas;
            _pipeObjects = new List<PipeObject>();
            _pipesToBeRemoved = new List<PipeObject>();
            _collisionDetector = new CollisionDetector();
            _playerRadius = gameWindow.PlayerCharacter.Width / 2;

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

        private void DisplacePipeObjectsAndDetectCollision(Vector2D playerPosition)
        {
            foreach (var pipeObject in _pipeObjects)
            {
                double leftPosition = Canvas.GetLeft(pipeObject) - _speed;

                if (leftPosition < REMOVE_PIPE_OBJECTS_AFTER_LEFT_POSITION)
                {
                    _pipesToBeRemoved.Add(pipeObject);
                }

                Canvas.SetLeft(pipeObject, leftPosition);

                if (_collisionDetector.CollidesWithPipeObject(playerPosition, pipeObject, _playerRadius))
                {
                    OnPlayerCollidedWithPipeObject();
                    return;
                }
            }

            foreach (var pipeObjectBeingRemoved in _pipesToBeRemoved)
            {
                _pipeObjects.Remove(pipeObjectBeingRemoved);
                _gameCanvas.Children.Remove(pipeObjectBeingRemoved);
                _score++;
            }

            _pipesToBeRemoved.Clear();
        }

        public void Update(object sender, EventArgs e) 
        {
            Tick();

            AdjustSpeed();

            Vector2D playerPosition = GetPlayerPosition();

            DisplacePipeObjectsAndDetectCollision(playerPosition);
        }

        public Vector2D GetPlayerPosition()
        {
            double top = Canvas.GetTop(_gameWindow.PlayerCharacter) + _gameWindow.PlayerCharacter.Height / 2;
            double left = Canvas.GetLeft(_gameWindow.PlayerCharacter) + _gameWindow.PlayerCharacter.Width / 2;

            Vector2D playerPosition = new(left, top);

            return playerPosition;
        }

        private void OnPlayerCollidedWithPipeObject()
        {
            OnPlayerCollide?.Invoke(this, new OnPlayerCollideEventArgs(_score));
            CompositionTarget.Rendering -= Update;
        }

        public void Dispose()
        {
            _gameCanvas.Children.Clear();
            _pipeObjects.Clear();
            _pipesToBeRemoved.Clear();
        }
    }
}

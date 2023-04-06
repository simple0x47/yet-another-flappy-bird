using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace YetAnotherFlappyBird
{
    internal class PlayerController
    {
        private const double GRAVITY = 2;
        private const double JUMP = -15;
        private const double MAX_VELOCITY = 2;

        private Ellipse _playerCharacter;
        private double _velocity = 0;

        public PlayerController(Ellipse playerCharacter) 
        {
            _playerCharacter = playerCharacter;
        }

        public void Update()
        {
            _velocity = Math.Min(_velocity + GRAVITY, MAX_VELOCITY);

            Canvas.SetTop(_playerCharacter, Canvas.GetTop(_playerCharacter) + _velocity);
        }

        public void Jump()
        {
            _velocity = JUMP;
        }
    }
}

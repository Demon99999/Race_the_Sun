namespace RaseTheSun.Scripts.Gameplay.Spaceship.SpeedDecorator
{
    public class SpaceshipSpeed : ISpeedProvider
    {
        private readonly float _defaultSpeed;

        public SpaceshipSpeed(float defaultSpeed) =>
            _defaultSpeed = defaultSpeed;

        public float GetSpeed() =>
            _defaultSpeed;
    }
}

using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "SpaceshipConfig", menuName = "Game/Spaceship Config", order = 1)]
    public class SpaceshipConfigSO : ScriptableObject
    {
        public float Speed => _speed;
        public float Drag => _drag;
        public float RotationSpeed => _rotationSpeed;
        
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _drag;
        [SerializeField]
        private float _rotationSpeed;
    }
}
using System;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidConfig", menuName = "Game/Asteroid Config", order = 1)]
    public class AsteroidConfigSO : ScriptableObject
    {
        [Serializable]
        public class AsteroidExplosionData
        {
            public AsteroidConfigSO Piece;
            public int MinCount;
            public int MaxCount;
        }
        
        public float Speed => _speed;
        public float Scale => _scale;
        public AsteroidExplosionData ExplosionData => _explosionData;

        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _scale;
        [SerializeField]
        private AsteroidExplosionData _explosionData;
    }
}
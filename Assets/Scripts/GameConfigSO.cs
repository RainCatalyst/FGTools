using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Config", order = 1)]
    public class GameConfigSO : ScriptableObject
    {
        public AsteroidConfigSO BaseAsteroidConfig => _baseAsteroidConfig;
        public SpaceshipConfigSO SpaceshipConfig => _spaceshipConfig;
        public Asteroid AsteroidPrefab => _asteroidPrefab;
        public float BulletSpeed => _bulletSpeed;
        public float AsteroidSpawnDelay => _asteroidSpawnDelay;

        [SerializeField]
        private AsteroidConfigSO _baseAsteroidConfig;
        [SerializeField]
        private SpaceshipConfigSO _spaceshipConfig;
        [SerializeField]
        private Asteroid _asteroidPrefab;
        [SerializeField]
        private float _bulletSpeed;
        [SerializeField]
        private float _asteroidSpawnDelay;
    }
}
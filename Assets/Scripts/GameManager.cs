using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameConfigSO Config => _config;
        
        public void SpawnAsteroid(AsteroidConfigSO config, Vector2 pos)
        {
            var instance = Instantiate(_config.AsteroidPrefab, pos, Quaternion.Euler(0, 0, Random.Range(0, 360)), _bounds.transform);
            instance.Setup(config);
        }

        private void Start()
        {
            SpawnAsteroid(_config.BaseAsteroidConfig, new Vector2(3f, 0));
            SpawnAsteroid(_config.BaseAsteroidConfig, new Vector2(-3f, 0));
            SpawnAsteroid(_config.BaseAsteroidConfig, new Vector2(4f, 0));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _config.AsteroidSpawnDelay)
            {
                _spawnTimer = 0;
                SpawnAsteroid(_config.BaseAsteroidConfig, _bounds.GetRandomEdgePosition());
            }
        }

        private float _spawnTimer;

        [SerializeField]
        private GameBounds _bounds;
        [SerializeField]
        private GameConfigSO _config;
    }
}
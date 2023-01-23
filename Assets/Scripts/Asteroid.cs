using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Health), typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        public void Setup(AsteroidConfigSO config)
        {
            _config = config;
            transform.localScale = Vector3.one * config.Scale;
            
            float angle = Random.Range(0, Mathf.PI * 2f);
            _rb.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _config.Speed;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Explode()
        {
            // Spawn extra meteors if needed
            if (_config.ExplosionData.Piece != null)
            {
                for (int i = 0; i < Random.Range(_config.ExplosionData.MinCount, _config.ExplosionData.MaxCount + 1); i++)
                {
                    GameManager.Instance.SpawnAsteroid(_config.ExplosionData.Piece, transform.position);
                }
            }
            Destroy(gameObject);
        }

        private Rigidbody2D _rb;
        private AsteroidConfigSO _config;
    }
}
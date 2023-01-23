using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Health), typeof(Rigidbody2D))]
    public class Spaceship : MonoBehaviour
    {
        public void Explode()
        {
            print("Game over!");
            Destroy(gameObject);
        }
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _config = GameManager.Instance.Config.SpaceshipConfig;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            float turnAxis = Input.GetAxisRaw("Horizontal");
            _angle -= turnAxis * _config.RotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, _angle);
            
            float moveAxis = Mathf.Max(0f, Input.GetAxisRaw("Vertical"));

            Vector2 forward = transform.up;

            _velocity = Vector2.Lerp(_velocity, Vector2.zero, _config.Drag * Time.deltaTime);
            _velocity += moveAxis * _config.Speed * Time.deltaTime * forward;

            _rb.velocity = _velocity;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent<Asteroid>(out var asteroid))
            {
                Explode();
            }
        }
        
        private void Shoot()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }

        [SerializeField]
        private Bullet _bulletPrefab;

        private SpaceshipConfigSO _config;
        private Vector2 _velocity;
        private float _angle;
        private Rigidbody2D _rb;
    }
}
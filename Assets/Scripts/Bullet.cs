using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * GameManager.Instance.Config.BulletSpeed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent<Asteroid>(out var asteroid))
            {
                asteroid.Explode();
                Destroy(gameObject);
            }
        }

        private Rigidbody2D _rb;
    }
}
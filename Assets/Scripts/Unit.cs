using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Health), typeof(Rigidbody2D))]
    public abstract class Unit : MonoBehaviour
    {
        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
            _rb = GetComponent<Rigidbody2D>();

            _health.Died += OnDied;
        }

        protected virtual void OnDied()
        {
            Destroy(gameObject);
        }

        protected Rigidbody2D _rb;
        protected Health _health;
    }
}
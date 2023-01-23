using System;
using UnityEngine;

namespace Asteroids
{
    public class Health : MonoBehaviour
    {
        public event Action Died;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                if (_currentHealth <= 0)
                    Died?.Invoke();
            }
        }

        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                CurrentHealth = _maxHealth;
            }
        }

        private int _currentHealth;
        private int _maxHealth;
    }
}
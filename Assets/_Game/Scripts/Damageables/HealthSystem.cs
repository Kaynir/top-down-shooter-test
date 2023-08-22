using System;
using UnityEngine;

namespace Kaynir.TDSTest.Damageables
{
    public class HealthSystem : MonoBehaviour, IDamageable, IKillable
    {
        public const int MIN_VALUE = 0;

        public event Action<int> ValueChanged;
        public event Action ValueDepleted;

        [SerializeField] private int maxValue = 100;

        public int Value { get; private set; }
        public int MaxValue => maxValue;

        public void SetValue(int value)
        {
            Value = Mathf.Clamp(value, MIN_VALUE, MaxValue);
            ValueChanged?.Invoke(Value);

            if (Value > MIN_VALUE) return;
            
            ValueDepleted?.Invoke();
        }

        public void ResetValue()
        {
            SetValue(maxValue);
        }

        public void TakeDamage(int damageAmount)
        {
            SetValue(Value - damageAmount);
        }

        public void Die()
        {
            TakeDamage(MaxValue);
        }
    }
}
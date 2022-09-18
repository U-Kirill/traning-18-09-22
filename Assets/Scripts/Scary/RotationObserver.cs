using System;
using Infastucture;
using UnityEngine;

namespace Scary
{
    public class RotationObserver : MonoBehaviour
    {
        [SerializeField] private float _thresholdRotation = 120f;
        
        private float _startRotation;

        public event Action<RotationObserver> Rotated;
        
        private float CurrentRotation => transform.eulerAngles.y;

        private void Update()
        {
            float deltaRotation = Mathf.DeltaAngle(_startRotation, CurrentRotation);

            if (deltaRotation > _thresholdRotation)
            {
                Kill();
            }
        }

        public void Observe()
        {
            _startRotation = CurrentRotation;
        }

        private void Kill()
        {
            enabled = false;
            Rotated?.Invoke(this);
        }
    }
}
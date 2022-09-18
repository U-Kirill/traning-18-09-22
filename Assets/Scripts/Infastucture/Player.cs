using System;
using UnityEngine;

namespace Infastucture
{
    public class Player : MonoBehaviour, IPlayerMove
    {
        [SerializeField] private SFPSC_PlayerMovement _playerMovement;
        [SerializeField] private SFPSC_FPSCamera _camera;
        [SerializeField] private Rigidbody _rigidbody;
        
        public event Action Moved;
        public Vector3 Position => transform.position;

        private void Update()
        {
            // if(_rigidbody.velocity.magnitude > Mathf.Epsilon)
                Moved?.Invoke();
        }

        public void Freeze()
        {
            _playerMovement.DisableMovement();
            _camera.DisableControll();
        }

        public void Kill()
        {
            Freeze();
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.AddTorque(10, 5, 2);
        }
    }
}
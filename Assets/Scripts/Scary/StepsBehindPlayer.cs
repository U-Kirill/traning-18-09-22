using System.Collections;
using Infastucture;
using UnityEngine;

namespace Scary
{
    public class StepsBehindPlayer : MonoBehaviour
    {
        [SerializeField] private float _startDistance = 20;
        [SerializeField] private int _endDistance = 0;
        [SerializeField] private AudioSource _audioSource;
        
        private Player _player;
        private float _time;
        
        public void Follow(Player player, float time)
        {
            _time = time;
            _player = player;
            _audioSource.maxDistance = _startDistance;

            StartCoroutine(MoveToPlayer());
        }

        private IEnumerator MoveToPlayer()
        {
            float startTime = Time.time;
            
            while (Time.time - startTime < _time)
            {
                _endDistance = 0;
                float effectProgress = Mathf.InverseLerp(_time, _endDistance, Time.time - startTime);
                float distanceToPlayer = effectProgress * _startDistance;
                transform.position = _player.transform.position - _player.transform.forward * distanceToPlayer;
                yield return null;
            }
            
            Destroy(gameObject);
        }
    }
}
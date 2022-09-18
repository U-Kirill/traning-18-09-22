using System;
using Infastucture;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scary
{
    public class ScarySystem : MonoBehaviour, IScarySystem
    {
        [SerializeField] private Player _player;
        [SerializeField] private RedEyes _redEye;
        [SerializeField] private StepsBehindPlayer _stepsBehindPlayer;
        [SerializeField] private Screamer _screamer;
        [SerializeField] private float _stepBehindDuration = 20f;
        [SerializeField] private float _redEyeDuration = 20f;

        public void ShowRedEye()
        {
            Vector3 position = _player.transform.position;
            position.y = 0;
            
            RedEyes redEyes = Instantiate(_redEye, position, _player.transform.rotation);
            redEyes.Show(_player.transform, _redEyeDuration);
        }

        public void ScaryWalkAndScreamer()
        {
            StepsBehindPlayer stepsBehindPlayer = Instantiate(_stepsBehindPlayer);
            stepsBehindPlayer.Follow(_player, _stepBehindDuration);

            RotationObserver killByRotate = _player.gameObject.AddComponent<RotationObserver>();
            killByRotate.Rotated += OnPlayerRotated;
            killByRotate.Observe();
            Destroy(killByRotate, _stepBehindDuration);
        }

        void OnPlayerRotated(RotationObserver rotationObserver)
        {
            _player.Kill();
            _screamer.Show();
        }
    }
}
using System;
using Infastucture;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scary
{
    public interface IScarySystem
    {
        void ShowRedEye();
        void ScaryWalkAndScreamer();
    }

    public class ScarySystem : MonoBehaviour, IScarySystem
    {
        [SerializeField] private Player _player;
        [SerializeField] private RedEyes _redEye;
        [SerializeField] private StepsBehindPlayer _stepsBehindPlayer;
        
        public void ShowRedEye()
        {
            RedEyes redEyes = Instantiate(_redEye, _player.transform.position, _player.transform.rotation);
            redEyes.Show(_player.transform);
        }

        public void ScaryWalkAndScreamer()
        {
            StepsBehindPlayer stepsBehindPlayer = Instantiate(_stepsBehindPlayer);
            stepsBehindPlayer.Follow(_player, 60f);

            RotationObserver killByRotate = _player.gameObject.AddComponent<RotationObserver>();
            killByRotate.Rotated += OnPlayerRotated;
            killByRotate.Observe();
            Destroy(killByRotate, 60);
        }

        void OnPlayerRotated(RotationObserver rotationObserver)
        {
            _player.Kill();
        }
    }
}
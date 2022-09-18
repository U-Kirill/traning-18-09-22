using System;
using Infastucture;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scary
{
    public class ScarySystem : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private RedEyes _redEye;
        [SerializeField] private StepsBehindPlayer _stepsBehindPlayer;

        private void Start()
        {
            ShowRedEye();
            ShowScaryWalkAndScreemer();
        }

        private void ShowScaryWalkAndScreemer()
        {
            StepsBehindPlayer stepsBehindPlayer = Instantiate(_stepsBehindPlayer);
            stepsBehindPlayer.Follow(_player, 20f);

            KillByRotate killByRotate = _player.gameObject.AddComponent<KillByRotate>();
            
            Destroy(killByRotate, 20);
        }

        public void ShowRedEye()
        {
            RedEyes redEyes = Instantiate(_redEye, _player.transform.position, _player.transform.rotation);
            redEyes.Show(_player.transform);
        }
    }

    public class KillByRotate : MonoBehaviour
    {
    }
}
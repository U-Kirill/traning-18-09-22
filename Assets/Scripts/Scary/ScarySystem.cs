using System;
using Infastucture;
using UnityEngine;

namespace Scary
{
    public class ScarySystem : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private RedEyes _redEye;

        private void Start()
        {
            ShowRedEye();
        }

        public void ShowRedEye()
        {
            RedEyes redEyes = Instantiate(_redEye, _player.transform.position, _player.transform.rotation);
            redEyes.Show(_player.transform);
        }
    }
}
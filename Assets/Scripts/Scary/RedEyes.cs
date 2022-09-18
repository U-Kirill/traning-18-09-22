using System.Collections;
using System.Collections.Generic;
using Infastucture;
using UnityEngine;

namespace Scary
{
    public class RedEyes : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _moveCurve;
        [SerializeField] private List<SpriteRenderer> _sprites;

        private Player _player;
        private float _effectStartTime;
        private bool _isShowing;
        private float _startEulerRotation;
        private float _duration = 5f;

        private void Update()
        {
            if(!_isShowing)
                return;
            
            float effectProgress = GetEffectProgress();
            RefreshRotation(effectProgress);
            
            if(effectProgress >= 1)
                Hide();
        }

        private float GetEffectProgress()
        {
            float passedTime = Time.time - _effectStartTime;
            float effectProgress = passedTime / _duration;
            return effectProgress;
        }
        
        public void Show(Transform player, float duration)
        {
            SetRotation(player.eulerAngles.y);

            _duration = duration;
            _effectStartTime = Time.time;
            _isShowing = true;
            _startEulerRotation = transform.eulerAngles.y;
        }

        private void RefreshRotation(float effectProgress)
        {
            float additionalRotation = _moveCurve.Evaluate(effectProgress);
            SetRotation(_startEulerRotation + additionalRotation);
        }

        private void SetRotation(float rotation) => 
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);

        private void Hide() => StartCoroutine(Hiding());

        private IEnumerator Hiding()
        {
            float opacity = 1;

            while (opacity > 0)
            {
                Color color = Color.white;
                color.a = opacity;
                
                _sprites.ForEach(x => x.color = color);
                opacity -= Time.deltaTime * 4f;
                yield return null;
            }
            
            Destroy(gameObject);
        }
    }
}
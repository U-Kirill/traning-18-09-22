using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Screamer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _time;

    public void Show()
    {
        gameObject.SetActive(true);
        _image.DOFade(1, _time);
    }
}

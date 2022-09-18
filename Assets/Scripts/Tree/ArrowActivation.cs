using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArrowActivation : MonoBehaviour
{
    [SerializeField] private Button _buttonArrowUp;
    [SerializeField] private Button _buttonArrowDown;
    [SerializeField] private Button _buttonArrowLeft;
    [SerializeField] private Button _buttonArrowRight;

    [SerializeField] private Arrow _arrowUp;
    [SerializeField] private Arrow _arrowDown;
    [SerializeField] private Arrow _arrowLeft;
    [SerializeField] private Arrow _arrowRight;

    public event UnityAction Selected;

    private void Start()
    {
        _buttonArrowUp.onClick.AddListener(SelectUp);
        _buttonArrowDown.onClick.AddListener(SelectDown);
        _buttonArrowLeft.onClick.AddListener(SelectLeft);
        _buttonArrowRight.onClick.AddListener(SelectRight);
    }

    private void SelectUp()
    {
        _arrowUp.gameObject.SetActive(true);
        Selected?.Invoke();
    }

    private void SelectDown()
    {
        _arrowDown.gameObject.SetActive(true);
        Selected?.Invoke();
    }
    
    private void SelectLeft()
    {
        _arrowLeft.gameObject.SetActive(true);
        Selected?.Invoke();
    }
    
    private void SelectRight()
    {
        _arrowRight.gameObject.SetActive(true);
        Selected?.Invoke();
    }
}

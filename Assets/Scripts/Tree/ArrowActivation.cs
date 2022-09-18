using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArrowActivation : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Button _buttonArrowUp;
    [SerializeField] private Button _buttonArrowDown;
    [SerializeField] private Button _buttonArrowLeft;
    [SerializeField] private Button _buttonArrowRight;

    private TreeZone[] _treeZones;
    private Tree _tree;

    public event UnityAction Selected;

    private void Start()
    {
        _buttonArrowUp.onClick.AddListener(SelectUp);
        _buttonArrowDown.onClick.AddListener(SelectDown);
        _buttonArrowLeft.onClick.AddListener(SelectLeft);
        _buttonArrowRight.onClick.AddListener(SelectRight);
    }

    private void OnEnable()
    {
        _treeZones = _container.GetComponentsInChildren<TreeZone>();

        foreach (var treeZone in _treeZones)
        {
            treeZone.Touched += OnTouched;
        }
    }

    private void OnDisable()
    {
        _treeZones = _container.GetComponentsInChildren<TreeZone>();

        foreach (var treeZone in _treeZones)
        {
            treeZone.Touched += OnTouched;
        }
    }

    private void OnTouched(Tree tree)
    {
        _tree = tree;
    }
    
    private void SelectUp()
    {
        _tree.ShowArrowUp();
        Selected?.Invoke();
    }

    private void SelectDown()
    {
        _tree.ShowArrowDown();
        Selected?.Invoke();
    }
    
    private void SelectLeft()
    {
        _tree.ShowArrowLeft();
        Selected?.Invoke();
    }
    
    private void SelectRight()
    {
        _tree.ShowArrowRight();
        Selected?.Invoke();
    }
}

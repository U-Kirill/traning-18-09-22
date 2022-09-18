using UnityEngine;

public class SelectionBar : MonoBehaviour
{
    [SerializeField] private ArrowActivation _arrowActivation;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Transform _container;
    
    private TreeZone[] _treeZones;
    private bool _isInZone;

    private void Update()
    {
        if (_isInZone == false)
            return;

        if (Input.GetKeyDown(KeyCode.E))
            _panel.SetActive(true);
    }

    private void OnEnable()
    {
        _treeZones = _container.GetComponentsInChildren<TreeZone>();

        foreach (var treeZone in _treeZones)
        {
            treeZone.Touched += OnTouched;
            treeZone.Goned += OnGoned;
        }

        _arrowActivation.Selected += OnSelected;
    }

    private void OnDisable()
    {
        foreach (var treeZone in _treeZones)
        {
            treeZone.Touched -= OnTouched;
            treeZone.Goned -= OnGoned;
        }

        _arrowActivation.Selected -= OnSelected;
    }

    private void OnTouched(Tree tree)
    {
        _isInZone = true;
    }

    private void OnGoned()
    {
        _isInZone = false;
        _panel.SetActive(false);
    }
    
    private void OnSelected()
    {
        _panel.SetActive(false);
    }
}

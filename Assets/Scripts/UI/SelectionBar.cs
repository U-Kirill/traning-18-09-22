using UnityEngine;

public class SelectionBar : MonoBehaviour
{
    [SerializeField] private ArrowActivation _arrowActivation;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TreeZone _treeZone;

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
        _treeZone.Touched += OnTouched;
        _treeZone.Goned += OnGoned;
        _arrowActivation.Selected += OnSelected;
    }

    private void OnDisable()
    {
        _treeZone.Touched -= OnTouched;
        _treeZone.Goned -= OnGoned;
        _arrowActivation.Selected -= OnSelected;
    }

    private void OnTouched()
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

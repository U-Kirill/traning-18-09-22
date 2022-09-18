using UnityEngine;
using UnityEngine.UI;

public class HintDrawArrow : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Text _text;

    private TreeZone[] _treeZones;

    private void OnEnable()
    {
        _treeZones = _container.GetComponentsInChildren<TreeZone>();

        foreach (var treeZone in _treeZones)
        {
            treeZone.Touched += OnTouched;
            treeZone.Goned += OnGoned;
        }
    }

    private void OnDisable()
    {
        foreach (var treeZone in _treeZones)
        {
            treeZone.Touched -= OnTouched;
            treeZone.Goned -= OnGoned;
        }
    }

    private void OnTouched(Tree tree)
    {
        _text.gameObject.SetActive(true);
    }

    private void OnGoned()
    {
        _text.gameObject.SetActive(false);
    }
}

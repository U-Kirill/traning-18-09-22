using UnityEngine;
using UnityEngine.UI;

public class HintDrawArrow : MonoBehaviour
{
    [SerializeField] private TreeZone _treeZone;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _treeZone.Touched += OnTouched;
        _treeZone.Goned += OnGoned;
    }

    private void OnDisable()
    {
        _treeZone.Touched -= OnTouched;
        _treeZone.Goned -= OnGoned;
    }

    private void OnTouched()
    {
        _text.gameObject.SetActive(true);
    }

    private void OnGoned()
    {
        _text.gameObject.SetActive(false);
    }
}

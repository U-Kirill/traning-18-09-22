using Infastucture;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Tree))]
public class TreeZone : MonoBehaviour
{
    private Tree _tree;

    public event UnityAction<Tree> Touched;
    public event UnityAction Goned;

    private void Start()
    {
        _tree = GetComponent<Tree>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Touched?.Invoke(_tree);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Goned?.Invoke();
        }
    }
}

using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private Arrow _up;
    [SerializeField] private Arrow _down;
    [SerializeField] private Arrow _left;
    [SerializeField] private Arrow _right;

    public void ShowArrowUp()
    {
        _up.gameObject.SetActive(true);
    }
    
    public void ShowArrowDown()
    {
        _down.gameObject.SetActive(true);
    }
    
    public void ShowArrowLeft()
    {
        _left.gameObject.SetActive(true);
    }
    
    public void ShowArrowRight()
    {
        _right.gameObject.SetActive(true);
    }
}

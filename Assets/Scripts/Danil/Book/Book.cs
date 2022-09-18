using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private GameObject _book;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            _book.SetActive(!_book.activeSelf);
    }
}

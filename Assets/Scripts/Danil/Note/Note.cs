using System;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    public string NoteText { get; private set; }
    
    public bool _isInit = false;

    public void Init(string text)
    {
        if (_isInit)
            throw new Exception();
        _isInit = true;
        NoteText = text;
        DisplayText(NoteText);
    }

    public void Hide() => gameObject.SetActive(false);

    private void DisplayText(string text) => _text.text = text;
}

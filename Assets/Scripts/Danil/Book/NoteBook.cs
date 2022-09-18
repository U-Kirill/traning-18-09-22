using TMPro;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void DisplayText(Note note) => _text.text = note.NoteText;
}

using UnityEngine;

public class DisplayNoteSpawner : MonoBehaviour
{
    [SerializeField] private NoteBook _noteBook;

    public void Spawn(Note note)
    {
        var display = Instantiate(_noteBook, Vector3.zero, Quaternion.identity, transform);
        display.DisplayText(note);
    }
}

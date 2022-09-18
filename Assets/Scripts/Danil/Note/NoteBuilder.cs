using UnityEngine;

namespace Danil
{
    public class NoteBuilder : MonoBehaviour
    {
        [SerializeField] private Note _note;
        [SerializeField] private NoteSystem _noteSystem;
        [SerializeField] private string _text = "Ебать ты лох";

        public Note Create(NotePosition notePosition)
        {
            var note = Instantiate(_note, Vector3.zero, Quaternion.identity, notePosition.transform);
            notePosition.SetPosition(note);
            _noteSystem.AddNote(note);
            note.Init(_text);
            return note;
        }
    }
}

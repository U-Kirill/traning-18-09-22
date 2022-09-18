using UnityEngine;

namespace Danil
{
    public class NoteBuilder : MonoBehaviour
    {
        [SerializeField] private Note _note;
        [SerializeField] private NoteSystem _noteSystem;

        public Note Create(NotePosition notePosition)
        {
            var note = Instantiate(_note, Vector3.zero, Quaternion.identity, notePosition.transform);
            notePosition.SetPosition(note);
            _noteSystem.AddNote(note);
            return note;
        }
    }
}

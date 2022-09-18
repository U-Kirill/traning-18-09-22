using UnityEngine;

namespace Danil
{
    public class NotePosition : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;

        private void Awake() => NotePositionObserver.AddNotePosition(this);

        public void SetPosition(Note note)
        {
            note.transform.position = transform.position + _offset;
        }
    }
}

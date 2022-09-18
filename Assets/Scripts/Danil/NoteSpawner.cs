using System.Linq;
using UnityEngine;

namespace Danil
{
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private NoteBuilder _note;
        [SerializeField] private int _count;

        private void Start()
        {
            var positions = NotePositionObserver.TakeRandomNonRecurringPosition(_count).ToList();

            foreach (var notePosition in positions)
                _note.Create(notePosition);
        }
    }
}

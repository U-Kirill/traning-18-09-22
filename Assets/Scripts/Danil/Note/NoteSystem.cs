using System;
using System.Collections.Generic;
using UnityEngine;

namespace Danil
{
    public class NoteSystem : MonoBehaviour, IMessageSystem
    {
        [SerializeField] private DisplayNoteSpawner _displayNoteSpawner;
        [SerializeField] private float _collectionDistance = 1;
        private readonly List<Note> _notes = new List<Note>();

        public void AddNote(Note note)
        {
            if (_notes.Contains(note))
                throw new ArgumentException();
            _notes.Add(note);
        }

        public event Action AllCollected;

        public void OnPlayerMoved(Vector3 position)
        {
            foreach (var note in _notes)
            {
                if (Vector3.Distance(note.transform.position, position) < _collectionDistance)
                {
                    note.Hide();
                    _notes.Remove(note);
                    _displayNoteSpawner.Spawn(note);
                    break;
                }
            }

            if (_notes.Count == 0)
                AllCollected?.Invoke();
        }
    }
}

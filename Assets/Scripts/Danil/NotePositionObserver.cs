using System;
using System.Collections.Generic;
using Extensions;

namespace Danil
{
    public static class NotePositionObserver
    {
        private static List<NotePosition> _positions = new List<NotePosition>();

        public static void AddNotePosition(NotePosition notePosition)
        {
            if (_positions.Contains(notePosition))
                throw new ArgumentException(nameof(notePosition) + "present in the list");

            _positions.Add(notePosition);
        }

        public static IEnumerable<NotePosition> TakeRandomNonRecurringPosition(int count)
        {
            if (count < 0)
                throw new ArgumentException(nameof(count));

            if (count > _positions.Count)
                throw new ArgumentException(nameof(count) + " > " + nameof(_positions.Count));

            var random = new Random();

            for (int i = 0; i < count; i++)
                yield return _positions.Extraction(random.Next(0, _positions.Count));
        }
    }
}

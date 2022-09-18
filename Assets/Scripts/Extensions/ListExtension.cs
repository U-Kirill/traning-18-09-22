using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtension
    {
        public static T Extraction<T>(this List<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            return item;
        }
    }
}

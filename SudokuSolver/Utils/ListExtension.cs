using System.Collections.Generic;

namespace SudokuSolver.Utils
{
    internal static class ListExtension
    {
        public static T Pop<T>(this List<T> list)
        {
            var r = list[0];
            list.RemoveAt(0);
            return r;
        }
    }
}
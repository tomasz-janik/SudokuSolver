using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.Utils
{
    internal static class Extensions
    {
        public static T Pop<T>(this List<T> list)
        {
            var r = list[0];
            list.RemoveAt(0);
            return r;
        }
        
        public static IEnumerable<IEnumerable<T>> ToGroup<T>(this IEnumerable<T> array, int length)
        {
            return array.Select((cell, index) => new {cell, index})
                .GroupBy(group => group.index / length)
                .Select(g => g.Select(a => a.cell));
        }

        public static List<List<T>> ToDoubleList<T>(this IEnumerable<IEnumerable<T>> arrays, int length)
        {
            return arrays.Select(array => array.ToList()).ToList();
        }
    }
}
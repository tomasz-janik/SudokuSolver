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
        
        //here we have yield - we know how to use it :)
        //todo - is this iterator? xDDD
        public static IEnumerable<string> Cut(this string input, int length)
        {
            for (var cursor = 0; cursor < input.Length; cursor += length) {
                if (cursor + length > input.Length) yield return input.Substring(cursor);
                else yield return input.Substring(cursor, length);
            }
        }

        public static IEnumerable<IEnumerable<T>> ToGroup<T>(this IEnumerable<T> array, int length)
        {
            return array.Select((cell, index) => new {cell, index})
                .GroupBy(group => group.index / length)
                .Select(g => g.Select(a => a.cell));
        }
        
        public static T[,] ToRectangularArray<T>(this IEnumerable<IEnumerable<T>> arrays, int length)
        {
            var ret = new T[length,  length];
            for (var i = 0; i < length; i++)
            {
                var array = arrays.ElementAt(i);
                for (var j = 0; j <  length; j++)
                {
                    ret[i, j] = array.ElementAt(j);
                }
            }
            return ret;
        }
        
        public static string DelimitWith<T>(this IEnumerable<T> source, string separator) => string.Join(separator, source);
    }
}
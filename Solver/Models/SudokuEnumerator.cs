using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ZedGraph;

namespace SudokuGrabber.Models
{
    public class SudokuEnumerator<T> : IEnumerator<T>
    {
        private readonly  T[,] _data;
        private int _row;
        private int _col;

        public SudokuEnumerator(T[,] data)
        {
            _row = 0;
            _col = 0;
            _data = data;
        }

        public bool MoveNext()
        {
            _col++;
            if (_col >= 9)
            {
                _col = 0;
                _row++;
            }

            return _row < 9;
        }

        public void Reset()
        {
            _row = 0;
            _col = 0;
        }

        public T Current => _data[_row, _col];

        object IEnumerator.Current => Current;

        public  void SetValue(T data)
        {
            _data[_row, _col] = data;
        }
        public void Dispose()
        {
        }
    }
}

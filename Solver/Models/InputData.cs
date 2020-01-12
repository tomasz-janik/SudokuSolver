using Microsoft.ML.Data;

namespace SudokuGrabber.Models
{
   public class InputData
    {
        [ColumnName("Data")]
        [VectorType(28*28)]
        public float[] PixelValues;

        public float Number;
    }
}
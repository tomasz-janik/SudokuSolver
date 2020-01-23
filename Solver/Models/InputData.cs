using Microsoft.ML.Data;

namespace SudokuGrabber.Models
{
   public class InputData
    {
        [ColumnName("PixelValues")]
        [VectorType(28*28)]
        public float[] PixelValues;

        public float Number;
    }
}
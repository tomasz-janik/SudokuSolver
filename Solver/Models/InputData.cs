using Microsoft.ML.Data;

namespace Solver.Models
{
   public class InputData
    {
        [ColumnName("Data")]
        [VectorType(28*28)]
        public float[] PixelValues;

        public float Number;
    }
}
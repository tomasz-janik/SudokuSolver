using Microsoft.ML.Data;

namespace Solver.Models
{
    public class OutPutData
    {
        [ColumnName("Score")]
        public float[] Score;
    }
}
using Microsoft.ML.Data;

namespace SudokuGrabber.Models
{
    public class OutPutData
    {
        [ColumnName("Score")]
        public float[] Score;
    }
}
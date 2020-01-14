using Emgu.CV;

namespace SudokuGrabber.Extensions
{
    internal static class MatExtension
    {
        public static void ShowImage(this Mat mat, string title = "Test")
        {
            // CvInvoke.Imshow(title, mat); //Show the image
            // CvInvoke.WaitKey();  //Wait for the key pressing event
            // CvInvoke.DestroyWindow(title); //Destroy the window if key is pressed
        }
        public static Matrix<float> ToVector(this Mat mat)
        {
            var result= new Matrix<float>(1, mat.Rows * mat.Cols);

            for (var row = 0; row < mat.Rows; row++)
            {
                for (var col = 0; col < mat.Cols; col++)
                {
                    var index = mat.Cols * row + col;

                    result[0, index] = (byte)mat.GetData().GetValue(row, col);

                }
            }
            return result;
        }
    }
}

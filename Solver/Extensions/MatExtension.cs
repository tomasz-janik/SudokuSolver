using Emgu.CV;

namespace SudokuGrabber.Extensions
{
   public static class MatExtension
    {
        public static void ShowImage(this Mat mat, string title = "Test")
        {
            CvInvoke.Imshow(title, mat); //Show the image
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyWindow(title); //Destroy the window if key is pressed
        }
        public static Matrix<float> ToVector(this Mat mat)
        {
            var result= new Matrix<float>(1, mat.Rows * mat.Cols);

            for (int row = 0; row < mat.Rows; row++)
            {
                for (int col = 0; col < mat.Cols; col++)
                {
                    int index = mat.Cols * row + col;

                    result[0, index] = (byte)mat.GetData().GetValue(row, col);

                }
            }
            return result;
        }

        public static float[] ToData(this Mat mat)
        {
            var result = new float[mat.Rows*mat.Cols];

            for (int row = 0; row < mat.Rows; row++)
            {
                for (int col = 0; col < mat.Cols; col++)
                {
                    int index = mat.Cols * row + col;

                    result[index] = (byte)mat.GetData().GetValue(row, col);

                }
            }
            return result;
        }
    }
}

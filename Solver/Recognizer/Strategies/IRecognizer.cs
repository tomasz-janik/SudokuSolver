using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;

namespace Solver.Recognizer.Strategies
{
    public  interface IRecognizer
    {
        int Recognize(Mat image);
    }
}

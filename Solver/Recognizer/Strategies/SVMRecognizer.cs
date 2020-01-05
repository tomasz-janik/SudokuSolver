using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.ML;
using Solver.Extensions;

namespace Solver.Recognizer.Strategies
{
    public class SVMRecognizer: IRecognizer
    {
        private readonly SVM _svm;

        public SVMRecognizer()
        {
            _svm = new SVM();
            _svm.Load("C:\\Users\\Daniel\\Desktop\\svm.xml"); //TO DO 
        }

        public SVMRecognizer(string path)
        {
            _svm = new SVM();
            _svm.Load(path);
        }
        public int Recognize(Mat image)
        { 
            return (int)_svm.Predict(image.ToVector());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Emgu.CV;
using Emgu.CV.ML;
using Solver.Extensions;

namespace Solver.Recognizer.Strategies
{
    public interface ISVMRecognizer: IRecognizer { }
    public class SVMRecognizer: ISVMRecognizer
    {
        private readonly SVM _svm;

        public SVMRecognizer()
        {
            _svm = new SVM();
            _svm.Load(Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\..\"), "Solver", "Resources", "svm.xml")); //TO DO 
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

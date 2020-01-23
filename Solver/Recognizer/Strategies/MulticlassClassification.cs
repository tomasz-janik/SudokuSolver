using System;
using System.IO;
using Emgu.CV;
using Microsoft.ML;
using Microsoft.ML.Data;
using SudokuGrabber.Extensions;
using SudokuGrabber.Models;

namespace SudokuGrabber.Recognizer.Strategies
{


    public class MulticlassClassification : IRecognizer
    {
        private readonly PredictionEngine<InputData, OutPutData> _pred;

        public MulticlassClassification()
        {
            var mlContext = new MLContext();
            var trainedModel= mlContext.Model.Load(Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\..\"), "Solver", "Resources", "Model.zip"), out var schema);

            _pred = mlContext.Model.CreatePredictionEngine<InputData, OutPutData>(trainedModel);
        }
        public int Recognize(Mat image)
        {
           
           var predict = _pred.Predict(new InputData(){PixelValues = image.ToData()});

           //Console.WriteLine($"Predicted probability:       zero:  {predict.Score[0]:0.####}");
           //Console.WriteLine($"                             one :  {predict.Score[1]:0.####}");
           //Console.WriteLine($"                             two:   {predict.Score[2]:0.####}");
           //Console.WriteLine($"                             three: {predict.Score[3]:0.####}");
           //Console.WriteLine($"                             four:  {predict.Score[4]:0.####}");
           //Console.WriteLine($"                             five:  {predict.Score[5]:0.####}");
           //Console.WriteLine($"                             six:   {predict.Score[6]:0.####}");
           //Console.WriteLine($"                             seven: {predict.Score[7]:0.####}");
           //Console.WriteLine($"                             eight: {predict.Score[8]:0.####}");
           //Console.WriteLine($"                             nine:  {predict.Score[9]:0.####}");
           //Console.WriteLine();

           //image.ShowImage();

           var score = predict.Score[0];
           var index = 0;
           for(int i = 0; i<=9;i++)
           { 
               if (predict.Score[i] > score)
               {
                   index = i;
                   score = predict.Score[i];
               }
           }

           return index;
        }
    }
}

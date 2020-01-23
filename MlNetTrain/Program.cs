using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using SudokuGrabber.Models;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Stitching;
using SudokuGrabber.Extensions;

namespace MlNetTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Train();
            
        }

        static void Train()
        {
            var mlContext = new MLContext();
            var digits = Read();

            var data = mlContext.Data.LoadFromEnumerable<InputData>(digits);
            data = mlContext.Data.Cache(data);

            var options = new SdcaMaximumEntropyMulticlassTrainer.Options
            {
                // Make the convergence tolerance tighter.
                ConvergenceTolerance = 0.03f,

                NumberOfThreads = 16,

                // Increase the maximum number of passes over training data.
                MaximumNumberOfIterations = 150,

            };


            var optionsSvm = new LinearSvmTrainer.Options
            {
                NumberOfIterations = 400,

            };

            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "Number", keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue).
                Append(mlContext.Transforms.Concatenate("Features", nameof(InputData.PixelValues)).AppendCacheCheckpoint(mlContext));

             var svm = mlContext.MulticlassClassification.Trainers.OneVersusAll(mlContext.BinaryClassification.Trainers.LinearSvm(optionsSvm));

            var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer).Append(mlContext.Transforms.Conversion.MapKeyToValue("Number", "Label"));



            Console.WriteLine("=============== Training the model ===============");
            ITransformer trainedModel = trainingPipeline.Fit(data);

            Console.WriteLine("=============== Done  ===============");
            mlContext.Model.Save(trainedModel, data.Schema, "C:\\Users\\Daniel\\Desktop\\Data\\Model.zip");
        }

        public static List<InputData> Read()
        {

            var result = new List<InputData>();


            var path = "C:\\Users\\Daniel\\Desktop\\ModelData\\";
            for (int i = 0; i < 10; i++)
            {
                var files = Directory.GetFiles($"{path}\\{i}\\");
                foreach (var file in files)
                {
                    using var image = CvInvoke.Imread(file, ImreadModes.Grayscale);
         
                    var newInputData = new InputData
                   {
                       Number = (float) i,
                       PixelValues = image.ToData()

                   };
                    result.Add(newInputData);
                }
            }

            return result;
        }



    }
}


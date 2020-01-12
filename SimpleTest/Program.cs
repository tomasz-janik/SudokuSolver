using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using SudokuGrabber;
using SudokuGrabber.Models;

namespace SimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            

            var image = CvInvoke.Imread("C:\\Users\\Daniel\\Desktop\\koty\\sudoku.jpg", ImreadModes.AnyColor);

              Train();


        }


        static void Train()
        {
            var mlContext = new MLContext();
            string basePath = "C:\\Users\\Daniel\\Desktop\\Data\\";
            var digits = new YnnMnistReader(basePath + "train-images.idx3-ubyte", basePath + "train-labels.idx1-ubyte").Read();

            var data = mlContext.Data.LoadFromEnumerable<InputData>(digits);
            //    mlContext.Data.Loa
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
                InitialWeightsDiameter = 2f,
                Shuffle = true,
                BatchSize = 2,
                NumberOfIterations = 90
            };

            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "Number", keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue).
                Append(mlContext.Transforms.Concatenate("Features", nameof(InputData.PixelValues)).AppendCacheCheckpoint(mlContext));

            // var svm = mlContext.MulticlassClassification.Trainers.OneVersusAll(mlContext.BinaryClassification.Trainers.LinearSvm(optionsSvm));
            var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(options);
            var trainingPipeline = dataProcessPipeline.Append(trainer).Append(mlContext.Transforms.Conversion.MapKeyToValue("Number", "Label"));


            Console.WriteLine("=============== Training the model ===============");
            ITransformer trainedModel = trainingPipeline.Fit(data);

            Console.WriteLine("=============== Done  ===============");
            mlContext.Model.Save(trainedModel, data.Schema, "C:\\Users\\Daniel\\Desktop\\Data\\Model.zip");
        }


    }
}

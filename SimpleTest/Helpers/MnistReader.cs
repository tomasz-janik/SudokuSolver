using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using SimpleTest.Helpers;
using Solver;
using Solver.Extensions;
using Solver.Models;

namespace SimpleTest
{
    class YnnMnistReader : IMnistReader<InputData>
    {
        private readonly string _pathData;
        private readonly string _pathLabels;
        public YnnMnistReader(string pathData, string pathLabels)
        {
            _pathData = pathData;
            _pathLabels = pathLabels;
        }

        public List<InputData> Read()
        {
           // var trainData = LoadFileBinary("C:\\Users\\Daniel\\Desktop\\Data\\train-images.idx3-ubyte");
            //var labelData = LoadFileBinary("C:\\Users\\Daniel\\Desktop\\Data\\train-labels.idx1-ubyte");
            var trainData = LoadFileBinary(_pathData);
            var labelData = LoadFileBinary(path: _pathLabels);

            trainData.ReadBigInt32();     //get header sum control
            labelData.ReadBigInt32();     //get header sum control

            var trainLength = trainData.ReadBigInt32();
            labelData.ReadBigInt32(); //get header label length

            var trainWidth = trainData.ReadBigInt32();      //ynn <- 28
            var trainHeight = trainData.ReadBigInt32();     //ynn <-- 28

            var digits = new List<InputData>();

            for (int train = 0; train < trainLength; train++)
            {

                var digit = new float[28 * 28];
                var label = labelData.ReadByte();
                for (int i = 0; i < trainWidth; i++)
                {

                    for (int j = 0; j < trainHeight; j++)
                    {
                        var pixel = trainData.ReadByte();
                        if (label != 0)
                        {
                            digit[j + i * 28] = pixel;
                        }
                        else
                        {
                            digit[j + i * 28] = 0f;
                        }

                    }
                }

                digits.Add(new InputData { PixelValues = digit, Number = label });
            }

            return digits;
        }

        private void Test(int arg1, int arg2)
        {

        }
        private  BinaryReader LoadFileBinary(string path)
        {
            var file = new FileStream(path, FileMode.Open);
            return new BinaryReader(file);
        }
    }
}

namespace FileProcessing
{
    using System;
    using System.Linq;
    using Handwritten_digits_recognition.NeuralNetworks;
    using System.Text;
    using System.IO;

    public class Program
    {
        static double[][] imgDataTrain, lblDataTrain, imgDataTest, lblDataTest;
        static Func<char[,], double[]> mapFunctionImages = x =>
            {
                double[] y = new double[x.GetLength(0) * x.GetLength(1)];
                for (int i = 0, pos = 0; i < x.GetLength(0); i++)
                    for (int j = 0; j < x.GetLength(0); j++)
                        y[pos++] = (double)x[i, j] / 256;
                return y;
            };
        static Func<short, double[]> mapFunctionLabels = x =>
            {
                double[] y = new double[10];
                y[x] = 1.0;
                return y;
            };

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            LoadDatabase();
            //LoadLocalDatabase();
            //CreateNeuralNetwork(20, 3000, 23);
            //TrainExistingNeuralNetwork(20, 2000, 4, 1);
            TrainExistingNeuralNetwork(20, 5000, 0.1, 0.01);
        }

        static void LoadDatabase()
        {
            //FullTest();
            imgDataTrain = DBFilesHandler.ReadImages(DBFilesHandler.images[0]).Select(mapFunctionImages).ToArray();
            lblDataTrain = DBFilesHandler.ReadLabels(DBFilesHandler.labels[0]).Select(mapFunctionLabels).ToArray();
            imgDataTest = DBFilesHandler.ReadImages(DBFilesHandler.images[1]).Select(mapFunctionImages).ToArray();
            lblDataTest = DBFilesHandler.ReadLabels(DBFilesHandler.labels[1]).Select(mapFunctionLabels).ToArray();
        }

        static void LoadLocalDatabase()
        {
            var a = DBFilesHandler.LoadLocalDB();
            imgDataTrain = a[0];
            lblDataTrain = a[1];
            imgDataTest = a[2];
            lblDataTest = a[3];
            for (int i = 0, id = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                    Console.Write($"{(int)(imgDataTrain[5][id++]):F4} "); Console.WriteLine();
            }
            Console.WriteLine(string.Join(" ", lblDataTrain[5]));
        }

        static void CreateNeuralNetwork(int batch = 20, int epochs = 30, double learingRate = 0.5)
        {
            NeuralNetwork nn = new NeuralNetwork(new int[]{ imgDataTrain[0].Length, 100, 10 }, learingRate);
            nn.Build(batch, epochs, imgDataTrain, lblDataTrain, imgDataTest, lblDataTest, DBFilesHandler.NNPath);
        }

        static void TrainExistingNeuralNetwork(int batch = 20, int epochs = 30, double learningRate = 10,
            double learingRateMin = 1.0, string file = "nn80.540_#72421.txt")
        {
            NeuralNetwork nn = new NeuralNetwork(DBFilesHandler.NNPath + file, learningRate, learingRateMin);
            nn.Build(batch, epochs, imgDataTrain, lblDataTrain, imgDataTest, lblDataTest, DBFilesHandler.NNPath);
        }

        static void PartialTest(int index, int id = 0)
        {
            char[][,] imgSetTest = DBFilesHandler.ReadImages(DBFilesHandler.images[index]);
            for (int i = 0; i < imgSetTest[id].GetLength(0); i++) 
            { 
                for (int j = 0; j < imgSetTest[id].GetLength(1); j++)
                    Console.Write($"{(int)(imgSetTest[id][i, j]):D4} "); Console.WriteLine();
            }
            short[] lblSetTest = DBFilesHandler.ReadLabels(DBFilesHandler.labels[index]);
            Console.WriteLine($"Label: {lblSetTest[id]}");
        }

        static void FullTest()
        {
            Console.WriteLine("Train Set:");
            PartialTest(0, 5);
            Console.WriteLine("Test Set:");
            PartialTest(1, 5);
        }
    }
}

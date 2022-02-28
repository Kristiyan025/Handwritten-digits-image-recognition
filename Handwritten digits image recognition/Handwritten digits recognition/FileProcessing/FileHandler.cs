namespace FileProcessing
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class DBFilesHandler
    {
        const byte byteSize = 8;
        public const string dataPath = "@../../../../../Resources/";
        public const string NNPath = "@../../../../../../NeuralNetworks/";
        /*   THE MNIST DATABASE of handwritten digits   */
        public static string[] images = { "img-ubyte-train.idx3-ubyte", "img-ubyte-test.idx3-ubyte" };
        public static string[] labels = { "lbl-ubyte-train.idx1-ubyte", "lbl-ubyte-test.idx1-ubyte" };
        static byte[] stream;
        static int pos;
        public static char[][,] ReadImages(string file)
        {
            stream = File.ReadAllBytes($"{dataPath}{file}");
            pos = 0;
            int magicNumber, count, rows, cols;
            ReadInt32(out magicNumber);
            if (magicNumber != 2051)
                throw new InvalidDataException("The image dataset has invalid format!");
            ReadInt32(out count);
            ReadInt32(out rows);
            ReadInt32(out cols);
            char[][,] dataset = new char[count][,];
            for(int i = 0; i < count; i++)
            {
                dataset[i] = new char[rows, cols];
                for (int j = 0; j < rows; j++)
                    for (int k = 0; k < cols; k++)
                        dataset[i][j, k] = (char)stream[pos++];
            }
            return dataset;
        }

        public static short[] ReadLabels(string file)
        {
            stream = File.ReadAllBytes($"{dataPath}{file}");
            pos = 0;
            int magicNumber, count;
            ReadInt32(out magicNumber);
            if (magicNumber != 2049)
                throw new InvalidDataException("The label dataset has invalid format!");
            ReadInt32(out count);
            short[] dataset = new short[count];
            for (int i = 0; i < count; i++)
                dataset[i] = stream[pos++];
            return dataset;
        }

        public static double[][][] LoadLocalDB()
        {
            double[][][] DataTrain;
            const int count = 100;
            DataTrain = new double[count][][];
            for (int i = 0; i < count; i++)
            {
                using (StreamReader sr = new StreamReader($"@../../../../../../Dataset/img-{i}.txt", Encoding.GetEncoding("windows-1251")))
                {
                    int dig = int.Parse(sr.ReadLine());
                    DataTrain[i] = new double[2][];
                    DataTrain[i][0] = new double[10];
                    DataTrain[i][0][dig] = 1.0;
                    int h = int.Parse(sr.ReadLine());
                    int w = int.Parse(sr.ReadLine());
                    DataTrain[i][1] = new double[w * h];
                    for (int j = 0, id = 0; j < h; j++)
                    {
                        double[] row = sr.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Select(x => (double)x / 256)
                            .ToArray();
                        for (int k = 0; k < w; k++)
                            DataTrain[i][1][id++] = row[k];
                    }
                }
            }
            Random r = new Random();
            int index = count - 1;
            while(index >= 0)
            {
                Swap(ref DataTrain[index], ref DataTrain[r.Next(index + 1)]);
                index--;
            }
            int skip = count / 5;
            double[][] imgDataTrain = DataTrain.Skip(skip).Select(x => x[1]).ToArray();
            double[][] lblDataTrain = DataTrain.Skip(skip).Select(x => x[0]).ToArray();
            double[][] imgDataTest = DataTrain.Take(skip).Select(x => x[1]).ToArray();
            double[][] lblDataTest = DataTrain.Take(skip).Select(x => x[0]).ToArray();
            return new double[][][] { imgDataTrain, lblDataTrain, imgDataTest, lblDataTest };
        }

        private static void Swap(ref double[][] a, ref double[][] b)
        {
            var x = a;
            a = b;
            b = a;
        }

        private static void ReadInt32(out int number)
        {
            number = 0;
            for (int i = 0; i < 4; i++)
                number = (number << byteSize) + stream[pos++];
        }

    }
}

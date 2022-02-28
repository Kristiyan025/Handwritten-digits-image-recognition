namespace Handwritten_digits_recognition.NeuralNetworks
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Handwritten_digits_recognition.Messages;

    public class NeuralNetwork
    {
        private const double LearningRateDecay = 0.98;
        private static Random random = new Random();
        private static Encoding encoding = Encoding.GetEncoding("windows-1251");
        private double[][,] weights;
        private double[][] biases;
        private double weightBound;

        public NeuralNetwork()
        {
            this.weights = new double[0][,];
            this.biases = new double[0][];
        }
    
        public NeuralNetwork(int[] layers, double learingRate = 0.1, double learningRateMin = 1.0)
        {
            this.LearningRate = learingRate;
            this.LearningRateMin = learningRateMin;
            foreach (int value in layers)
                if (value < 1)
                    throw new ArgumentException(MessageDB.InvalidLayers);
            weightBound = 1;
            this.weights = new double[layers.Length - 1][,];
            this.biases = new double[layers.Length - 1][];
            for(int i = 0; i < this.biases.Length; i++)
            {
                this.weights[i] = new double[layers[i + 1], layers[i]];
                for(int j = 0; j < this.weights[i].GetLength(0); j++)
                    for(int k = 0; k < this.weights[i].GetLength(1); k++)
                        this.weights[i][j, k] = this.GetRandomIn();
                this.biases[i] = new double[layers[i + 1]];
                for(int j = 0; j < this.biases[i].Length; j++)
                    this.biases[i][j] = this.GetRandomIn();
            }
        }

        public NeuralNetwork(string location, double learningRate = -1, double learningRateMin = 1.0)
        {
            using(StreamReader sr = new StreamReader(location, encoding))
            {
                this.LearningRate = double.Parse(sr.ReadLine());
                if (learningRate != -1) this.LearningRate = learningRate;
                this.LearningRateMin = learningRateMin;
                this.weights = new double[int.Parse(sr.ReadLine())][,];
                this.biases = new double[this.weights.Length][];
                for(int i = 0; i < this.weights.Length; i++)
                {
                    this.weights[i] = new double[int.Parse(sr.ReadLine()), int.Parse(sr.ReadLine())];
                    for(int j = 0; j < this.weights[i].GetLength(0); j++)
                    {
                        var row = sr.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();
                        if (row.Length != this.weights[i].GetLength(1))
                            throw new InvalidDataException(MessageDB.InvalidFileFormat);
                        for (int k = 0; k < row.Length; k++)
                            this.weights[i][j, k] = row[k];
                    }
                    this.biases[i] = sr.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();
                    if(this.biases[i].Length != this.weights[i].GetLength(0))
                        throw new InvalidDataException(MessageDB.InvalidFileFormat);
                }
                weightBound = 1;
            }
        }

        public NeuralNetwork(NeuralNetwork nn)
        {
            weightBound = nn.weightBound;
            this.LearningRate = nn.LearningRate;
            this.LearningRateMin = nn.LearningRateMin;
            this.weights = new double[nn.weights.Length][,];
            for(int i = 0; i < this.biases.Length; i++)
                this.weights[i] = nn.weights[i].Clone() as double[,];
            this.biases = new double[nn.biases.Length][];
            for(int i = 0; i < this.biases.Length; i++)
                this.biases[i] = nn.biases[i].Clone() as double[];
        }

        public double LearningRate { get; private set; }
        public double LearningRateMin { get; private set; }

        public void Build(int batchSize, int epochs, 
            double[][] trainImages, double[][] trainLabels, 
            double[][] testImages, double[][] testLabels,
            string location)
        {
            this.TrainInBatches(batchSize, epochs, trainImages, trainLabels, testLabels.Length, location);
            double accuracy = this.CaluclateAccuracy(testImages, testLabels);
            Console.WriteLine($"Accuracy: {accuracy*100:F2}%");
            this.SaveIn(Filename(location, accuracy));
        }

        public void TrainInBatches(int batchSize, int epochs, double[][] images, double[][] labels, 
            int validationLength, string location)
        {
            //while (images.Length % batchSize != 0) batchSize--;
            //for(int b = 0; b + batchSize <= images.Length; b += batchSize)
            /*{
                for (int i = 0; i < epochs; i++)
                {
                    //var imgBatch = images.Skip(b).Take(batchSize).ToArray();
                    //var lblBatch = labels.Skip(b).Take(batchSize).ToArray();
                    for (int j = 0; j < images.Length; j++)
                    {
                        //Console.WriteLine($"Img:{j+1:D5}");
                        var a = this.ForwardPropagate(images[j]);
                        this.BackwardPropagate(a, labels[j]);
                    }

                    //Console.WriteLine($"Finished epoch {i + 1:D3}");
                }
            }*/
            double[][] validationImages = images.Take(validationLength).ToArray();
            double[][] validationLabels = labels.Take(validationLength).ToArray();
            images = images.Skip(validationLength).ToArray();
            labels = labels.Skip(validationLength).ToArray();
            while (images.Length % batchSize != 0) batchSize--;
            for(int b = 287 * batchSize; b + batchSize <= images.Length; b += batchSize)
            {
                var imgBatch = images.Skip(b).Take(batchSize).ToArray();
                var lblBatch = labels.Skip(b).Take(batchSize).ToArray();
                for (int j = 0; j < imgBatch.Length; j++)
                {
                    for(int i = 0; i < epochs; i++)
                    {
                        var a = this.ForwardPropagate(imgBatch[j]);
                        this.BackwardPropagate(a, lblBatch[j]);
                    }
                }
                /*
                for(int i = 0; i < epochs; i++)
                {
                    var a = this.ForwardPropagateBatch(batchSize, imgBatch);
                    this.BackwardPropagateBatch(batchSize, a, lblBatch);
                }
                 */
                this.LearningRate = Math.Max(this.LearningRate * LearningRateDecay, this.LearningRateMin);
                Console.WriteLine($"Finished batch {b / batchSize + 1:D4}");
                double accuracy = this.CaluclateAccuracy(validationImages, validationLabels);
                Console.WriteLine($"Accuracy: {accuracy * 100:F3}%");
                this.SaveIn(Filename(location, accuracy));
            }
        }

        public double CaluclateAccuracy(double[][] images, double[][] labels)
        {
            int successful = 0;
            for(int i = 0; i < images.Length; i++)
            {
                var output = this.ForwardPropagate(images[i]).Last();
                if (NeuralNetwork.Argmax(output) == NeuralNetwork.Argmax(labels[i])) successful++;
            }
            return (double)successful / images.Length;
        }

        public int Predict(double[] input)
            => NeuralNetwork.Argmax(this.ForwardPropagate(input).Last());

        public double[][] ForwardPropagate(double[] input)
        {
            if (input.Length != this.weights[0].GetLength(1))
                throw new ArgumentException(MessageDB.InvalidInput);
            double[][] a = new double[this.weights.Length + 1][];
            a[0] = input.Clone() as double[];
            for (int i = 0; i < weights.Length; i++)
                a[i + 1] = this.Apply(weights[i], a[i], biases[i]);
            return a;
        }

        public double[][][] ForwardPropagateBatch(int batch, double[][] input)
        {
            for(int b = 0; b < batch; b++)
                if (input[b].Length != this.weights[0].GetLength(1))
                    throw new ArgumentException(MessageDB.InvalidInput);
            double[][][] a = new double[batch][][];
            for(int b = 0; b < batch; b++)
            {
                a[b] = new double[this.weights.Length + 1][];
                a[b][0] = input[b].Clone() as double[];
                for (int i = 0; i < weights.Length; i++)
                    a[b][i + 1] = this.Apply(weights[i], a[b][i], biases[i]);
            }
            return a;
        }

        public void BackwardPropagate(double[][] a, double[] expectedOutput)
        {
            if (a.Length != 1 + this.weights.Length) throw new Exception();
            double[][] err = new double[this.weights.Length][];
            for (int i = 0; i < err.Length; i++)
                err[i] = new double[this.weights[i].GetLength(0)];
            //Console.WriteLine($"errlen {err.Length}");
            for (int i = 0; i < expectedOutput.Length; i++)
                err[err.Length - 1][i] = (a[err.Length][i] - expectedOutput[i]);// * ActivateDerivative(a[err.Length][i]);
            //Console.WriteLine("Last Row");
            //for (int i = 0; i < expectedOutput.Length; i++)
            //    Console.WriteLine(err[err.Length - 1][i]); 
            for (int i = err.Length - 2; i >= 0; i--)
            {
                //Console.WriteLine($"Li = {i}");
                for (int j = 0; j < err[i].Length; j++)
                {
                    for (int k = 0; k < err[i + 1].Length; k++)
                        err[i][j] += this.weights[i][k, j] * err[i + 1][k];
                    //err[i][j] *= ActivateDerivative(a[i + 1][j]);
                    //Console.WriteLine($"err[{i:D3}][{j:D3}] = {err[i][j]}");
                }
            }
            for(int i = 0; i < this.weights.Length; i++)
            {
                for(int j = 0; j < this.weights[i].GetLength(0); j++)
                {
                    for(int k = 0; k < this.weights[i].GetLength(1); k++)
                    {
                        this.weights[i][j, k] -= this.LearningRate * err[i][j] * a[i][k];
                        //Console.WriteLine($"{i:D3} {j:D3} {k:D3} {this.weights[i][j, k]:F5}: {this.LearningRate * err[i][j] * a[i][k]}");
                    }
                }
            }
            for (int i = 0; i < this.weights.Length; i++)
            {
                for (int j = 0; j < this.weights[i].GetLength(0); j++)
                {
                    this.biases[i][j] -= this.LearningRate * err[i][j];
                }
            }
        }

        public void BackwardPropagateBatch(int batch, double[][][] a, double[][] expectedOutput)
        {
            double[][] err = new double[this.weights.Length][];
            for (int i = 0; i < err.Length; i++)
                err[i] = new double[this.weights[i].GetLength(0)];
            for(int b = 0; b < batch; b++)
            {
                for (int i = 0; i < expectedOutput[b].Length; i++)
                    err[err.Length - 1][i] += (a[b][err.Length][i] - expectedOutput[b][i]);// * ActivateDerivative(a[b][err.Length][i]);
            }
            for (int i = 0; i < expectedOutput[0].Length; i++)
                err[err.Length - 1][i] /= batch;
            for (int i = err.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < err[i].Length; j++)
                {
                    for (int k = 0; k < err[i + 1].Length; k++)
                        err[i][j] += this.weights[i][k, j] * err[i + 1][k];
                    //double avgDerivative = 0.0;
                    //for(int b = 0; b < batch; b++)
                    //    avgDerivative += ActivateDerivative(a[b][i + 1][j]);
                    //err[i][j] *= avgDerivative / batch;
                }
            }
            for (int i = 0; i < this.weights.Length; i++)
            {
                for (int j = 0; j < this.weights[i].GetLength(0); j++)
                {
                    for (int k = 0; k < this.weights[i].GetLength(1); k++)
                    {
                        double avgA = 0.0;
                        for (int b = 0; b < batch; b++)
                            avgA += a[b][i][k];
                        this.weights[i][j, k] -= this.LearningRate * err[i][j] * (avgA / batch);
                    }
                }
            }
            for (int i = 0; i < this.weights.Length; i++)
            {
                for (int j = 0; j < this.weights[i].GetLength(0); j++)
                {
                    this.biases[i][j] -= this.LearningRate * err[i][j];
                }
            }
        }

        public double[] Apply(double[,] weights, double[] input, double[] biases)
        {
            if (weights.GetLength(1) != input.Length || weights.GetLength(0) != biases.Length)
                throw new ArgumentException(MessageDB.InvalidDimensions);
            double[] output = new double[weights.GetLength(0)];
            for (int i = 0; i < weights.GetLength(0); i++)
                for (int j = 0; j < weights.GetLength(1); j++)
                    output[i] += weights[i, j] * input[j];
            for (int i = 0; i < output.Length; i++)
                output[i] = this.Activate(output[i] + biases[i]);
            return output;
        }

        public double GetRandomIn()
            => -this.weightBound  + 2 * this.weightBound * random.NextDouble();

        public Func<double, double> Activate { get; private set; } = Sigmoid;//x => (x > 0 ? x : 0);

        public Func<double, double> ActivateDerivative { get; private set; } = o => SigmoidDerivative(o);

        public static double Sigmoid(double x)
            => 1 / (1 + Math.Exp(-x));

        public static double SigmoidDerivative(double output)
            => output * (1 - output);

        public static int Argmax(double[] arr)
        {
            int mxId = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > arr[mxId]) mxId = i;
            return mxId;
        }

        public string Filename(string location, double accuracy) => $"{location}/nn{(accuracy * 100):F3}_#{NeuralNetwork.random.Next((int)1e4, (int)1e5)}.txt";

        public void SaveIn(string location)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.LearningRate.ToString());
            sb.AppendLine(this.biases.Length.ToString());
            for (int i = 0; i < this.biases.Length; i++)
            {
                sb.AppendLine(this.weights[i].GetLength(0).ToString());
                sb.AppendLine(this.weights[i].GetLength(1).ToString());
                for (int j = 0; j < this.weights[i].GetLength(0); j++)
                {
                    for (int k = 0; k < this.weights[i].GetLength(1); k++)
                    {
                        sb.Append($"{this.weights[i][j, k]}");
                        if (k != this.weights[i].GetLength(1) - 1)
                            sb.Append(' ');
                    }
                    sb.AppendLine();
                }
                sb.AppendLine(string.Join(" ", this.biases[i]));
            }
            using (StreamWriter sw = new StreamWriter(location, false, encoding))
            {
                sw.Write(sb.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Neural Network:\n");
            for(int i = 0; i < this.biases.Length; i++)
            {
                sb.Append($"From Layer {i + 1} to Layer {i + 2}:\n");
                for (int j = 0; j < this.weights[i].GetLength(0); j++)
                {
                    sb.Append('|');
                    for (int k = 0; k < this.weights[i].GetLength(1); k++)
                    {
                        sb.Append($"{this.weights[i][j, k]:F2}");
                        if (k != this.weights[i].GetLength(1) - 1)
                            sb.Append(' ');
                    }
                    sb.Append("|  ");
                    sb.Append(j == (this.weights[i].GetLength(0) >> 1) ? ',' : ' ');
                    sb.Append($"  |{this.biases[i][j]}|");
                    sb.Append('\n');
                }
            }
            return sb.ToString();
        }
    }
}

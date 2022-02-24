namespace Handwritten_digits_recognition.NeuralNetworks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Handwritten_digits_recognition.Messages;

    public class NeuralNetwork
    {
        private static Random random = new Random();
        private double[][,] weights;
        private double[][] biases;

        public NeuralNetwork()
        {
            this.weights = new double[0][,];
            this.biases = new double[0][];
        }
    
        public NeuralNetwork(params int[] layers)
        {
            foreach (int value in layers)
                if (value < 1)
                    throw new ArgumentException(MessageDB.InvalidLayers);
            this.weights = new double[layers.Length - 1][,];
            this.biases = new double[layers.Length - 1][];
            for(int i = 0; i < this.biases.Length; i++)
            {
                this.weights[i] = new double[layers[i], layers[i - 1]];
                for(int j = 0; j < this.weights[i].GetLength(0); j++)
                    for(int k = 0; k < this.weights[i].GetLength(1); k++)
                        this.weights[i][j, k] = NeuralNetwork.GetRandomIn();
                this.biases[i] = new double[layers[i]];
                for(int j = 0; j < this.biases[i].Length; j++)
                    this.biases[i][j] = NeuralNetwork.GetRandomIn();
            }
        }

        public NeuralNetwork(string location)
        {
            using(StreamReader sr = new StreamReader(location, Encoding.GetEncoding("windows-1251")))
            {
                this.LearningRate = double.Parse(sr.ReadLine());
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
            }
        }

        public NeuralNetwork(NeuralNetwork nn)
        {
            this.LearningRate = nn.LearningRate;
            this.weights = new double[nn.weights.Length][,];
            for(int i = 0; i < this.biases.Length; i++)
                this.weights[i] = nn.weights[i].Clone() as double[,];
            this.biases = new double[nn.biases.Length][];
            for(int i = 0; i < this.biases.Length; i++)
                this.biases[i] = nn.biases[i].Clone() as double[];
        }

        public double LearningRate { get; private set; } = 0.1;

        public double[][] Test(double[] input)
        {
            if (input.Length != this.weights[0].GetLength(1))
                throw new ArgumentException(MessageDB.InvalidInput);
            double[][] z = new double[this.weights.Length + 1][];
            z[0] = input.Clone() as double[];
            for(int i = 0; i < weights.Length; i++)
                z[i + 1] = this.Apply(weights[i], input, biases[i]);
            return z;
        }

        public void BackPropagate(double[][] z, double[] actualOutput)
        {
            double[][] deltas = new double[this.weights.Length][];
            for (int i = 0; i < deltas.Length; i++)
                deltas[i] = new double[this.weights[i].GetLength(0)];
            for(int i = 0; i < actualOutput.Length; i++)
                deltas[deltas.Length - 1][i] = z[z.Length][i] - actualOutput[i];
            for(int i = z.Length - 2; i > 0; i--)
            {
                //DO WORK
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

        public static double GetRandomIn(double a = -1.0, double b = +1.0)
            => a + (b - a) * random.NextDouble();

        public Func<double, double> Activate { get; private set; } = x => Sigmoid(x);

        public Func<double, double> ActivateDerivative { get; private set; } = x => SigmoidDerivative(x);

        public static double Sigmoid(double x)
            => 1 / (1 + Math.Exp(-x));

        private static double exp;
        public static double SigmoidDerivative(double x)
            => (exp = Math.Exp(-x)) / Math.Pow(1 + exp, 2);

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
            using(StreamWriter sw = new StreamWriter(location, false, Encoding.GetEncoding("windows-1251")))
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

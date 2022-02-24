namespace Handwritten_digits_recognition.Messages
{
    public static class MessageDB
    {
        public const string InvalidLayers = "The number of neurons in all layers should be a positive integer.";
        public const string InvalidDimensions = "The dimensions of the matrix should match the dimensions of the vectors.";
        public const string InvalidInput = "The size of the input should match the first given number in the constructor.";
        public const string InvalidFileFormat = "The file for reading the neural network is not in the right format.";
    }
}

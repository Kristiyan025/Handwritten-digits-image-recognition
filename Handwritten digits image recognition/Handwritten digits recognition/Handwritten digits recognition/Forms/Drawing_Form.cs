namespace Handwritten_digits_recognition.Forms
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Handwritten_digits_recognition.NeuralNetworks;

    public partial class Drawing_Form : Form
    {
        private int hoverOffset;

        public static bool isHovered = false;

        private const int size = 28;

        private const int width = 16;

        private Point location = new Point(2 * width, 2 * width);

        private double[][] alphas = new double[size][];

        private int previousLabel = -1;

        private int sign = 1;

        private Random r = new Random();

        private const int bias = 20;

        private NeuralNetwork nn;

        private int imgId = 0;

        public Drawing_Form(int hoverOff)
        {
            InitializeComponent();
            this.hoverOffset = hoverOff;
            this.ColorTimer.Enabled = true;
            for (int i = 0; i < size; i++)
            {
                this.Labels[i] = new Label[size];
                this.alphas[i] = new double[size];
                for (int j = 0; j < size; j++)
                {
                    Labels[i][j] = new Label();
                    Labels[i][j].Location = new Point(location.X + j * width,
                                                      location.Y + i * width);
                    Labels[i][j].Size = new Size(width, width);
                    Labels[i][j].BackColor = Color.White;
                    Labels[i][j].BorderStyle = BorderStyle.Fixed3D;
                    Labels[i][j].Enabled = true;
                    Labels[i][j].MouseMove += this.label_MouseMove;
                    Labels[i][j].Name = $"lblGrid_{i}-{j}";
                    Labels[i][j].Tag = i * size + j;
                    this.Controls.Add(Labels[i][j]);
                    this.alphas[i][j] = 1.00; //when the backColor is white the alpha is 1.00
                }

                this.Controls["lblBorder"].SendToBack();
            }
        }

        public Label[][] Labels = new Label[size][];

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            isHovered = true;
            Button b = sender as Button;
            b.Font = new Font("Papyrus", 38, FontStyle.Bold);
            b.Width += 2 * this.hoverOffset;
            b.Height += 2 * this.hoverOffset;
            b.Location = new Point(b.Location.X - hoverOffset,
                                   b.Location.Y - hoverOffset);;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            if (isHovered)
            {
                Button b = sender as Button;
                b.Font = new Font("Papyrus", 36, FontStyle.Regular);
                b.Width -= 2 * this.hoverOffset;
                b.Height -= 2 * this.hoverOffset;
                b.Location = new Point(b.Location.X + hoverOffset,
                                       b.Location.Y + hoverOffset);
            }

            isHovered = false;
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = MousePosition.X - this.Location.X; 
                int y = MousePosition.Y - this.Location.Y;
                x /= width;
                y /= width;
                x -= 2;
                y -= 2;
                if (x >= 0 && x < size && y >= 0 && y < size)
                {
                    int tag = y * size + x;
                    if (tag != this.previousLabel)
                    {
                        int column = tag % size;
                        int row = tag / size;
                        int radius = 2;
                        for (int i = row - radius + 1; i <= row + radius - 1; i++)
                        {
                            for (int j = column - radius + 1; j <= column + radius - 1; j++)
                            {
                                /*
                                  * x * 
                                  x o x 
                                  * x * 

                                 - these cells' alpha is not affected
                                 * these cells' alpha is affected with -0.33
                                 x these cells' alpha is affected with -0.67
                                 o these cells' alpha is affected with -1.00 
                                 (that's cursor location) 
                                 */
                                //that checks whether indexes are valid
                                if (i >= 0 && i < size && j >= 0 && j < size)
                                {
                                    double change = 0.00;
                                    //that checks whether the cell is o
                                    if (i == row && j == column)
                                    {
                                        change = 0.40;
                                    }
                                    //that checks whether the cell is x
                                    else if (Math.Abs(row - i) + Math.Abs(column - j) == 1)
                                    {
                                        change = 0.20;
                                    }
                                    //that checks whether the cell is *
                                    else if(Math.Abs(row - i) + Math.Abs(column - j) == 2)
                                    {
                                        change = 0.00;
                                    }

                                    //here is multiplying by sign, which is
                                    //defined according to pen/eraser 
                                    alphas[i][j] -= sign * change; 
                                    if (alphas[i][j] < 0.00) alphas[i][j] = 0.00;
                                    else if (alphas[i][j] > 1.00) alphas[i][j] = 1.00;
                                    int value = (int)(alphas[i][j] * 255);
                                    Labels[i][j].BackColor = 
                                        Color.FromArgb(value,value,value);
                                }
                            }
                        }
                    }

                    this.previousLabel = tag;
                }
            }
        }

        private void lblClear_MouseHover(object sender, EventArgs e)
        {
            lblClear.ForeColor = Color.White;
            lblClear.BackColor = Color.SteelBlue;
        }

        private void lblClear_MouseLeave(object sender, EventArgs e)
        {
            lblClear.ForeColor = Color.Black;
            lblClear.BackColor = Color.White;
        }

        ///update the grayscale value of the
        ///grid of labels according to the alphas
        private void UpdatePixels() 
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int value = (int)(alphas[i][j] * 255);
                    Labels[i][j].BackColor = 
                        Color.FromArgb(value, value, value);
                }
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    alphas[i][j] = 1.00;
                }
            }

            UpdatePixels();
        }

        private void lblPen_Click(object sender, EventArgs e)
        {
            if ((string)lblPen.Tag == "0") // not already selected pen
            {
                lblPen.Image = Properties.Resources.pen_focused;
                lblPen.Tag = "1";
                lblEraser.Image = Properties.Resources.eraser_unfocused;
                lblEraser.Tag = "0";
                this.sign = 1;
            }
        }

        private void lblEraser_Click(object sender, EventArgs e)
        {
            if ((string)lblEraser.Tag == "0") // not already selected eraser
            {
                lblPen.Image = Properties.Resources.pen_unfocused;
                lblPen.Tag = "0";
                lblEraser.Image = Properties.Resources.eraser_focused;
                lblEraser.Tag = "1";
                this.sign = -1;
            }
        }

        private void Drawing_Form_Shown(object sender, EventArgs e)
        {
            lblClear_Click(new object(), new EventArgs());
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            int p = 2 * bias + 1;
            var color = lblNumber.BackColor;
            int r = color.R + this.r.Next(0, p) - bias;
            if (r < 3) r = 3;
            if (r > 191) r = 191;
            int g = color.G + this.r.Next(0, p) - bias;
            if (g < 3) g = 3;
            if (g > 191) g = 191;
            int b = color.B + this.r.Next(0, p) - bias;
            if (b < 3) b = 3;
            if (b > 191) b = 191;
            lblNumber.BackColor = Color.FromArgb(r, g, b);
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            lblNumber.Visible = true;
            lblText.Visible = true;
            ColorTimer.Enabled = true;
            double[] input = new double[alphas.Length * alphas[0].Length];
            for (int i = 0, id = 0; i < alphas.Length; i++)
                for (int j = 0; j < alphas[i].Length; j++)
                    input[id++] = 1.0 - alphas[i][j];
            double max = input.Max();
            input = input.Select(x => x / max).ToArray();
            lblNumber.Text = this.nn.Predict(input).ToString();
            lblClear_Click(sender, e);
        }

        private void Drawing_Form_Load(object sender, EventArgs e)
        {

            lblNumber.Visible = false;
            lblText.Visible = false;
            ColorTimer.Enabled = false;
            this.nn = new NeuralNetwork(@"../../../NeuralNetworks/nn80.540_#72421.txt");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Digit_Form dForm = new Digit_Form();
            if (dForm.ShowDialog() == DialogResult.Cancel) return;
            using (StreamWriter sw = new StreamWriter($"../../../Dataset/img-{imgId++}.txt", false, Encoding.GetEncoding("windows-1251")))
            {
                sw.WriteLine(dForm.Digit);
                sw.WriteLine(alphas.Length);
                sw.WriteLine(alphas[0].Length);
                for (int i = 0; i < alphas.Length; i++)
                {
                    for (int j = 0; j < alphas[i].Length; j++)
                        sw.Write($"{(int)Math.Round((1.0 - alphas[i][j]) * 256):D3} ");
                    sw.WriteLine();
                }
            }
            lblClear_Click(sender, e);
        }
    }
}

namespace Handwritten_digits_recognition
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Forms;

    public partial class Menu : Form
    {
        private static Random r = new Random();

        private static Point p1;

        private static Point p2;

        private static double angle1 = 359.0;

        private static double angle2 = 179.0;

        private static double radius = 8.0;

        private static double incremention = 0.1;

        private static int hoverOffset = 2;

        public static bool isHovered = false;

        private static Closing_Form closingForm;

        private static QuickGuide_Form quickGuideForm;

        private static Drawing_Form drawingForm;

        public Menu()
        {
            InitializeComponent();
            closingForm = new Closing_Form(hoverOffset);
            quickGuideForm = new QuickGuide_Form(hoverOffset);
            drawingForm = new Drawing_Form(hoverOffset);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            p1 = lblNeuralNetwork.Location;
            p2 = lblDigits.Location;
            ColorTimer.Enabled = true;
            PositionTimer.Enabled = true;
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            var color = Color.FromArgb(r.Next(0, 191), r.Next(0, 191), r.Next(0, 191));
            lblNeuralNetwork.ForeColor = color;
            lblDigits.ForeColor = color;
        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            lblNeuralNetwork.Location = new Point((int)(p1.X + radius * Math.Cos(angle1)),
                                                  (int)(p1.Y + radius * Math.Sin(angle1)));
            angle1 += incremention;
            if (angle1 > 360) angle1 = 1;
            
            lblDigits.Location = new Point((int)(p2.X + radius * Math.Cos(angle2)),
                                           (int)(p2.Y + radius * Math.Sin(angle2)));
            angle2 += incremention;
            if (angle2 > 360) angle2 = 1;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            isHovered = true;
            Button b = sender as Button;
            b.Font = new Font("Tempus Sans ITC", 49, FontStyle.Bold);
            b.Width += 2 * hoverOffset;
            b.Height += 2 * hoverOffset;
            b.Location = new Point(b.Location.X - hoverOffset,
                                   b.Location.Y - hoverOffset);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            if(isHovered)
            {
                Button b = sender as Button;
                b.Font = new Font("Tempus Sans ITC", 47, FontStyle.Regular);
                b.Width -= 2 * hoverOffset;
                b.Height -= 2 * hoverOffset;
                b.Location = new Point(b.Location.X + hoverOffset,
                                       b.Location.Y + hoverOffset);
            }

            isHovered = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = closingForm.ShowDialog();
            if (d == DialogResult.No)
            {
                this.Enabled = true;
            }
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            DialogResult d;
            this.Enabled = false;
            this.Hide();
            d = quickGuideForm.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                
                this.Enabled = true;
                this.Show();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DialogResult d;
            this.Enabled = false;
            this.Hide();
            d = drawingForm.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                this.Enabled = true;
                this.Show();
            }
        }
    }
}

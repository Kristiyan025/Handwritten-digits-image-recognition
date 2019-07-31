namespace Handwritten_digits_recognition
{
    using System.Windows.Forms;
    using System.Drawing;

    public partial class Closing_Form : Form
    {
        private int hoverOffset;

        public static bool isHovered = false;

        public Closing_Form(int hoverOff)
        {
            InitializeComponent();
            this.hoverOffset = hoverOff;
        }

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnYes_MouseHover(object sender, System.EventArgs e)
        {
            isHovered = true;
            Button b = sender as Button;
            b.Font = new Font("Playball", 38, FontStyle.Bold);
            b.Width += 2 * hoverOffset;
            b.Height += 2 * hoverOffset;
            b.Location = new Point(b.Location.X - hoverOffset,
                                   b.Location.Y - hoverOffset);
        }

        private void btnYes_MouseLeave(object sender, System.EventArgs e)
        {
            if (isHovered)
            {
                Button b = sender as Button;
                b.Font = new Font("Playball", 36, FontStyle.Regular);
                b.Width -= 2 * hoverOffset;
                b.Height -= 2 * hoverOffset;
                b.Location = new Point(b.Location.X + hoverOffset,
                                       b.Location.Y + hoverOffset);
            }

            isHovered = false;
        }
    }
}

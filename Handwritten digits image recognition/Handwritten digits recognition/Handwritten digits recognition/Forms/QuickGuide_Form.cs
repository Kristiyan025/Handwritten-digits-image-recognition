namespace Handwritten_digits_recognition
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class QuickGuide_Form : Form
    {
        private int hoverOffset;

        public static bool isHovered = false;

        public QuickGuide_Form(int hoverOff)
        {
            InitializeComponent();
            this.hoverOffset = hoverOff;
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnBack_MouseHover(object sender, System.EventArgs e)
        {
            isHovered = true;
            Button b = sender as Button;
            b.Font = new Font("Papyrus", 38, FontStyle.Bold);
            b.Width += 2 * hoverOffset;
            b.Height += 2 * hoverOffset;
            b.Location = new Point(b.Location.X - hoverOffset,
                                   b.Location.Y - hoverOffset);
        }

        private void btnBack_MouseLeave(object sender, System.EventArgs e)
        {
            if (isHovered)
            {
                Button b = sender as Button;
                b.Font = new Font("Papyrus", 36, FontStyle.Regular);
                b.Width -= 2 * hoverOffset;
                b.Height -= 2 * hoverOffset;
                b.Location = new Point(b.Location.X + hoverOffset,
                                       b.Location.Y + hoverOffset);
            }

            isHovered = false;
        }
    }
}

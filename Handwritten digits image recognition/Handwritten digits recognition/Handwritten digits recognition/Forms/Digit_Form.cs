using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Handwritten_digits_recognition.Forms
{
    public partial class Digit_Form : Form
    {
        public Digit_Form()
        {
            InitializeComponent();
        }

        public int Digit { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Digit = (int)nudDigit.Value;
        }
    }
}

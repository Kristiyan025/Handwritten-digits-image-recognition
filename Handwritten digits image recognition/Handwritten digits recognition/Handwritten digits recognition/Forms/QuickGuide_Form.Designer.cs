namespace Handwritten_digits_recognition
{
    partial class QuickGuide_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickGuide_Form));
            this.picBoxExample = new System.Windows.Forms.PictureBox();
            this.lblPart1 = new System.Windows.Forms.Label();
            this.lblPart2 = new System.Windows.Forms.Label();
            this.picBoxExclamation = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExclamation)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxExample
            // 
            this.picBoxExample.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBoxExample.Image = global::Handwritten_digits_recognition.Properties.Resources.game;
            this.picBoxExample.Location = new System.Drawing.Point(440, 34);
            this.picBoxExample.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxExample.Name = "picBoxExample";
            this.picBoxExample.Size = new System.Drawing.Size(589, 338);
            this.picBoxExample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExample.TabIndex = 0;
            this.picBoxExample.TabStop = false;
            // 
            // lblPart1
            // 
            this.lblPart1.BackColor = System.Drawing.Color.Transparent;
            this.lblPart1.Font = new System.Drawing.Font("Tempus Sans ITC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPart1.Location = new System.Drawing.Point(21, 26);
            this.lblPart1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPart1.Name = "lblPart1";
            this.lblPart1.Size = new System.Drawing.Size(416, 415);
            this.lblPart1.TabIndex = 1;
            this.lblPart1.Text = "You can draw on the 28x28 grid and the goal is to write a single digit! Then ther" +
    "e is 99% chance, that computer will guess right your digit!";
            // 
            // lblPart2
            // 
            this.lblPart2.BackColor = System.Drawing.Color.Transparent;
            this.lblPart2.Font = new System.Drawing.Font("Tempus Sans ITC", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPart2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPart2.Location = new System.Drawing.Point(540, 406);
            this.lblPart2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPart2.Name = "lblPart2";
            this.lblPart2.Size = new System.Drawing.Size(500, 188);
            this.lblPart2.TabIndex = 1;
            this.lblPart2.Text = "Please follow these guide strictly, otherwise the percent of right guessing will " +
    "decrease!";
            // 
            // picBoxExclamation
            // 
            this.picBoxExclamation.BackColor = System.Drawing.Color.Transparent;
            this.picBoxExclamation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxExclamation.Image = global::Handwritten_digits_recognition.Properties.Resources.exclamation_mark;
            this.picBoxExclamation.Location = new System.Drawing.Point(453, 406);
            this.picBoxExclamation.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxExclamation.Name = "picBoxExclamation";
            this.picBoxExclamation.Size = new System.Drawing.Size(84, 66);
            this.picBoxExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExclamation.TabIndex = 2;
            this.picBoxExclamation.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.blue_button_background;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Blue;
            this.btnBack.Location = new System.Drawing.Point(52, 491);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(267, 97);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = " Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseLeave += new System.EventHandler(this.btnBack_MouseLeave);
            this.btnBack.MouseHover += new System.EventHandler(this.btnBack_MouseHover);
            // 
            // QuickGuide_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.form_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 630);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.picBoxExclamation);
            this.Controls.Add(this.lblPart2);
            this.Controls.Add(this.lblPart1);
            this.Controls.Add(this.picBoxExample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuickGuide_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExclamation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxExample;
        private System.Windows.Forms.Label lblPart1;
        private System.Windows.Forms.Label lblPart2;
        private System.Windows.Forms.PictureBox picBoxExclamation;
        private System.Windows.Forms.Button btnBack;
    }
}
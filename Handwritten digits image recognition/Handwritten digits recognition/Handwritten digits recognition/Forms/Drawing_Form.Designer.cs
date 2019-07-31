namespace Handwritten_digits_recognition.Forms
{
    partial class Drawing_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drawing_Form));
            this.lblBorder = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblPen = new System.Windows.Forms.Label();
            this.lblEraser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.ColorTimer = new System.Windows.Forms.Timer(this.components);
            this.btnGuess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBorder
            // 
            this.lblBorder.BackColor = System.Drawing.Color.Black;
            this.lblBorder.Location = new System.Drawing.Point(29, 29);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(454, 454);
            this.lblBorder.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.blue_button_background;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBack.Location = new System.Drawing.Point(540, 405);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 80);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = " Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseLeave += new System.EventHandler(this.btnBack_MouseLeave);
            this.btnBack.MouseHover += new System.EventHandler(this.btnBack_MouseHover);
            // 
            // lblPen
            // 
            this.lblPen.Image = global::Handwritten_digits_recognition.Properties.Resources.pen_focused;
            this.lblPen.Location = new System.Drawing.Point(489, 30);
            this.lblPen.Name = "lblPen";
            this.lblPen.Size = new System.Drawing.Size(40, 28);
            this.lblPen.TabIndex = 5;
            this.lblPen.Tag = "1";
            this.lblPen.Click += new System.EventHandler(this.lblPen_Click);
            // 
            // lblEraser
            // 
            this.lblEraser.Image = global::Handwritten_digits_recognition.Properties.Resources.eraser_unfocused;
            this.lblEraser.Location = new System.Drawing.Point(529, 30);
            this.lblEraser.Name = "lblEraser";
            this.lblEraser.Size = new System.Drawing.Size(40, 28);
            this.lblEraser.TabIndex = 5;
            this.lblEraser.Tag = "0";
            this.lblEraser.Click += new System.EventHandler(this.lblEraser_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(488, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 30);
            this.label1.TabIndex = 6;
            // 
            // lblClear
            // 
            this.lblClear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClear.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClear.Location = new System.Drawing.Point(489, 59);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(80, 28);
            this.lblClear.TabIndex = 7;
            this.lblClear.Text = "Clear";
            this.lblClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            this.lblClear.MouseLeave += new System.EventHandler(this.lblClear_MouseLeave);
            this.lblClear.MouseHover += new System.EventHandler(this.lblClear_MouseHover);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(488, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 30);
            this.label3.TabIndex = 7;
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.Indigo;
            this.lblText.Location = new System.Drawing.Point(576, 29);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(214, 85);
            this.lblText.TabIndex = 8;
            this.lblText.Text = "The neural network thinks, that your number is:";
            // 
            // lblNumber
            // 
            this.lblNumber.Font = new System.Drawing.Font("Playball", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumber.Location = new System.Drawing.Point(611, 137);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(114, 149);
            this.lblNumber.TabIndex = 9;
            this.lblNumber.Text = "5";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorTimer
            // 
            this.ColorTimer.Enabled = true;
            this.ColorTimer.Interval = 30;
            this.ColorTimer.Tick += new System.EventHandler(this.ColorTimer_Tick);
            // 
            // btnGuess
            // 
            this.btnGuess.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.blue_button_background;
            this.btnGuess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuess.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuess.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnGuess.Location = new System.Drawing.Point(540, 319);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(200, 80);
            this.btnGuess.TabIndex = 4;
            this.btnGuess.Text = "Guess";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            this.btnGuess.MouseLeave += new System.EventHandler(this.btnBack_MouseLeave);
            this.btnGuess.MouseHover += new System.EventHandler(this.btnBack_MouseHover);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(609, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 153);
            this.label2.TabIndex = 10;
            // 
            // Drawing_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.drawing_form_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblEraser);
            this.Controls.Add(this.lblPen);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Drawing_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Drawing_Form_Load);
            this.Shown += new System.EventHandler(this.Drawing_Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblPen;
        private System.Windows.Forms.Label lblEraser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Timer ColorTimer;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.Label label2;
    }
}
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBorder
            // 
            this.lblBorder.BackColor = System.Drawing.Color.Black;
            this.lblBorder.Location = new System.Drawing.Point(39, 36);
            this.lblBorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(605, 559);
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
            this.btnBack.Location = new System.Drawing.Point(720, 521);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(267, 98);
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
            this.lblPen.Location = new System.Drawing.Point(652, 37);
            this.lblPen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPen.Name = "lblPen";
            this.lblPen.Size = new System.Drawing.Size(53, 34);
            this.lblPen.TabIndex = 5;
            this.lblPen.Tag = "1";
            this.lblPen.Click += new System.EventHandler(this.lblPen_Click);
            // 
            // lblEraser
            // 
            this.lblEraser.Image = global::Handwritten_digits_recognition.Properties.Resources.eraser_unfocused;
            this.lblEraser.Location = new System.Drawing.Point(705, 37);
            this.lblEraser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEraser.Name = "lblEraser";
            this.lblEraser.Size = new System.Drawing.Size(53, 34);
            this.lblEraser.TabIndex = 5;
            this.lblEraser.Tag = "0";
            this.lblEraser.Click += new System.EventHandler(this.lblEraser_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(651, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 37);
            this.label1.TabIndex = 6;
            // 
            // lblClear
            // 
            this.lblClear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClear.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClear.Location = new System.Drawing.Point(652, 73);
            this.lblClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(107, 34);
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
            this.label3.Location = new System.Drawing.Point(651, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 37);
            this.label3.TabIndex = 7;
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.Indigo;
            this.lblText.Location = new System.Drawing.Point(768, 36);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(285, 105);
            this.lblText.TabIndex = 8;
            this.lblText.Text = "The neural network thinks, that your number is:";
            // 
            // lblNumber
            // 
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumber.Location = new System.Drawing.Point(853, 114);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(152, 183);
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
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.blue_button_background;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSave.Location = new System.Drawing.Point(720, 416);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(267, 98);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnBack_MouseLeave);
            this.btnSave.MouseHover += new System.EventHandler(this.btnBack_MouseHover);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(850, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 188);
            this.label2.TabIndex = 10;
            // 
            // btnGuess
            // 
            this.btnGuess.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.blue_button_background;
            this.btnGuess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuess.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuess.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnGuess.Location = new System.Drawing.Point(720, 310);
            this.btnGuess.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(267, 98);
            this.btnGuess.TabIndex = 4;
            this.btnGuess.Text = "Guess";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            this.btnGuess.MouseLeave += new System.EventHandler(this.btnBack_MouseLeave);
            this.btnGuess.MouseHover += new System.EventHandler(this.btnBack_MouseHover);
            // 
            // Drawing_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Handwritten_digits_recognition.Properties.Resources.drawing_form_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 630);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblEraser);
            this.Controls.Add(this.lblPen);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuess;
    }
}
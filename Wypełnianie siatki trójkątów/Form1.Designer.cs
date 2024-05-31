

namespace Wypełnianie_siatki_trójkątów
{
    partial class Form1
    {
     
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.LoadTextureButton = new System.Windows.Forms.Button();
            this.ChooseLightColor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadMapButton = new System.Windows.Forms.Button();
            this.FillingBox = new System.Windows.Forms.GroupBox();
            this.CloudBox = new System.Windows.Forms.CheckBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.StepButton = new System.Windows.Forms.Button();
            this.NormalMapBox = new System.Windows.Forms.CheckBox();
            this.VectorInterpolationButton = new System.Windows.Forms.RadioButton();
            this.ColorInterpolationButton = new System.Windows.Forms.RadioButton();
            this.FromTextureBox = new System.Windows.Forms.CheckBox();
            this.FillTriangleButton = new System.Windows.Forms.RadioButton();
            this.StopBox = new System.Windows.Forms.CheckBox();
            this.GridBox = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mBar = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.HeightBar = new System.Windows.Forms.TrackBar();
            this.ksText = new System.Windows.Forms.TextBox();
            this.kdText = new System.Windows.Forms.TextBox();
            this.ksBar = new System.Windows.Forms.TrackBar();
            this.kdBar = new System.Windows.Forms.TrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kaBar = new System.Windows.Forms.TrackBar();
            this.kaBarasdsa = new System.Windows.Forms.TextBox();
            this.cloudheightBar = new System.Windows.Forms.TrackBar();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.LightColorChooser = new System.Windows.Forms.ColorDialog();
            this.FrameUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ObjectColorChooser = new System.Windows.Forms.ColorDialog();
            this.TextureFileLoader = new System.Windows.Forms.OpenFileDialog();
            this.MapFileLoader = new System.Windows.Forms.OpenFileDialog();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.FillingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kaBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudheightBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(611, 611);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.FillingBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 611);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.speedBar);
            this.groupBox3.Controls.Add(this.LoadTextureButton);
            this.groupBox3.Controls.Add(this.ChooseLightColor);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.LoadMapButton);
            this.groupBox3.Location = new System.Drawing.Point(0, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 149);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kolory, Textura i Mapa";
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(249, 43);
            this.speedBar.Maximum = 100;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(104, 45);
            this.speedBar.TabIndex = 19;
            this.speedBar.Value = 40;
            // 
            // LoadTextureButton
            // 
            this.LoadTextureButton.Location = new System.Drawing.Point(127, 43);
            this.LoadTextureButton.Name = "LoadTextureButton";
            this.LoadTextureButton.Size = new System.Drawing.Size(83, 23);
            this.LoadTextureButton.TabIndex = 17;
            this.LoadTextureButton.Text = "Load Texture";
            this.LoadTextureButton.UseVisualStyleBackColor = true;
            this.LoadTextureButton.Click += new System.EventHandler(this.LoadTextureButton_Click);
            // 
            // ChooseLightColor
            // 
            this.ChooseLightColor.Location = new System.Drawing.Point(6, 111);
            this.ChooseLightColor.Name = "ChooseLightColor";
            this.ChooseLightColor.Size = new System.Drawing.Size(83, 23);
            this.ChooseLightColor.TabIndex = 4;
            this.ChooseLightColor.Text = "światło";
            this.ChooseLightColor.UseVisualStyleBackColor = true;
            this.ChooseLightColor.Click += new System.EventHandler(this.ChooseLightColor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "obiekt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadMapButton
            // 
            this.LoadMapButton.Location = new System.Drawing.Point(127, 111);
            this.LoadMapButton.Name = "LoadMapButton";
            this.LoadMapButton.Size = new System.Drawing.Size(83, 23);
            this.LoadMapButton.TabIndex = 18;
            this.LoadMapButton.Text = "Load Map";
            this.LoadMapButton.UseVisualStyleBackColor = true;
            this.LoadMapButton.Click += new System.EventHandler(this.LoadMapButton_Click);
            // 
            // FillingBox
            // 
            this.FillingBox.Controls.Add(this.CloudBox);
            this.FillingBox.Controls.Add(this.UpdateButton);
            this.FillingBox.Controls.Add(this.StepButton);
            this.FillingBox.Controls.Add(this.NormalMapBox);
            this.FillingBox.Controls.Add(this.VectorInterpolationButton);
            this.FillingBox.Controls.Add(this.ColorInterpolationButton);
            this.FillingBox.Controls.Add(this.FromTextureBox);
            this.FillingBox.Controls.Add(this.FillTriangleButton);
            this.FillingBox.Controls.Add(this.StopBox);
            this.FillingBox.Controls.Add(this.GridBox);
            this.FillingBox.Location = new System.Drawing.Point(0, 410);
            this.FillingBox.Name = "FillingBox";
            this.FillingBox.Size = new System.Drawing.Size(410, 201);
            this.FillingBox.TabIndex = 14;
            this.FillingBox.TabStop = false;
            this.FillingBox.Text = "Sposób wypełniania";
            // 
            // CloudBox
            // 
            this.CloudBox.AutoSize = true;
            this.CloudBox.Location = new System.Drawing.Point(249, 91);
            this.CloudBox.Name = "CloudBox";
            this.CloudBox.Size = new System.Drawing.Size(86, 19);
            this.CloudBox.TabIndex = 18;
            this.CloudBox.Text = "Draw cloud";
            this.CloudBox.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(249, 168);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 17;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // StepButton
            // 
            this.StepButton.Location = new System.Drawing.Point(249, 127);
            this.StepButton.Name = "StepButton";
            this.StepButton.Size = new System.Drawing.Size(75, 23);
            this.StepButton.TabIndex = 14;
            this.StepButton.Text = "Step";
            this.StepButton.UseVisualStyleBackColor = true;
            this.StepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // NormalMapBox
            // 
            this.NormalMapBox.AutoSize = true;
            this.NormalMapBox.Location = new System.Drawing.Point(6, 163);
            this.NormalMapBox.Name = "NormalMapBox";
            this.NormalMapBox.Size = new System.Drawing.Size(111, 19);
            this.NormalMapBox.TabIndex = 16;
            this.NormalMapBox.Text = "Mapa wektorów";
            this.NormalMapBox.UseVisualStyleBackColor = true;
            // 
            // VectorInterpolationButton
            // 
            this.VectorInterpolationButton.AutoSize = true;
            this.VectorInterpolationButton.Location = new System.Drawing.Point(6, 91);
            this.VectorInterpolationButton.Name = "VectorInterpolationButton";
            this.VectorInterpolationButton.Size = new System.Drawing.Size(142, 19);
            this.VectorInterpolationButton.TabIndex = 5;
            this.VectorInterpolationButton.TabStop = true;
            this.VectorInterpolationButton.Text = "interpolacja wektorów";
            this.VectorInterpolationButton.UseVisualStyleBackColor = true;
            // 
            // ColorInterpolationButton
            // 
            this.ColorInterpolationButton.AutoSize = true;
            this.ColorInterpolationButton.Location = new System.Drawing.Point(6, 56);
            this.ColorInterpolationButton.Name = "ColorInterpolationButton";
            this.ColorInterpolationButton.Size = new System.Drawing.Size(124, 19);
            this.ColorInterpolationButton.TabIndex = 4;
            this.ColorInterpolationButton.TabStop = true;
            this.ColorInterpolationButton.Text = "interpolacja koloru";
            this.ColorInterpolationButton.UseVisualStyleBackColor = true;
            this.ColorInterpolationButton.CheckedChanged += new System.EventHandler(this.ColorInterpolationButton_CheckedChanged);
            // 
            // FromTextureBox
            // 
            this.FromTextureBox.AutoSize = true;
            this.FromTextureBox.Location = new System.Drawing.Point(6, 127);
            this.FromTextureBox.Name = "FromTextureBox";
            this.FromTextureBox.Size = new System.Drawing.Size(64, 19);
            this.FromTextureBox.TabIndex = 15;
            this.FromTextureBox.Text = "Textura";
            this.FromTextureBox.UseVisualStyleBackColor = true;
            // 
            // FillTriangleButton
            // 
            this.FillTriangleButton.AutoSize = true;
            this.FillTriangleButton.Checked = true;
            this.FillTriangleButton.Location = new System.Drawing.Point(6, 22);
            this.FillTriangleButton.Name = "FillTriangleButton";
            this.FillTriangleButton.Size = new System.Drawing.Size(83, 19);
            this.FillTriangleButton.TabIndex = 3;
            this.FillTriangleButton.TabStop = true;
            this.FillTriangleButton.Text = "cały trójkąt";
            this.FillTriangleButton.UseVisualStyleBackColor = true;
            // 
            // StopBox
            // 
            this.StopBox.AutoSize = true;
            this.StopBox.Location = new System.Drawing.Point(249, 23);
            this.StopBox.Name = "StopBox";
            this.StopBox.Size = new System.Drawing.Size(50, 19);
            this.StopBox.TabIndex = 11;
            this.StopBox.Text = "Stop";
            this.StopBox.UseVisualStyleBackColor = true;
            this.StopBox.CheckedChanged += new System.EventHandler(this.StopBox_CheckedChanged);
            // 
            // GridBox
            // 
            this.GridBox.AutoSize = true;
            this.GridBox.Location = new System.Drawing.Point(249, 57);
            this.GridBox.Name = "GridBox";
            this.GridBox.Size = new System.Drawing.Size(77, 19);
            this.GridBox.TabIndex = 13;
            this.GridBox.Text = "Draw grid";
            this.GridBox.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(154, 176);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 23);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "m";
            // 
            // mBar
            // 
            this.mBar.Location = new System.Drawing.Point(127, 125);
            this.mBar.Maximum = 100;
            this.mBar.Minimum = 1;
            this.mBar.Name = "mBar";
            this.mBar.Size = new System.Drawing.Size(104, 45);
            this.mBar.TabIndex = 9;
            this.mBar.Value = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 23);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "wysokość";
            // 
            // HeightBar
            // 
            this.HeightBar.Location = new System.Drawing.Point(127, 24);
            this.HeightBar.Maximum = 100;
            this.HeightBar.Name = "HeightBar";
            this.HeightBar.Size = new System.Drawing.Size(104, 45);
            this.HeightBar.TabIndex = 7;
            this.HeightBar.Value = 1;
            // 
            // ksText
            // 
            this.ksText.Location = new System.Drawing.Point(27, 176);
            this.ksText.Name = "ksText";
            this.ksText.Size = new System.Drawing.Size(55, 23);
            this.ksText.TabIndex = 3;
            this.ksText.Text = "ks";
            // 
            // kdText
            // 
            this.kdText.Location = new System.Drawing.Point(27, 75);
            this.kdText.Name = "kdText";
            this.kdText.Size = new System.Drawing.Size(55, 23);
            this.kdText.TabIndex = 2;
            this.kdText.Text = "kd";
            // 
            // ksBar
            // 
            this.ksBar.Location = new System.Drawing.Point(6, 125);
            this.ksBar.Name = "ksBar";
            this.ksBar.Size = new System.Drawing.Size(104, 45);
            this.ksBar.TabIndex = 1;
            this.ksBar.Value = 10;
            // 
            // kdBar
            // 
            this.kdBar.Location = new System.Drawing.Point(6, 24);
            this.kdBar.Name = "kdBar";
            this.kdBar.Size = new System.Drawing.Size(104, 45);
            this.kdBar.TabIndex = 0;
            this.kdBar.Value = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Canvas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1032, 614);
            this.splitContainer1.SplitterDistance = 615;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kaBar);
            this.groupBox2.Controls.Add(this.kaBarasdsa);
            this.groupBox2.Controls.Add(this.cloudheightBar);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.kdBar);
            this.groupBox2.Controls.Add(this.ksBar);
            this.groupBox2.Controls.Add(this.kdText);
            this.groupBox2.Controls.Add(this.ksText);
            this.groupBox2.Controls.Add(this.HeightBar);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.mBar);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 211);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametry";
            // 
            // kaBar
            // 
            this.kaBar.Location = new System.Drawing.Point(249, 125);
            this.kaBar.Maximum = 100;
            this.kaBar.Name = "kaBar";
            this.kaBar.Size = new System.Drawing.Size(104, 45);
            this.kaBar.TabIndex = 13;
            this.kaBar.Value = 1;
            // 
            // kaBarasdsa
            // 
            this.kaBarasdsa.Location = new System.Drawing.Point(276, 176);
            this.kaBarasdsa.Name = "kaBarasdsa";
            this.kaBarasdsa.Size = new System.Drawing.Size(59, 23);
            this.kaBarasdsa.TabIndex = 14;
            this.kaBarasdsa.Text = "ka";
            // 
            // cloudheightBar
            // 
            this.cloudheightBar.Location = new System.Drawing.Point(249, 24);
            this.cloudheightBar.Maximum = 100;
            this.cloudheightBar.Name = "cloudheightBar";
            this.cloudheightBar.Size = new System.Drawing.Size(104, 45);
            this.cloudheightBar.TabIndex = 11;
            this.cloudheightBar.Value = 1;
            this.cloudheightBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(276, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 23);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "chmura";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // LightColorChooser
            // 
            this.LightColorChooser.Color = System.Drawing.Color.White;
            // 
            // FrameUpdateTimer
            // 
            this.FrameUpdateTimer.Enabled = true;
            this.FrameUpdateTimer.Interval = 10;
            this.FrameUpdateTimer.Tick += new System.EventHandler(this.FrameUpdateTimer_Tick);
            // 
            // ObjectColorChooser
            // 
            this.ObjectColorChooser.Color = System.Drawing.Color.White;
            // 
            // TextureFileLoader
            // 
            this.TextureFileLoader.FileName = "openFileDialog1";
            // 
            // MapFileLoader
            // 
            this.MapFileLoader.FileName = "openFileDialog2";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(276, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(59, 23);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Prędkość";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 614);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.FillingBox.ResumeLayout(false);
            this.FillingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdBar)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kaBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudheightBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox kdText;
        private System.Windows.Forms.TrackBar ksBar;
        private System.Windows.Forms.TrackBar kdBar;
        private System.Windows.Forms.Button ChooseLightColor;
        private System.Windows.Forms.TextBox ksText;
        private System.Windows.Forms.ColorDialog LightColorChooser;
        private System.Windows.Forms.Timer FrameUpdateTimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar HeightBar;
        private System.Windows.Forms.CheckBox StopBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TrackBar mBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog ObjectColorChooser;
        private System.Windows.Forms.CheckBox GridBox;
        private System.Windows.Forms.GroupBox FillingBox;
        private System.Windows.Forms.RadioButton VectorInterpolationButton;
        private System.Windows.Forms.RadioButton ColorInterpolationButton;
        private System.Windows.Forms.RadioButton FillTriangleButton;
        private System.Windows.Forms.CheckBox FromTextureBox;
        private System.Windows.Forms.CheckBox NormalMapBox;
        private System.Windows.Forms.Button LoadMapButton;
        private System.Windows.Forms.Button LoadTextureButton;
        private System.Windows.Forms.OpenFileDialog TextureFileLoader;
        private System.Windows.Forms.OpenFileDialog MapFileLoader;
        private System.Windows.Forms.Button StepButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TrackBar cloudheightBar;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox CloudBox;
        private System.Windows.Forms.TrackBar kaBar;
        private System.Windows.Forms.TextBox kaBarasdsa;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TextBox textBox4;
    }
}


namespace NeuralNetwork
{
    partial class Form1
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
            this.RunButton = new System.Windows.Forms.Button();
            this.Train = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.elapsedLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.learningRateTextBox = new System.Windows.Forms.TextBox();
            this.trainLoopsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(13, 33);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // Train
            // 
            this.Train.Location = new System.Drawing.Point(12, 63);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(75, 23);
            this.Train.TabIndex = 1;
            this.Train.Text = "Train";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 151);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(415, 613);
            this.treeView1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(463, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(653, 613);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // elapsedLabel
            // 
            this.elapsedLabel.AutoSize = true;
            this.elapsedLabel.Location = new System.Drawing.Point(118, 128);
            this.elapsedLabel.Name = "elapsedLabel";
            this.elapsedLabel.Size = new System.Drawing.Size(13, 13);
            this.elapsedLabel.TabIndex = 7;
            this.elapsedLabel.Text = "0";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(13, 92);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // driverComboBox
            // 
            this.driverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverComboBox.FormattingEnabled = true;
            this.driverComboBox.Location = new System.Drawing.Point(166, 33);
            this.driverComboBox.Name = "driverComboBox";
            this.driverComboBox.Size = new System.Drawing.Size(347, 21);
            this.driverComboBox.TabIndex = 9;
            this.driverComboBox.SelectedIndexChanged += new System.EventHandler(this.driverComboBox_SelectedIndexChanged);
            // 
            // learningRateTextBox
            // 
            this.learningRateTextBox.Location = new System.Drawing.Point(576, 33);
            this.learningRateTextBox.Name = "learningRateTextBox";
            this.learningRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.learningRateTextBox.TabIndex = 10;
            // 
            // trainLoopsTextBox
            // 
            this.trainLoopsTextBox.Location = new System.Drawing.Point(576, 65);
            this.trainLoopsTextBox.Name = "trainLoopsTextBox";
            this.trainLoopsTextBox.Size = new System.Drawing.Size(100, 20);
            this.trainLoopsTextBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 794);
            this.Controls.Add(this.trainLoopsTextBox);
            this.Controls.Add(this.learningRateTextBox);
            this.Controls.Add(this.driverComboBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.elapsedLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.RunButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label elapsedLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.TextBox learningRateTextBox;
        private System.Windows.Forms.TextBox trainLoopsTextBox;
    }
}


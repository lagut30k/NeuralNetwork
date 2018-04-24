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
            this.TestButton = new System.Windows.Forms.Button();
            this.TrainButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftInputTextBox = new System.Windows.Forms.TextBox();
            this.rightInputTextBox = new System.Windows.Forms.TextBox();
            this.elapsedLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.learningRateTextBox = new System.Windows.Forms.TextBox();
            this.trainLoopsTextBox = new System.Windows.Forms.TextBox();
            this.layerDataGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.updateTreeCheckBox = new System.Windows.Forms.CheckBox();
            this.dropoutTextBox = new System.Windows.Forms.TextBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.dataComboBox = new System.Windows.Forms.ComboBox();
            this.classificationErrorLabel = new System.Windows.Forms.Label();
            this.meanSquaredErrorLabel = new System.Windows.Forms.Label();
            this.crossEntropyErrorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(13, 33);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Run";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(12, 63);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(75, 23);
            this.TrainButton.TabIndex = 1;
            this.TrainButton.Text = "Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 211);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(280, 613);
            this.treeView1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(298, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 300);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // leftInputTextBox
            // 
            this.leftInputTextBox.Location = new System.Drawing.Point(166, 65);
            this.leftInputTextBox.Name = "leftInputTextBox";
            this.leftInputTextBox.Size = new System.Drawing.Size(100, 20);
            this.leftInputTextBox.TabIndex = 4;
            // 
            // rightInputTextBox
            // 
            this.rightInputTextBox.Location = new System.Drawing.Point(166, 95);
            this.rightInputTextBox.Name = "rightInputTextBox";
            this.rightInputTextBox.Size = new System.Drawing.Size(100, 20);
            this.rightInputTextBox.TabIndex = 5;
            // 
            // elapsedLabel
            // 
            this.elapsedLabel.AutoSize = true;
            this.elapsedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elapsedLabel.Location = new System.Drawing.Point(36, 153);
            this.elapsedLabel.Name = "elapsedLabel";
            this.elapsedLabel.Size = new System.Drawing.Size(20, 24);
            this.elapsedLabel.TabIndex = 7;
            this.elapsedLabel.Text = "0";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(13, 92);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 2;
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
            this.driverComboBox.Size = new System.Drawing.Size(160, 21);
            this.driverComboBox.TabIndex = 9;
            // 
            // learningRateTextBox
            // 
            this.learningRateTextBox.Location = new System.Drawing.Point(372, 35);
            this.learningRateTextBox.Name = "learningRateTextBox";
            this.learningRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.learningRateTextBox.TabIndex = 10;
            // 
            // trainLoopsTextBox
            // 
            this.trainLoopsTextBox.Location = new System.Drawing.Point(372, 66);
            this.trainLoopsTextBox.Name = "trainLoopsTextBox";
            this.trainLoopsTextBox.Size = new System.Drawing.Size(100, 20);
            this.trainLoopsTextBox.TabIndex = 11;
            // 
            // layerDataGridView
            // 
            this.layerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.layerDataGridView.Location = new System.Drawing.Point(495, 33);
            this.layerDataGridView.Name = "layerDataGridView";
            this.layerDataGridView.Size = new System.Drawing.Size(271, 147);
            this.layerDataGridView.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(820, 211);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 295);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(298, 535);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(500, 302);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(820, 535);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(500, 302);
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // updateTreeCheckBox
            // 
            this.updateTreeCheckBox.AutoSize = true;
            this.updateTreeCheckBox.Location = new System.Drawing.Point(13, 188);
            this.updateTreeCheckBox.Name = "updateTreeCheckBox";
            this.updateTreeCheckBox.Size = new System.Drawing.Size(80, 17);
            this.updateTreeCheckBox.TabIndex = 19;
            this.updateTreeCheckBox.Text = "update tree";
            this.updateTreeCheckBox.UseVisualStyleBackColor = true;
            // 
            // dropoutTextBox
            // 
            this.dropoutTextBox.Location = new System.Drawing.Point(372, 94);
            this.dropoutTextBox.Name = "dropoutTextBox";
            this.dropoutTextBox.Size = new System.Drawing.Size(100, 20);
            this.dropoutTextBox.TabIndex = 20;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(13, 122);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 21;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // dataComboBox
            // 
            this.dataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataComboBox.FormattingEnabled = true;
            this.dataComboBox.Location = new System.Drawing.Point(166, 153);
            this.dataComboBox.Name = "dataComboBox";
            this.dataComboBox.Size = new System.Drawing.Size(160, 21);
            this.dataComboBox.TabIndex = 22;
            this.dataComboBox.SelectedIndexChanged += new System.EventHandler(this.dataComboBox_SelectedIndexChanged);
            // 
            // classificationErrorLabel
            // 
            this.classificationErrorLabel.AutoSize = true;
            this.classificationErrorLabel.Location = new System.Drawing.Point(959, 38);
            this.classificationErrorLabel.Name = "classificationErrorLabel";
            this.classificationErrorLabel.Size = new System.Drawing.Size(93, 13);
            this.classificationErrorLabel.TabIndex = 23;
            this.classificationErrorLabel.Text = "Classification Error";
            // 
            // meanSquaredErrorLabel
            // 
            this.meanSquaredErrorLabel.AutoSize = true;
            this.meanSquaredErrorLabel.Location = new System.Drawing.Point(959, 83);
            this.meanSquaredErrorLabel.Name = "meanSquaredErrorLabel";
            this.meanSquaredErrorLabel.Size = new System.Drawing.Size(102, 13);
            this.meanSquaredErrorLabel.TabIndex = 24;
            this.meanSquaredErrorLabel.Text = "Mean Squared Error";
            // 
            // crossEntropyErrorLabel
            // 
            this.crossEntropyErrorLabel.AutoSize = true;
            this.crossEntropyErrorLabel.Location = new System.Drawing.Point(959, 132);
            this.crossEntropyErrorLabel.Name = "crossEntropyErrorLabel";
            this.crossEntropyErrorLabel.Size = new System.Drawing.Size(96, 13);
            this.crossEntropyErrorLabel.TabIndex = 25;
            this.crossEntropyErrorLabel.Text = "Cross-entropy Error";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 866);
            this.Controls.Add(this.crossEntropyErrorLabel);
            this.Controls.Add(this.meanSquaredErrorLabel);
            this.Controls.Add(this.classificationErrorLabel);
            this.Controls.Add(this.dataComboBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.dropoutTextBox);
            this.Controls.Add(this.updateTreeCheckBox);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.layerDataGridView);
            this.Controls.Add(this.trainLoopsTextBox);
            this.Controls.Add(this.learningRateTextBox);
            this.Controls.Add(this.driverComboBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.elapsedLabel);
            this.Controls.Add(this.rightInputTextBox);
            this.Controls.Add(this.leftInputTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.TrainButton);
            this.Controls.Add(this.TestButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox leftInputTextBox;
        private System.Windows.Forms.TextBox rightInputTextBox;
        private System.Windows.Forms.Label elapsedLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.TextBox learningRateTextBox;
        private System.Windows.Forms.TextBox trainLoopsTextBox;
        private System.Windows.Forms.DataGridView layerDataGridView;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox updateTreeCheckBox;
        private System.Windows.Forms.TextBox dropoutTextBox;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ComboBox dataComboBox;
        private System.Windows.Forms.Label classificationErrorLabel;
        private System.Windows.Forms.Label meanSquaredErrorLabel;
        private System.Windows.Forms.Label crossEntropyErrorLabel;
    }
}


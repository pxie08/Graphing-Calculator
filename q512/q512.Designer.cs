namespace q512
{
    partial class q512
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
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.yEqual = new System.Windows.Forms.Label();
            this.eqTextBox = new System.Windows.Forms.TextBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.yAxis = new System.Windows.Forms.Label();
            this.xAxis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 20;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // yEqual
            // 
            this.yEqual.AutoSize = true;
            this.yEqual.Location = new System.Drawing.Point(26, 470);
            this.yEqual.Name = "yEqual";
            this.yEqual.Size = new System.Drawing.Size(26, 13);
            this.yEqual.TabIndex = 0;
            this.yEqual.Text = "Y = ";
            // 
            // eqTextBox
            // 
            this.eqTextBox.Location = new System.Drawing.Point(58, 467);
            this.eqTextBox.Name = "eqTextBox";
            this.eqTextBox.Size = new System.Drawing.Size(198, 20);
            this.eqTextBox.TabIndex = 1;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(262, 465);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 2;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(343, 465);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // yAxis
            // 
            this.yAxis.AutoSize = true;
            this.yAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yAxis.Location = new System.Drawing.Point(230, 9);
            this.yAxis.Name = "yAxis";
            this.yAxis.Size = new System.Drawing.Size(21, 20);
            this.yAxis.TabIndex = 4;
            this.yAxis.Text = "Y";
            // 
            // xAxis
            // 
            this.xAxis.AutoSize = true;
            this.xAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xAxis.Location = new System.Drawing.Point(440, 210);
            this.xAxis.Name = "xAxis";
            this.xAxis.Size = new System.Drawing.Size(21, 20);
            this.xAxis.TabIndex = 5;
            this.xAxis.Text = "X";
            // 
            // q512
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 562);
            this.Controls.Add(this.xAxis);
            this.Controls.Add(this.yAxis);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.eqTextBox);
            this.Controls.Add(this.yEqual);
            this.DoubleBuffered = true;
            this.Name = "q512";
            this.Text = "Quest 512 -- Patrick Xie";
            this.Load += new System.EventHandler(this.q512_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.q512_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Label yEqual;
        private System.Windows.Forms.TextBox eqTextBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label yAxis;
        private System.Windows.Forms.Label xAxis;
    }
}


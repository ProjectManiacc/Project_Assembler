namespace ArmstrongGUI
{
    partial class ArmstrongForm
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
            this.title = new System.Windows.Forms.Label();
            this.minNumberLabel = new System.Windows.Forms.Label();
            this.minNumberInput = new System.Windows.Forms.TextBox();
            this.minExponentInput = new System.Windows.Forms.TextBox();
            this.minExponentLabel = new System.Windows.Forms.Label();
            this.maxNumberInput = new System.Windows.Forms.TextBox();
            this.maxNumberLabel = new System.Windows.Forms.Label();
            this.maxExponentInput = new System.Windows.Forms.TextBox();
            this.maxExponentLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.Location = new System.Drawing.Point(299, 49);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(235, 50);
            this.title.TabIndex = 0;
            this.title.Text = "Armstrong Number";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // minNumberLabel
            // 
            this.minNumberLabel.AutoSize = true;
            this.minNumberLabel.Location = new System.Drawing.Point(155, 149);
            this.minNumberLabel.Name = "minNumberLabel";
            this.minNumberLabel.Size = new System.Drawing.Size(60, 13);
            this.minNumberLabel.TabIndex = 1;
            this.minNumberLabel.Text = "minNumber";
            // 
            // minNumberInput
            // 
            this.minNumberInput.Location = new System.Drawing.Point(221, 142);
            this.minNumberInput.Name = "minNumberInput";
            this.minNumberInput.Size = new System.Drawing.Size(100, 20);
            this.minNumberInput.TabIndex = 2;
            this.minNumberInput.Text = "1024";
            this.minNumberInput.TextChanged += new System.EventHandler(this.minNumberInput_TextChanged);
            // 
            // minExponentInput
            // 
            this.minExponentInput.Location = new System.Drawing.Point(569, 142);
            this.minExponentInput.Name = "minExponentInput";
            this.minExponentInput.Size = new System.Drawing.Size(100, 20);
            this.minExponentInput.TabIndex = 4;
            this.minExponentInput.TextChanged += new System.EventHandler(this.minExponentInput_TextChanged);
            // 
            // minExponentLabel
            // 
            this.minExponentLabel.AutoSize = true;
            this.minExponentLabel.Location = new System.Drawing.Point(495, 149);
            this.minExponentLabel.Name = "minExponentLabel";
            this.minExponentLabel.Size = new System.Drawing.Size(68, 13);
            this.minExponentLabel.TabIndex = 3;
            this.minExponentLabel.Text = "minExponent";
            // 
            // maxNumberInput
            // 
            this.maxNumberInput.Location = new System.Drawing.Point(221, 180);
            this.maxNumberInput.Name = "maxNumberInput";
            this.maxNumberInput.Size = new System.Drawing.Size(100, 20);
            this.maxNumberInput.TabIndex = 6;
            this.maxNumberInput.Text = "1024";
            // 
            // maxNumberLabel
            // 
            this.maxNumberLabel.AutoSize = true;
            this.maxNumberLabel.Location = new System.Drawing.Point(155, 187);
            this.maxNumberLabel.Name = "maxNumberLabel";
            this.maxNumberLabel.Size = new System.Drawing.Size(63, 13);
            this.maxNumberLabel.TabIndex = 5;
            this.maxNumberLabel.Text = "maxNumber";
            // 
            // maxExponentInput
            // 
            this.maxExponentInput.Location = new System.Drawing.Point(569, 180);
            this.maxExponentInput.Name = "maxExponentInput";
            this.maxExponentInput.Size = new System.Drawing.Size(100, 20);
            this.maxExponentInput.TabIndex = 8;
            // 
            // maxExponentLabel
            // 
            this.maxExponentLabel.AutoSize = true;
            this.maxExponentLabel.Location = new System.Drawing.Point(495, 187);
            this.maxExponentLabel.Name = "maxExponentLabel";
            this.maxExponentLabel.Size = new System.Drawing.Size(71, 13);
            this.maxExponentLabel.TabIndex = 7;
            this.maxExponentLabel.Text = "maxExponent";
            // 
            // calculateButton
            // 
            this.calculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.calculateButton.Location = new System.Drawing.Point(315, 227);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(206, 86);
            this.calculateButton.TabIndex = 9;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(48, 341);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(742, 192);
            this.outputText.TabIndex = 10;
            // 
            // ArmstrongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 572);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.maxExponentInput);
            this.Controls.Add(this.maxExponentLabel);
            this.Controls.Add(this.maxNumberInput);
            this.Controls.Add(this.maxNumberLabel);
            this.Controls.Add(this.minExponentInput);
            this.Controls.Add(this.minExponentLabel);
            this.Controls.Add(this.minNumberInput);
            this.Controls.Add(this.minNumberLabel);
            this.Controls.Add(this.title);
            this.Name = "ArmstrongForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ArmstrongForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label minNumberLabel;
        private System.Windows.Forms.TextBox minNumberInput;
        private System.Windows.Forms.TextBox minExponentInput;
        private System.Windows.Forms.Label minExponentLabel;
        private System.Windows.Forms.TextBox maxNumberInput;
        private System.Windows.Forms.Label maxNumberLabel;
        private System.Windows.Forms.TextBox maxExponentInput;
        private System.Windows.Forms.Label maxExponentLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox outputText;
    }
}


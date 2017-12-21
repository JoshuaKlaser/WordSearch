namespace Tester
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.btnClearWords = new System.Windows.Forms.Button();
            this.btnOriginalWords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 823);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 109);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(803, 143);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(880, 143);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(794, 159);
            this.txtWidth.MaxLength = 2;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(52, 20);
            this.txtWidth.TabIndex = 4;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(872, 159);
            this.txtHeight.MaxLength = 2;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(52, 20);
            this.txtHeight.TabIndex = 5;
            // 
            // txtWords
            // 
            this.txtWords.Location = new System.Drawing.Point(794, 273);
            this.txtWords.Multiline = true;
            this.txtWords.Name = "txtWords";
            this.txtWords.Size = new System.Drawing.Size(140, 213);
            this.txtWords.TabIndex = 6;
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(838, 257);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(38, 13);
            this.lblWords.TabIndex = 7;
            this.lblWords.Text = "Words";
            // 
            // btnClearWords
            // 
            this.btnClearWords.Location = new System.Drawing.Point(825, 513);
            this.btnClearWords.Name = "btnClearWords";
            this.btnClearWords.Size = new System.Drawing.Size(75, 23);
            this.btnClearWords.TabIndex = 8;
            this.btnClearWords.Text = "Clear Words";
            this.btnClearWords.UseVisualStyleBackColor = true;
            this.btnClearWords.Click += new System.EventHandler(this.btnClearWords_Click);
            // 
            // btnOriginalWords
            // 
            this.btnOriginalWords.Location = new System.Drawing.Point(806, 547);
            this.btnOriginalWords.Name = "btnOriginalWords";
            this.btnOriginalWords.Size = new System.Drawing.Size(118, 23);
            this.btnOriginalWords.TabIndex = 9;
            this.btnOriginalWords.Text = "Load Original Words";
            this.btnOriginalWords.UseVisualStyleBackColor = true;
            this.btnOriginalWords.Click += new System.EventHandler(this.btnOriginalWords_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 847);
            this.Controls.Add(this.btnOriginalWords);
            this.Controls.Add(this.btnClearWords);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.Button btnClearWords;
        private System.Windows.Forms.Button btnOriginalWords;
    }
}


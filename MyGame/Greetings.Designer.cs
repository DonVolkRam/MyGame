namespace MyGame
{
    partial class Greetings
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 100);
            this.button1.TabIndex = 0;
            this.button1.Text = "btnNewGame";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(242, 100);
            this.button2.TabIndex = 1;
            this.button2.Text = "btnRecord";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Greetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 471);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Greetings";
            this.Text = "Greetings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
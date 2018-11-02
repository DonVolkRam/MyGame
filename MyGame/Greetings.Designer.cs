using System.Drawing;

namespace MyGame
{
    partial class Greetings
    {
        /// <summary>
        /// крнекси графического буфера
        /// </summary>
        private static BufferedGraphicsContext _context;
        /// <summary>
        /// графический буфер
        /// </summary>
        public static BufferedGraphics Buffer;
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
            this.btn_Record = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(130, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Новая игра";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Record
            // 
            this.btn_Record.BackColor = System.Drawing.Color.Black;
            this.btn_Record.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Record.Location = new System.Drawing.Point(11, 51);
            this.btn_Record.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Record.Name = "btn_Record";
            this.btn_Record.Size = new System.Drawing.Size(115, 44);
            this.btn_Record.TabIndex = 1;
            this.btn_Record.Text = "Реорды";
            this.btn_Record.UseVisualStyleBackColor = false;
            this.btn_Record.Click += new System.EventHandler(this.btn_Record_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Black;
            this.btn_Exit.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Location = new System.Drawing.Point(249, 51);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(115, 44);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(125, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Автор: Волков Кирилл";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(111, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Космический Устранитель";
            // 
            // Greetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 101);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Record);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Greetings";
            this.Text = "Greetings";
            this.Shown += new System.EventHandler(this.Greetings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Record;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
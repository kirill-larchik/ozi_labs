namespace WindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EncryptionMessageTB = new System.Windows.Forms.TextBox();
            this.ResultTB = new System.Windows.Forms.TextBox();
            this.DecryptionMessageTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.encodingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Wheat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите сообщение, которое необходим дешифровать:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 61);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите сообщение, которое необходим зашифровать:";
            // 
            // EncryptionMessageTB
            // 
            this.EncryptionMessageTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.EncryptionMessageTB.Location = new System.Drawing.Point(12, 95);
            this.EncryptionMessageTB.Name = "EncryptionMessageTB";
            this.EncryptionMessageTB.Size = new System.Drawing.Size(383, 35);
            this.EncryptionMessageTB.TabIndex = 2;
            this.EncryptionMessageTB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EncryptionMessageTB_MouseDown);
            // 
            // ResultTB
            // 
            this.ResultTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.ResultTB.Location = new System.Drawing.Point(12, 394);
            this.ResultTB.Name = "ResultTB";
            this.ResultTB.ReadOnly = true;
            this.ResultTB.Size = new System.Drawing.Size(760, 35);
            this.ResultTB.TabIndex = 3;
            // 
            // DecryptionMessageTB
            // 
            this.DecryptionMessageTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.DecryptionMessageTB.Location = new System.Drawing.Point(12, 253);
            this.DecryptionMessageTB.Name = "DecryptionMessageTB";
            this.DecryptionMessageTB.Size = new System.Drawing.Size(383, 35);
            this.DecryptionMessageTB.TabIndex = 4;
            this.DecryptionMessageTB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DecryptionMessageTB_MouseDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Wheat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(12, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(760, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выходное сообщение";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Wheat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(456, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 35);
            this.label4.TabIndex = 6;
            this.label4.Text = "Режим кодировки";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 29;
            this.listBox.Location = new System.Drawing.Point(461, 108);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(276, 91);
            this.listBox.TabIndex = 7;
            // 
            // encodingButton
            // 
            this.encodingButton.BackColor = System.Drawing.Color.Tan;
            this.encodingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.encodingButton.Location = new System.Drawing.Point(461, 205);
            this.encodingButton.Name = "encodingButton";
            this.encodingButton.Size = new System.Drawing.Size(276, 42);
            this.encodingButton.TabIndex = 8;
            this.encodingButton.Text = "Закодировать сообщение.";
            this.encodingButton.UseVisualStyleBackColor = false;
            this.encodingButton.Click += new System.EventHandler(this.encodingButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.encodingButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DecryptionMessageTB);
            this.Controls.Add(this.ResultTB);
            this.Controls.Add(this.EncryptionMessageTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа N.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EncryptionMessageTB;
        private System.Windows.Forms.TextBox ResultTB;
        private System.Windows.Forms.TextBox DecryptionMessageTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button encodingButton;
    }
}


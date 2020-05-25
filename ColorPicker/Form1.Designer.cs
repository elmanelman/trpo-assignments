namespace ColorPicker
{
    partial class Form1
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
            this.LabelRed = new System.Windows.Forms.Label();
            this.LabelGreen = new System.Windows.Forms.Label();
            this.LabelBlue = new System.Windows.Forms.Label();
            this.TrackBarRed = new System.Windows.Forms.TrackBar();
            this.TrackBarGreen = new System.Windows.Forms.TrackBar();
            this.TrackBarBlue = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelRed
            // 
            this.LabelRed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelRed.AutoSize = true;
            this.LabelRed.Location = new System.Drawing.Point(204, 12);
            this.LabelRed.Name = "LabelRed";
            this.LabelRed.Size = new System.Drawing.Size(38, 17);
            this.LabelRed.TabIndex = 0;
            this.LabelRed.Text = "Red:";
            // 
            // LabelGreen
            // 
            this.LabelGreen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelGreen.AutoSize = true;
            this.LabelGreen.Location = new System.Drawing.Point(204, 74);
            this.LabelGreen.Name = "LabelGreen";
            this.LabelGreen.Size = new System.Drawing.Size(52, 17);
            this.LabelGreen.TabIndex = 1;
            this.LabelGreen.Text = "Green:";
            // 
            // LabelBlue
            // 
            this.LabelBlue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelBlue.AutoSize = true;
            this.LabelBlue.Location = new System.Drawing.Point(204, 136);
            this.LabelBlue.Name = "LabelBlue";
            this.LabelBlue.Size = new System.Drawing.Size(40, 17);
            this.LabelBlue.TabIndex = 2;
            this.LabelBlue.Text = "Blue:";
            // 
            // TrackBarRed
            // 
            this.TrackBarRed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TrackBarRed.Location = new System.Drawing.Point(262, 12);
            this.TrackBarRed.Maximum = 255;
            this.TrackBarRed.Name = "TrackBarRed";
            this.TrackBarRed.Size = new System.Drawing.Size(250, 56);
            this.TrackBarRed.TabIndex = 3;
            this.TrackBarRed.TickFrequency = 5;
            this.TrackBarRed.Value = 125;
            // 
            // TrackBarGreen
            // 
            this.TrackBarGreen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TrackBarGreen.Location = new System.Drawing.Point(262, 74);
            this.TrackBarGreen.Maximum = 255;
            this.TrackBarGreen.Name = "TrackBarGreen";
            this.TrackBarGreen.Size = new System.Drawing.Size(250, 56);
            this.TrackBarGreen.TabIndex = 4;
            this.TrackBarGreen.TickFrequency = 5;
            this.TrackBarGreen.Value = 125;
            // 
            // TrackBarBlue
            // 
            this.TrackBarBlue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TrackBarBlue.Location = new System.Drawing.Point(262, 136);
            this.TrackBarBlue.Maximum = 255;
            this.TrackBarBlue.Name = "TrackBarBlue";
            this.TrackBarBlue.Size = new System.Drawing.Size(250, 56);
            this.TrackBarBlue.TabIndex = 5;
            this.TrackBarBlue.TickFrequency = 5;
            this.TrackBarBlue.Value = 125;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 180);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 204);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TrackBarBlue);
            this.Controls.Add(this.TrackBarGreen);
            this.Controls.Add(this.TrackBarRed);
            this.Controls.Add(this.LabelBlue);
            this.Controls.Add(this.LabelGreen);
            this.Controls.Add(this.LabelRed);
            this.Name = "Form1";
            this.Text = "Color Picker";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelRed;
        private System.Windows.Forms.Label LabelGreen;
        private System.Windows.Forms.Label LabelBlue;
        private System.Windows.Forms.TrackBar TrackBarRed;
        private System.Windows.Forms.TrackBar TrackBarGreen;
        private System.Windows.Forms.TrackBar TrackBarBlue;
        private System.Windows.Forms.Panel panel1;
    }
}


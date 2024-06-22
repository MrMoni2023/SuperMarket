namespace SuperMarket
{
    partial class FrontForm
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
            this.panel_imt1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProgressBar_imtiaz = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_imt1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.ProgressBar_imtiaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_imt1
            // 
            this.panel_imt1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel_imt1.Controls.Add(this.label1);
            this.panel_imt1.Controls.Add(this.guna2PictureBox1);
            this.panel_imt1.Location = new System.Drawing.Point(-3, 1);
            this.panel_imt1.Name = "panel_imt1";
            this.panel_imt1.Size = new System.Drawing.Size(652, 86);
            this.panel_imt1.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::SuperMarket.Properties.Resources.icons8_mobile_order_80;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(38, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(80, 80);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "MULTI_VENDER SUPERMARKET STORE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(56, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "MVSS";
            // 
            // ProgressBar_imtiaz
            // 
            this.ProgressBar_imtiaz.Controls.Add(this.label2);
            this.ProgressBar_imtiaz.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.ProgressBar_imtiaz.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ProgressBar_imtiaz.ForeColor = System.Drawing.Color.White;
            this.ProgressBar_imtiaz.Location = new System.Drawing.Point(218, 126);
            this.ProgressBar_imtiaz.Minimum = 0;
            this.ProgressBar_imtiaz.Name = "ProgressBar_imtiaz";
            this.ProgressBar_imtiaz.ProgressColor = System.Drawing.Color.Goldenrod;
            this.ProgressBar_imtiaz.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ProgressBar_imtiaz.Size = new System.Drawing.Size(205, 205);
            this.ProgressBar_imtiaz.TabIndex = 2;
            this.ProgressBar_imtiaz.Text = "guna2CircleProgressBar1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.ProgressBar_imtiaz);
            this.Controls.Add(this.panel_imt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrontForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrontForm";
            this.Load += new System.EventHandler(this.FrontForm_Load);
            this.panel_imt1.ResumeLayout(false);
            this.panel_imt1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ProgressBar_imtiaz.ResumeLayout(false);
            this.ProgressBar_imtiaz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_imt1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleProgressBar ProgressBar_imtiaz;
        private System.Windows.Forms.Timer timer1;
    }
}
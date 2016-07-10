namespace ProgramTA
{
    partial class Tampil_CItra
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ComboboxZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.histogram1 = new AForge.Controls.Histogram();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nilaiaspect = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nilaimean = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nilaimedian = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nilaimin = new System.Windows.Forms.Label();
            this.nilaimax = new System.Windows.Forms.Label();
            this.bnykpixel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nilaistd = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComboboxZoom,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ComboboxZoom
            // 
            this.ComboboxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxZoom.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ComboboxZoom.Items.AddRange(new object[] {
            "200%",
            "150%",
            "100%",
            "75%",
            "50%",
            "25%"});
            this.ComboboxZoom.Name = "ComboboxZoom";
            this.ComboboxZoom.Size = new System.Drawing.Size(121, 25);
            this.ComboboxZoom.ToolTipText = "Zoom %";
            this.ComboboxZoom.SelectedIndexChanged += new System.EventHandler(this.ComboboxZoom_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ProgramTA.Properties.Resources.plus;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Zoom In";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ProgramTA.Properties.Resources.minus;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Zoom Out";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(13, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 491);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.mouse_enter);
            // 
            // histogram1
            // 
            this.histogram1.Location = new System.Drawing.Point(18, 19);
            this.histogram1.Name = "histogram1";
            this.histogram1.Size = new System.Drawing.Size(256, 150);
            this.histogram1.TabIndex = 2;
            this.histogram1.Text = "histogram1";
            this.histogram1.Values = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.histogram1);
            this.groupBox1.Location = new System.Drawing.Point(486, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Histogram";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 516);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Citra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Aspect Ratio";
            // 
            // nilaiaspect
            // 
            this.nilaiaspect.AutoSize = true;
            this.nilaiaspect.Location = new System.Drawing.Point(594, 221);
            this.nilaiaspect.Name = "nilaiaspect";
            this.nilaiaspect.Size = new System.Drawing.Size(35, 13);
            this.nilaiaspect.TabIndex = 6;
            this.nilaiaspect.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mean";
            // 
            // nilaimean
            // 
            this.nilaimean.AutoSize = true;
            this.nilaimean.Location = new System.Drawing.Point(594, 247);
            this.nilaimean.Name = "nilaimean";
            this.nilaimean.Size = new System.Drawing.Size(35, 13);
            this.nilaimean.TabIndex = 8;
            this.nilaimean.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Median";
            // 
            // nilaimedian
            // 
            this.nilaimedian.AutoSize = true;
            this.nilaimedian.Location = new System.Drawing.Point(594, 276);
            this.nilaimedian.Name = "nilaimedian";
            this.nilaimedian.Size = new System.Drawing.Size(35, 13);
            this.nilaimedian.TabIndex = 10;
            this.nilaimedian.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Pixels";
            // 
            // nilaimin
            // 
            this.nilaimin.AutoSize = true;
            this.nilaimin.Location = new System.Drawing.Point(594, 305);
            this.nilaimin.Name = "nilaimin";
            this.nilaimin.Size = new System.Drawing.Size(35, 13);
            this.nilaimin.TabIndex = 14;
            this.nilaimin.Text = "label9";
            // 
            // nilaimax
            // 
            this.nilaimax.AutoSize = true;
            this.nilaimax.Location = new System.Drawing.Point(594, 333);
            this.nilaimax.Name = "nilaimax";
            this.nilaimax.Size = new System.Drawing.Size(41, 13);
            this.nilaimax.TabIndex = 15;
            this.nilaimax.Text = "label10";
            // 
            // bnykpixel
            // 
            this.bnykpixel.AutoSize = true;
            this.bnykpixel.Location = new System.Drawing.Point(594, 361);
            this.bnykpixel.Name = "bnykpixel";
            this.bnykpixel.Size = new System.Drawing.Size(41, 13);
            this.bnykpixel.TabIndex = 16;
            this.bnykpixel.Text = "label11";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Std Dev";
            // 
            // nilaistd
            // 
            this.nilaistd.AutoSize = true;
            this.nilaistd.Location = new System.Drawing.Point(594, 389);
            this.nilaistd.Name = "nilaistd";
            this.nilaistd.Size = new System.Drawing.Size(35, 13);
            this.nilaistd.TabIndex = 18;
            this.nilaistd.Text = "label5";
            // 
            // Tampil_CItra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.nilaistd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bnykpixel);
            this.Controls.Add(this.nilaimax);
            this.Controls.Add(this.nilaimin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nilaimedian);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nilaimean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nilaiaspect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "Tampil_CItra";
            this.Text = "Tampil Citra";
            this.Load += new System.EventHandler(this.Tampil_CItra_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ComboboxZoom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AForge.Controls.Histogram histogram1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nilaiaspect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nilaimean;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nilaimedian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label nilaimin;
        private System.Windows.Forms.Label nilaimax;
        private System.Windows.Forms.Label bnykpixel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nilaistd;
    }
}
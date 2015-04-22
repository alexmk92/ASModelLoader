namespace ASLoader
{
    partial class ASWindow
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
            this.lblNormals = new System.Windows.Forms.Label();
            this.lblVertices = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectModel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.Panel();
            this.btnHiddenRemoval = new System.Windows.Forms.Button();
            this.colourPolys = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rotateZ = new System.Windows.Forms.HScrollBar();
            this.rotateY = new System.Windows.Forms.HScrollBar();
            this.rotateX = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.focal = new System.Windows.Forms.HScrollBar();
            this.scale = new System.Windows.Forms.HScrollBar();
            this.translateZ = new System.Windows.Forms.HScrollBar();
            this.translateY = new System.Windows.Forms.HScrollBar();
            this.translateX = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.originY = new System.Windows.Forms.HScrollBar();
            this.originX = new System.Windows.Forms.HScrollBar();
            this.panel1.SuspendLayout();
            this.canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.lblNormals);
            this.panel1.Controls.Add(this.lblVertices);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.selectModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 68);
            this.panel1.TabIndex = 0;
            // 
            // lblNormals
            // 
            this.lblNormals.AutoSize = true;
            this.lblNormals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormals.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblNormals.Location = new System.Drawing.Point(365, 21);
            this.lblNormals.Name = "lblNormals";
            this.lblNormals.Size = new System.Drawing.Size(100, 24);
            this.lblNormals.TabIndex = 3;
            this.lblNormals.Text = "# Normals:";
            // 
            // lblVertices
            // 
            this.lblVertices.AutoSize = true;
            this.lblVertices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVertices.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblVertices.Location = new System.Drawing.Point(222, 21);
            this.lblVertices.Name = "lblVertices";
            this.lblVertices.Size = new System.Drawing.Size(98, 24);
            this.lblVertices.TabIndex = 2;
            this.lblVertices.Text = "# Vertices:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Model";
            // 
            // selectModel
            // 
            this.selectModel.FormattingEnabled = true;
            this.selectModel.Location = new System.Drawing.Point(13, 34);
            this.selectModel.Name = "selectModel";
            this.selectModel.Size = new System.Drawing.Size(170, 21);
            this.selectModel.TabIndex = 0;
            this.selectModel.SelectedIndexChanged += new System.EventHandler(this.selectModel_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(988, 593);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Toggle Show Points";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.canvas.Controls.Add(this.label10);
            this.canvas.Controls.Add(this.label11);
            this.canvas.Controls.Add(this.originY);
            this.canvas.Controls.Add(this.originX);
            this.canvas.Controls.Add(this.btnHiddenRemoval);
            this.canvas.Controls.Add(this.button1);
            this.canvas.Controls.Add(this.colourPolys);
            this.canvas.Controls.Add(this.label7);
            this.canvas.Controls.Add(this.label8);
            this.canvas.Controls.Add(this.label9);
            this.canvas.Controls.Add(this.rotateZ);
            this.canvas.Controls.Add(this.rotateY);
            this.canvas.Controls.Add(this.rotateX);
            this.canvas.Controls.Add(this.label6);
            this.canvas.Controls.Add(this.label5);
            this.canvas.Controls.Add(this.label4);
            this.canvas.Controls.Add(this.label3);
            this.canvas.Controls.Add(this.label2);
            this.canvas.Controls.Add(this.btnDraw);
            this.canvas.Controls.Add(this.focal);
            this.canvas.Controls.Add(this.scale);
            this.canvas.Controls.Add(this.translateZ);
            this.canvas.Controls.Add(this.translateY);
            this.canvas.Controls.Add(this.translateX);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 68);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1239, 660);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // btnHiddenRemoval
            // 
            this.btnHiddenRemoval.Location = new System.Drawing.Point(760, 593);
            this.btnHiddenRemoval.Name = "btnHiddenRemoval";
            this.btnHiddenRemoval.Size = new System.Drawing.Size(108, 55);
            this.btnHiddenRemoval.TabIndex = 18;
            this.btnHiddenRemoval.Text = "Toggle Surface Removal";
            this.btnHiddenRemoval.UseVisualStyleBackColor = true;
            this.btnHiddenRemoval.Click += new System.EventHandler(this.btnHiddenRemoval_Click);
            // 
            // colourPolys
            // 
            this.colourPolys.Location = new System.Drawing.Point(874, 593);
            this.colourPolys.Name = "colourPolys";
            this.colourPolys.Size = new System.Drawing.Size(108, 55);
            this.colourPolys.TabIndex = 17;
            this.colourPolys.Text = "Toggle Poly Colour";
            this.colourPolys.UseVisualStyleBackColor = true;
            this.colourPolys.Click += new System.EventHandler(this.colourPolys_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(968, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Rotate Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(967, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Rotate Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(968, 357);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rotate X";
            // 
            // rotateZ
            // 
            this.rotateZ.Location = new System.Drawing.Point(1048, 430);
            this.rotateZ.Maximum = 360;
            this.rotateZ.Name = "rotateZ";
            this.rotateZ.Size = new System.Drawing.Size(168, 25);
            this.rotateZ.TabIndex = 11;
            this.rotateZ.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rotateZ_Scroll);
            // 
            // rotateY
            // 
            this.rotateY.Location = new System.Drawing.Point(1048, 394);
            this.rotateY.Maximum = 360;
            this.rotateY.Name = "rotateY";
            this.rotateY.Size = new System.Drawing.Size(168, 24);
            this.rotateY.TabIndex = 12;
            this.rotateY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rotateY_Scroll);
            // 
            // rotateX
            // 
            this.rotateX.Location = new System.Drawing.Point(1048, 357);
            this.rotateX.Maximum = 360;
            this.rotateX.Name = "rotateX";
            this.rotateX.Size = new System.Drawing.Size(168, 24);
            this.rotateX.TabIndex = 13;
            this.rotateX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rotateX_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(952, 555);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Translate Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(951, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Translate Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(952, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Translate X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(993, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Focal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(993, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scale";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(1102, 592);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(114, 56);
            this.btnDraw.TabIndex = 5;
            this.btnDraw.Text = "Force Redraw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // focal
            // 
            this.focal.Location = new System.Drawing.Point(1048, 282);
            this.focal.Maximum = 1000;
            this.focal.Minimum = 10;
            this.focal.Name = "focal";
            this.focal.Size = new System.Drawing.Size(168, 21);
            this.focal.TabIndex = 0;
            this.focal.Value = 400;
            this.focal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.focal_Scroll);
            // 
            // scale
            // 
            this.scale.Location = new System.Drawing.Point(1048, 313);
            this.scale.Maximum = 800;
            this.scale.Minimum = 10;
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(168, 23);
            this.scale.TabIndex = 1;
            this.scale.Value = 100;
            this.scale.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scale_Scroll);
            // 
            // translateZ
            // 
            this.translateZ.Location = new System.Drawing.Point(1048, 552);
            this.translateZ.Maximum = 1000;
            this.translateZ.Name = "translateZ";
            this.translateZ.Size = new System.Drawing.Size(168, 25);
            this.translateZ.TabIndex = 2;
            this.translateZ.Value = 400;
            this.translateZ.Scroll += new System.Windows.Forms.ScrollEventHandler(this.translateZ_Scroll);
            // 
            // translateY
            // 
            this.translateY.Location = new System.Drawing.Point(1048, 516);
            this.translateY.Maximum = 1000;
            this.translateY.Name = "translateY";
            this.translateY.Size = new System.Drawing.Size(168, 24);
            this.translateY.TabIndex = 3;
            this.translateY.Value = 50;
            this.translateY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.translateY_Scroll);
            // 
            // translateX
            // 
            this.translateX.Location = new System.Drawing.Point(1048, 479);
            this.translateX.Maximum = 1000;
            this.translateX.Name = "translateX";
            this.translateX.Size = new System.Drawing.Size(168, 24);
            this.translateX.TabIndex = 4;
            this.translateX.Value = 200;
            this.translateX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.translateX_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(975, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Origin Y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(975, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Origin X";
            // 
            // originY
            // 
            this.originY.Location = new System.Drawing.Point(1048, 57);
            this.originY.Maximum = 1000;
            this.originY.Name = "originY";
            this.originY.Size = new System.Drawing.Size(168, 24);
            this.originY.TabIndex = 19;
            this.originY.Value = 200;
            this.originY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.originY_Scroll);
            // 
            // originX
            // 
            this.originX.Location = new System.Drawing.Point(1048, 20);
            this.originX.Maximum = 1000;
            this.originX.Name = "originX";
            this.originX.Size = new System.Drawing.Size(168, 24);
            this.originX.TabIndex = 20;
            this.originX.Value = 200;
            this.originX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.originX_Scroll);
            // 
            // ASWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 728);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.Name = "ASWindow";
            this.Text = "ASLoader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.canvas.ResumeLayout(false);
            this.canvas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblNormals;
        private System.Windows.Forms.Label lblVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectModel;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.HScrollBar translateZ;
        private System.Windows.Forms.HScrollBar translateY;
        private System.Windows.Forms.HScrollBar translateX;
        private System.Windows.Forms.HScrollBar focal;
        private System.Windows.Forms.HScrollBar scale;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.HScrollBar rotateZ;
        private System.Windows.Forms.HScrollBar rotateY;
        private System.Windows.Forms.HScrollBar rotateX;
        private System.Windows.Forms.Button colourPolys;
        private System.Windows.Forms.Button btnHiddenRemoval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.HScrollBar originY;
        private System.Windows.Forms.HScrollBar originX;
    }
}


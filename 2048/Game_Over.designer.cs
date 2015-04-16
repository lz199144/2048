namespace _2048
{
    partial class Game_Over
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
            this.label1 = new System.Windows.Forms.Label();
            this.Again = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Screen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over!";
            // 
            // Again
            // 
            this.Again.BackColor = System.Drawing.SystemColors.Control;
            this.Again.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.Again.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.Again.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            this.Again.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.Again.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Again.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Again.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Again.Location = new System.Drawing.Point(-1, 176);
            this.Again.Margin = new System.Windows.Forms.Padding(0);
            this.Again.Name = "Again";
            this.Again.Size = new System.Drawing.Size(101, 51);
            this.Again.TabIndex = 1;
            this.Again.Text = "再来一次";
            this.Again.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button3.Location = new System.Drawing.Point(199, 176);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 51);
            this.button3.TabIndex = 3;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 5);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "分   数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(37, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "最高分：";
            // 
            // Screen
            // 
            this.Screen.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Screen.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.Screen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.Screen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.Screen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Screen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Screen.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Screen.Location = new System.Drawing.Point(97, 176);
            this.Screen.Margin = new System.Windows.Forms.Padding(0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(105, 51);
            this.Screen.TabIndex = 2;
            this.Screen.Text = "截图保存";
            this.Screen.UseVisualStyleBackColor = true;
            // 
            // Game_Over
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 224);
            this.ControlBox = false;
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Again);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game_Over";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Game_Over_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Again;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Screen;
    }
}
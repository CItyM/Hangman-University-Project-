namespace Hangman
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCateg = new System.Windows.Forms.Label();
            this.cbCateg = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLose = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picStart = new System.Windows.Forms.PictureBox();
            this.picTwoMis = new System.Windows.Forms.PictureBox();
            this.picOneMis = new System.Windows.Forms.PictureBox();
            this.picThreeMis = new System.Windows.Forms.PictureBox();
            this.picFourMis = new System.Windows.Forms.PictureBox();
            this.picFiveMis = new System.Windows.Forms.PictureBox();
            this.picSixMis = new System.Windows.Forms.PictureBox();
            this.picSevenMis = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwoMis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOneMis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThreeMis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFourMis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFiveMis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSixMis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSevenMis)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnAdd);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCateg
            // 
            resources.ApplyResources(this.lblCateg, "lblCateg");
            this.lblCateg.Name = "lblCateg";
            // 
            // cbCateg
            // 
            this.cbCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCateg, "cbCateg");
            this.cbCateg.FormattingEnabled = true;
            this.cbCateg.Name = "cbCateg";
            this.cbCateg.SelectedIndexChanged += new System.EventHandler(this.cbCateg_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblWin
            // 
            resources.ApplyResources(this.lblWin, "lblWin");
            this.lblWin.Name = "lblWin";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblLose
            // 
            resources.ApplyResources(this.lblLose, "lblLose");
            this.lblLose.Name = "lblLose";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Hangman.Properties.Resources.CTM_logo;
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // picStart
            // 
            this.picStart.Image = global::Hangman.Properties.Resources.main;
            resources.ApplyResources(this.picStart, "picStart");
            this.picStart.Name = "picStart";
            this.picStart.TabStop = false;
            // 
            // picTwoMis
            // 
            this.picTwoMis.Image = global::Hangman.Properties.Resources._2mistakes;
            resources.ApplyResources(this.picTwoMis, "picTwoMis");
            this.picTwoMis.Name = "picTwoMis";
            this.picTwoMis.TabStop = false;
            // 
            // picOneMis
            // 
            this.picOneMis.Image = global::Hangman.Properties.Resources._1mistake;
            resources.ApplyResources(this.picOneMis, "picOneMis");
            this.picOneMis.Name = "picOneMis";
            this.picOneMis.TabStop = false;
            // 
            // picThreeMis
            // 
            this.picThreeMis.Image = global::Hangman.Properties.Resources._3mistakes;
            resources.ApplyResources(this.picThreeMis, "picThreeMis");
            this.picThreeMis.Name = "picThreeMis";
            this.picThreeMis.TabStop = false;
            // 
            // picFourMis
            // 
            this.picFourMis.Image = global::Hangman.Properties.Resources._4mistakes;
            resources.ApplyResources(this.picFourMis, "picFourMis");
            this.picFourMis.Name = "picFourMis";
            this.picFourMis.TabStop = false;
            // 
            // picFiveMis
            // 
            this.picFiveMis.Image = global::Hangman.Properties.Resources._5mistakes;
            resources.ApplyResources(this.picFiveMis, "picFiveMis");
            this.picFiveMis.Name = "picFiveMis";
            this.picFiveMis.TabStop = false;
            // 
            // picSixMis
            // 
            this.picSixMis.Image = global::Hangman.Properties.Resources._6mistakes;
            resources.ApplyResources(this.picSixMis, "picSixMis");
            this.picSixMis.Name = "picSixMis";
            this.picSixMis.TabStop = false;
            // 
            // picSevenMis
            // 
            this.picSevenMis.Image = global::Hangman.Properties.Resources._7mistakes;
            resources.ApplyResources(this.picSevenMis, "picSevenMis");
            this.picSevenMis.Name = "picSevenMis";
            this.picSevenMis.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblLose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCateg);
            this.Controls.Add(this.cbCateg);
            this.Controls.Add(this.picStart);
            this.Controls.Add(this.picTwoMis);
            this.Controls.Add(this.picOneMis);
            this.Controls.Add(this.picThreeMis);
            this.Controls.Add(this.picFourMis);
            this.Controls.Add(this.picFiveMis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picSixMis);
            this.Controls.Add(this.picSevenMis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwoMis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOneMis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThreeMis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFourMis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFiveMis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSixMis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSevenMis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox picStart;
        private System.Windows.Forms.PictureBox picFiveMis;
        private System.Windows.Forms.PictureBox picFourMis;
        private System.Windows.Forms.PictureBox picThreeMis;
        private System.Windows.Forms.PictureBox picOneMis;
        private System.Windows.Forms.PictureBox picTwoMis;
        private System.Windows.Forms.PictureBox picSixMis;
        private System.Windows.Forms.PictureBox picSevenMis;
        private System.Windows.Forms.Label lblCateg;
        private System.Windows.Forms.ComboBox cbCateg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLose;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label5;
    }
}


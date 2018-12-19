namespace ReversiGame
{
    partial class ReversiForm
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
            this.checkBoxHelp = new System.Windows.Forms.CheckBox();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.textBoxSizeX = new System.Windows.Forms.TextBox();
            this.textBoxSizeY = new System.Windows.Forms.TextBox();
            this.labelSizeX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.labelScoreBlue = new System.Windows.Forms.Label();
            this.labelScoreRed = new System.Windows.Forms.Label();
            this.labelGameState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxHelp
            // 
            this.checkBoxHelp.AutoSize = true;
            this.checkBoxHelp.Location = new System.Drawing.Point(517, 54);
            this.checkBoxHelp.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHelp.Name = "checkBoxHelp";
            this.checkBoxHelp.Size = new System.Drawing.Size(148, 21);
            this.checkBoxHelp.TabIndex = 0;
            this.checkBoxHelp.Text = "Show Legal Moves";
            this.checkBoxHelp.UseVisualStyleBackColor = true;
            this.checkBoxHelp.CheckedChanged += new System.EventHandler(this.checkBoxHelp_CheckedChanged);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(389, 38);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(100, 28);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // textBoxSizeX
            // 
            this.textBoxSizeX.Location = new System.Drawing.Point(205, 34);
            this.textBoxSizeX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSizeX.Name = "textBoxSizeX";
            this.textBoxSizeX.Size = new System.Drawing.Size(132, 22);
            this.textBoxSizeX.TabIndex = 2;
            // 
            // textBoxSizeY
            // 
            this.textBoxSizeY.Location = new System.Drawing.Point(205, 66);
            this.textBoxSizeY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSizeY.Name = "textBoxSizeY";
            this.textBoxSizeY.Size = new System.Drawing.Size(132, 22);
            this.textBoxSizeY.TabIndex = 3;
            // 
            // labelSizeX
            // 
            this.labelSizeX.AutoSize = true;
            this.labelSizeX.Location = new System.Drawing.Point(105, 38);
            this.labelSizeX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSizeX.Name = "labelSizeX";
            this.labelSizeX.Size = new System.Drawing.Size(90, 17);
            this.labelSizeX.TabIndex = 4;
            this.labelSizeX.Text = "Board Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Board Height:";
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(389, 74);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(100, 28);
            this.buttonUndo.TabIndex = 6;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(834, 80);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(66, 17);
            this.labelTest.TabIndex = 8;
            this.labelTest.Text = "labelTest";
            // 
            // labelScoreBlue
            // 
            this.labelScoreBlue.AutoSize = true;
            this.labelScoreBlue.Location = new System.Drawing.Point(746, 59);
            this.labelScoreBlue.Name = "labelScoreBlue";
            this.labelScoreBlue.Size = new System.Drawing.Size(77, 17);
            this.labelScoreBlue.TabIndex = 9;
            this.labelScoreBlue.Text = "Score Blue";
            // 
            // labelScoreRed
            // 
            this.labelScoreRed.AutoSize = true;
            this.labelScoreRed.Location = new System.Drawing.Point(746, 80);
            this.labelScoreRed.Name = "labelScoreRed";
            this.labelScoreRed.Size = new System.Drawing.Size(75, 17);
            this.labelScoreRed.TabIndex = 10;
            this.labelScoreRed.Text = "Score Red";
            // 
            // labelGameState
            // 
            this.labelGameState.AutoSize = true;
            this.labelGameState.Location = new System.Drawing.Point(895, 26);
            this.labelGameState.Name = "labelGameState";
            this.labelGameState.Size = new System.Drawing.Size(79, 17);
            this.labelGameState.TabIndex = 11;
            this.labelGameState.Text = "GameState";
            // 
            // ReversiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelGameState);
            this.Controls.Add(this.labelScoreRed);
            this.Controls.Add(this.labelScoreBlue);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSizeX);
            this.Controls.Add(this.textBoxSizeY);
            this.Controls.Add(this.textBoxSizeX);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.checkBoxHelp);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReversiForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxHelp;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.TextBox textBoxSizeX;
        private System.Windows.Forms.TextBox textBoxSizeY;
        private System.Windows.Forms.Label labelSizeX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Label labelScoreBlue;
        private System.Windows.Forms.Label labelScoreRed;
        private System.Windows.Forms.Label labelGameState;
    }
}


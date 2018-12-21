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
            this.textBoxBoardWidth = new System.Windows.Forms.TextBox();
            this.textBoxBoardHeight = new System.Windows.Forms.TextBox();
            this.labelBoardWidth = new System.Windows.Forms.Label();
            this.labelBoardHeight = new System.Windows.Forms.Label();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.labelScoreBlue = new System.Windows.Forms.Label();
            this.labelScoreRed = new System.Windows.Forms.Label();
            this.labelGameState = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxHelp
            // 
            this.checkBoxHelp.AutoSize = true;
            this.checkBoxHelp.Location = new System.Drawing.Point(459, 58);
            this.checkBoxHelp.Name = "checkBoxHelp";
            this.checkBoxHelp.Size = new System.Drawing.Size(117, 17);
            this.checkBoxHelp.TabIndex = 0;
            this.checkBoxHelp.Text = "Show Legal Moves";
            this.checkBoxHelp.UseVisualStyleBackColor = true;
            this.checkBoxHelp.CheckedChanged += new System.EventHandler(this.checkBoxHelp_CheckedChanged);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(365, 21);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // textBoxBoardWidth
            // 
            this.textBoxBoardWidth.Location = new System.Drawing.Point(243, 24);
            this.textBoxBoardWidth.Name = "textBoxBoardWidth";
            this.textBoxBoardWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxBoardWidth.TabIndex = 2;
            // 
            // textBoxBoardHeight
            // 
            this.textBoxBoardHeight.Location = new System.Drawing.Point(243, 50);
            this.textBoxBoardHeight.Name = "textBoxBoardHeight";
            this.textBoxBoardHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxBoardHeight.TabIndex = 3;
            // 
            // labelBoardWidth
            // 
            this.labelBoardWidth.AutoSize = true;
            this.labelBoardWidth.Location = new System.Drawing.Point(158, 57);
            this.labelBoardWidth.Name = "labelBoardWidth";
            this.labelBoardWidth.Size = new System.Drawing.Size(69, 13);
            this.labelBoardWidth.TabIndex = 4;
            this.labelBoardWidth.Text = "Board Width:";
            // 
            // labelBoardHeight
            // 
            this.labelBoardHeight.AutoSize = true;
            this.labelBoardHeight.Location = new System.Drawing.Point(143, 31);
            this.labelBoardHeight.Name = "labelBoardHeight";
            this.labelBoardHeight.Size = new System.Drawing.Size(72, 13);
            this.labelBoardHeight.TabIndex = 5;
            this.labelBoardHeight.Text = "Board Height:";
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(365, 52);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 6;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(11, 9);
            this.labelTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(50, 13);
            this.labelTest.TabIndex = 8;
            this.labelTest.Text = "labelTest";
            // 
            // labelScoreBlue
            // 
            this.labelScoreBlue.AutoSize = true;
            this.labelScoreBlue.Location = new System.Drawing.Point(637, 31);
            this.labelScoreBlue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreBlue.Name = "labelScoreBlue";
            this.labelScoreBlue.Size = new System.Drawing.Size(59, 13);
            this.labelScoreBlue.TabIndex = 9;
            this.labelScoreBlue.Text = "Score Blue";
            // 
            // labelScoreRed
            // 
            this.labelScoreRed.AutoSize = true;
            this.labelScoreRed.Location = new System.Drawing.Point(638, 62);
            this.labelScoreRed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreRed.Name = "labelScoreRed";
            this.labelScoreRed.Size = new System.Drawing.Size(58, 13);
            this.labelScoreRed.TabIndex = 10;
            this.labelScoreRed.Text = "Score Red";
            // 
            // labelGameState
            // 
            this.labelGameState.AutoSize = true;
            this.labelGameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameState.Location = new System.Drawing.Point(484, 27);
            this.labelGameState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGameState.Name = "labelGameState";
            this.labelGameState.Size = new System.Drawing.Size(69, 13);
            this.labelGameState.TabIndex = 11;
            this.labelGameState.Text = "GameState";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(607, 13);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(35, 13);
            this.labelScore.TabIndex = 12;
            this.labelScore.Text = "Score";
            // 
            // ReversiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelGameState);
            this.Controls.Add(this.labelScoreRed);
            this.Controls.Add(this.labelScoreBlue);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.labelBoardHeight);
            this.Controls.Add(this.labelBoardWidth);
            this.Controls.Add(this.textBoxBoardHeight);
            this.Controls.Add(this.textBoxBoardWidth);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.checkBoxHelp);
            this.Name = "ReversiForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxHelp;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.TextBox textBoxBoardWidth;
        private System.Windows.Forms.TextBox textBoxBoardHeight;
        private System.Windows.Forms.Label labelBoardWidth;
        private System.Windows.Forms.Label labelBoardHeight;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Label labelScoreBlue;
        private System.Windows.Forms.Label labelScoreRed;
        private System.Windows.Forms.Label labelGameState;
        private System.Windows.Forms.Label labelScore;
    }
}


namespace _2048WinFormsApp
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelCell = new Label();
            ButtinExit = new Button();
            ButtionRestart = new Button();
            ButtonRulesGame = new Button();
            LabelBorder = new Label();
            LabelViewRecord = new Label();
            LabelVeiwScore = new Label();
            tableLayoutPanelField = new TableLayoutPanel();
            labelScore = new Label();
            labelRecord = new Label();
            SuspendLayout();
            // 
            // LabelCell
            // 
            LabelCell.AutoSize = true;
            LabelCell.BackColor = SystemColors.WindowText;
            LabelCell.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCell.Location = new Point(855, 122);
            LabelCell.MinimumSize = new Size(100, 100);
            LabelCell.Name = "LabelCell";
            LabelCell.Size = new Size(100, 100);
            LabelCell.TabIndex = 0;
            LabelCell.Text = "0";
            LabelCell.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtinExit
            // 
            ButtinExit.BackColor = SystemColors.WindowText;
            ButtinExit.ForeColor = SystemColors.Window;
            ButtinExit.Location = new Point(1041, 750);
            ButtinExit.Name = "ButtinExit";
            ButtinExit.Size = new Size(225, 75);
            ButtinExit.TabIndex = 8;
            ButtinExit.Text = "Выход";
            ButtinExit.UseVisualStyleBackColor = false;
            ButtinExit.Click += ButtonExit_Click;
            // 
            // ButtionRestart
            // 
            ButtionRestart.BackColor = SystemColors.WindowText;
            ButtionRestart.ForeColor = SystemColors.Window;
            ButtionRestart.Location = new Point(1041, 250);
            ButtionRestart.Name = "ButtionRestart";
            ButtionRestart.Size = new Size(225, 75);
            ButtionRestart.TabIndex = 9;
            ButtionRestart.Text = "Переиграть";
            ButtionRestart.UseVisualStyleBackColor = false;
            ButtionRestart.Click += ButtionRestart_Click;
            // 
            // ButtonRulesGame
            // 
            ButtonRulesGame.BackColor = SystemColors.WindowText;
            ButtonRulesGame.ForeColor = SystemColors.Window;
            ButtonRulesGame.Location = new Point(1041, 500);
            ButtonRulesGame.Name = "ButtonRulesGame";
            ButtonRulesGame.Size = new Size(225, 75);
            ButtonRulesGame.TabIndex = 10;
            ButtonRulesGame.Text = "Правила игры";
            ButtonRulesGame.UseVisualStyleBackColor = false;
            ButtonRulesGame.Click += ButtonRulesGame_Click;
            // 
            // LabelBorder
            // 
            LabelBorder.BackColor = SystemColors.WindowText;
            LabelBorder.ForeColor = SystemColors.WindowText;
            LabelBorder.Location = new Point(1000, 10);
            LabelBorder.Name = "LabelBorder";
            LabelBorder.Size = new Size(10, 925);
            LabelBorder.TabIndex = 11;
            // 
            // LabelViewRecord
            // 
            LabelViewRecord.AutoSize = true;
            LabelViewRecord.ForeColor = SystemColors.WindowText;
            LabelViewRecord.Location = new Point(600, 40);
            LabelViewRecord.Name = "LabelViewRecord";
            LabelViewRecord.Size = new Size(78, 25);
            LabelViewRecord.TabIndex = 12;
            LabelViewRecord.Text = "Рекорд:";
            // 
            // LabelVeiwScore
            // 
            LabelVeiwScore.AutoSize = true;
            LabelVeiwScore.ForeColor = SystemColors.WindowText;
            LabelVeiwScore.Location = new Point(200, 40);
            LabelVeiwScore.Name = "LabelVeiwScore";
            LabelVeiwScore.Size = new Size(61, 25);
            LabelVeiwScore.TabIndex = 13;
            LabelVeiwScore.Text = "Очки:";
            // 
            // tableLayoutPanelField
            // 
            tableLayoutPanelField.AutoScroll = true;
            tableLayoutPanelField.AutoSize = true;
            tableLayoutPanelField.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            tableLayoutPanelField.ColumnCount = 4;
            tableLayoutPanelField.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelField.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelField.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelField.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelField.Location = new Point(300, 250);
            tableLayoutPanelField.MinimumSize = new Size(100, 100);
            tableLayoutPanelField.Name = "tableLayoutPanelField";
            tableLayoutPanelField.RowCount = 4;
            tableLayoutPanelField.RowStyles.Add(new RowStyle());
            tableLayoutPanelField.RowStyles.Add(new RowStyle());
            tableLayoutPanelField.RowStyles.Add(new RowStyle());
            tableLayoutPanelField.RowStyles.Add(new RowStyle());
            tableLayoutPanelField.Size = new Size(300, 300);
            tableLayoutPanelField.TabIndex = 19;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.ForeColor = SystemColors.WindowText;
            labelScore.Location = new Point(267, 40);
            labelScore.MinimumSize = new Size(100, 25);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(100, 25);
            labelScore.TabIndex = 20;
            labelScore.Text = "0";
            // 
            // labelRecord
            // 
            labelRecord.AutoSize = true;
            labelRecord.ForeColor = SystemColors.WindowText;
            labelRecord.Location = new Point(684, 40);
            labelRecord.MinimumSize = new Size(100, 25);
            labelRecord.Name = "labelRecord";
            labelRecord.Size = new Size(100, 25);
            labelRecord.TabIndex = 21;
            labelRecord.Text = "0";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1278, 944);
            Controls.Add(labelRecord);
            Controls.Add(labelScore);
            Controls.Add(tableLayoutPanelField);
            Controls.Add(LabelVeiwScore);
            Controls.Add(LabelViewRecord);
            Controls.Add(LabelBorder);
            Controls.Add(ButtonRulesGame);
            Controls.Add(ButtionRestart);
            Controls.Add(ButtinExit);
            Controls.Add(LabelCell);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.Window;
            Margin = new Padding(5);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            Load += GameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelCell;
        private Button ButtinExit;
        private Button ButtionRestart;
        private Button ButtonRulesGame;
        private Label LabelBorder;
        private Label LabelViewRecord;
        private Label LabelVeiwScore;
        private TableLayoutPanel tableLayoutPanelField;
        private Label labelScore;
        private Label labelRecord;
    }
}

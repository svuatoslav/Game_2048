using System.Drawing;

namespace _2048WinFormsApp
{
    public partial class GameForm : Form
    {
        public static Game Game { get; private set; }
        private Player _player;
        private Label[,] _labelCells;
        private bool _gameStatus = true;

        public GameForm()
        {
            InitializeComponent();
            //System.Drawing.KnownColor;
            var w = SystemColors.InactiveCaptionText;
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += GameForm_KeyDown;

            InitializeGame();

            _player = new Player(Name = "Undefined");

            LoadData();
        }

        private void InitializeGame(int rows = 4, int columns = 4)
        {
            Game = new Game(rows, columns);

            GenerateGameField(LabelCell, tableLayoutPanelField, rows, columns);
            //FieldGeneration(LabelCell, rows, columns);

            this.Controls.Remove(LabelCell);

            Helper.GenerateNewNumber(tableLayoutPanelField.Controls.OfType<Label>().Where(label => label.Text == "0").ToList());
        }
        
        private void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!_gameStatus)
            {
                MessageBox.Show("Игра окончена");
                return;
            }

            _player.Move(e.KeyCode);
            e.Handled = true;
        }

        private void GenerateGameField(Label exemplar, int rows, int columns,
            int startX = 200,
            int startY = 200,
            int spacing = 100)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var label = CloneLabel(exemplar);
                    label.Name = $"LabelCell_{row}_{col}";
                    label.Location = CalculatePosition(row, col, startX, startY, spacing, exemplar.Width, exemplar.Height);
                    Controls.Add(label);

                    _labelCells[row, col] = label;
                }
            }
        }

        private void GenerateGameField(Label template, TableLayoutPanel panel, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var label = CloneLabel(template);
                    label.Name = $"LabelCell_{row}_{col}";

                    panel.Controls.Add(CloneLabel(LabelCell), col, row);
                }
            }
        }

        public static Label CloneLabel(Label original)
        {
            return new Label
            {
                BackColor = original.BackColor,
                Font = (Font)original.Font.Clone(),
                Size = original.Size,
                Text = original.Text,
                TextAlign = original.TextAlign,
                MinimumSize = original.MinimumSize,
                AutoSize = original.AutoSize
            };
        }

        private Point CalculatePosition(
            int row,
            int col,
            int startX,
            int startY,
            int spacing,
            int cellWidth,
            int cellHeight)
        {
            return new Point(
                    x: startX + col * (cellWidth + spacing),
                    y: startY + row * (cellHeight + spacing));
        }


        private void SaveData(int score) => JSONManager.WriteJSON(StoragePath.ProjectPath, score); 
        
        private void LoadData()
        {
            var record = JSONManager.ReadJSON<int>(StoragePath.ProjectPath);
            _player.BestResult = record ?? default;
            labelRecord.Text = record.ToString() ?? "0";
        }

        private void CheckStatusGame()
        {
            var emptyCells = tableLayoutPanelField.Controls.OfType<Label>().Where(label => label.Text == "0").ToList();

            if (emptyCells.Count == 0)
            {
                _gameStatus = false;
                SaveData(int.Parse(labelRecord.Text));
                MessageBox.Show("Игра окончена");
            }
            else
                Helper.GenerateNewNumber(emptyCells);
        }

        internal void ChangingGamePoints(int count)
        {
            if (int.TryParse(labelScore.Text, out int score))
            {
                labelScore.Text = (score + count).ToString();
                if (int.TryParse(labelRecord.Text, out int record))
                    if (record < int.Parse(labelScore.Text))
                        labelRecord.Text = labelScore.Text; // из-за ссылки при перезапуске
            }
        }
        private void RestartGame()
        {
            _gameStatus = true;
            labelScore.Text = "0";

            foreach (Label tile in tableLayoutPanelField.Controls)
                tile.Text = "0";

            Helper.GenerateNewNumber(tableLayoutPanelField.Controls.OfType<Label>().Where(label => label.Text == "0").ToList());
        }

        private void ButtionRestart_Click(object sender, EventArgs e) => RestartGame();

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            SaveData(int.Parse(labelRecord.Text));
            Application.Exit();
        }

        private void ButtonRulesGame_Click(object sender, EventArgs e)
        {
            var rulesForm = new RulesGameForm();
            rulesForm.ShowDialog();
        }
    }
}

using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public class Game
    {
        private GameForm _form;
        private List<Label> _labels;
        private TableLayoutPanel _tableLayoutPanelField;
        private bool _gameStatus = true;

        public Game(int rows = 4, int columns = 4)
        {
            _labels = new List<Label>(Math.Max(rows, columns));
            //GenerateGameField(LabelCell, _tableLayoutPanelField, rows, columns);
        }

        internal void Load(Label label) => label.Text = JSONManager.ReadJSON<int>(StoragePath.ProjectPath)?.ToString() ?? "0";

        internal void CheckStatus()
        {
            var emptyCells = _tableLayoutPanelField.Controls.OfType<Label>().Where(label => label.Text == "0").ToList();

            if (emptyCells.Count == 0)
            {
                _gameStatus = false;
                // !!!!!!!!
                //SaveBestScore(int.Parse(labelRecord.Text));
                MessageBox.Show("Игра окончена");
            }
            else
                Helper.GenerateNewNumber(emptyCells);
        }

        internal void MoveRows(MoveDirection moveDirection)
        {
            int rows = _tableLayoutPanelField.RowCount;

            (int startColumn, int endColumn, int step) = moveDirection == MoveDirection.Forward
                ? (0, rows - 1, 1)
                : (rows - 1, 0, -1);

            for (int row = 0; row < rows; row++)
            {
                _labels.Clear();

                for (int col = startColumn; step > 0 ? col <= endColumn : col >= endColumn; col += step)
                    AddLabel(col, row);
                MoveValues(_labels);
            }
        }

        internal void MoveColomns(MoveDirection moveDirection)
        {
            int cols = _tableLayoutPanelField.ColumnCount;

            (int startRows, int endRows, int step) = moveDirection == MoveDirection.Forward
                ? (0, cols - 1, 1)
                : (cols - 1, 0, -1);

            for (int col = 0; col < cols; col++)
            {
                _labels.Clear();
                for (int row = startRows; step > 0 ? row <= endRows : row >= endRows; row += step)
                    AddLabel(col, row);
                MoveValues(_labels);
            }
        }

        private void AddLabel(int col, int row)
        {
            var control = _tableLayoutPanelField.GetControlFromPosition(col, row);
            if (control is Label label) 
                _labels.Add(label);
        }

        private void MoveValues(List<Label> labels) // <-
        {
            var filledCells = labels.Where(label => label.Text != "0").ToList();

            if (filledCells.Count > 1)
            {
                for (int i = 0; i < filledCells.Count - 1; i++)
                {
                    if (string.Equals(filledCells[i].Text, filledCells[i + 1].Text, StringComparison.Ordinal))
                    {
                        filledCells[i].Text = (int.Parse(filledCells[i].Text) * 2).ToString();
                        filledCells.RemoveAt(i + 1);

                        _form.ChangingGamePoints(int.Parse(filledCells[i].Text));
                    }
                }
            }

            for (int i = 0; i < labels.Count; i++)
                labels[i].Text = i < filledCells.Count
                    ? filledCells[i].Text
                    : labels[i].Text = "0";
        }

        internal void Restart(Player player)
        {
            _gameStatus = true;
            //labelScore.Text = "0";
            player.Score = 0;

            foreach (Label tile in _tableLayoutPanelField.Controls)
                tile.Text = "0";

            Helper.GenerateNewNumber(_tableLayoutPanelField.Controls.OfType<Label>().Where(label => label.Text == "0").ToList());
        }

        private bool CheckMerger()
        {
            return true;
        }

        internal bool Win()
        {
            foreach (Label tile in _tableLayoutPanelField.Controls)
                if (tile.Text == "2048")
                    return true;
            return false;
        }
    }
}

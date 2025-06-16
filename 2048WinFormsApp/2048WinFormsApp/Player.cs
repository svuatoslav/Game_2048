namespace _2048WinFormsApp
{
    public class Player
    {
        public int Score { get; set; }

        public string Name { get; init; }

        private int _bestResult;
        public int BestResult
        {
            get => _bestResult;
            set
            {
                if (value <= _bestResult) return;
                _bestResult = value;

                if (value > Record)
                    Record = value;
            }
        }

        private static int _record;
        public static int Record { 
            get => _record;
            private set
            {
                if (value <= _record) return;
                _record = value;
            }
        }

        private static List<Player> _players;

        public Player(string name)
        {
            Name = name;
        }

        //public static List<Player> Players { get => _players ??= JSONManager.ReadJSON<Player>(string.Empty) ?? new List<Player>(); }

        //public static void LoadPlayers(string jsonStoragePath) => _players ??= JSONManager.ReadJSON<Player>(jsonStoragePath) ?? new List<Player>();

        public void Move(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                case Keys.W:
                    GameForm.Game.MoveColomns(MoveDirection.Forward);
                    goto default;
                case Keys.Down:
                case Keys.S:
                    GameForm.Game.MoveColomns(MoveDirection.Backward);
                    goto default;
                case Keys.Left:
                case Keys.A:
                    GameForm.Game.MoveRows(MoveDirection.Forward);
                    goto default;
                case Keys.Right:
                case Keys.D:
                    GameForm.Game.MoveRows(MoveDirection.Backward);
                    goto default;
                default:
                    GameForm.Game.CheckStatus();
                    break;
            }
        }
        public void Save() => JSONManager.WriteJSON(StoragePath.ProjectPath, Record);
    }
}

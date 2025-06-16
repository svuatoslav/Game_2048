namespace _2048WinFormsApp
{
    public static class Helper
    {
        public static void GenerateNewNumber(List<Label> labels)
        {
            var rand = new Random();
            var index = rand.Next(0, labels.Count);

            if (rand.NextDouble() < 0.75)
                labels[index].Text = "2";
            else
                labels[index].Text = "4";
        }
    }
}

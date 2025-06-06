namespace GeniusIdiot.Common
{
    abstract public class BaseTest
    {
        public List<Question> Questions { get; protected set; }
        protected string _rootPathFiles;

        protected void CalculatingResults(User user, int countCorrectAnswers)
        {
            user.LevelKnowledge = GetDiagnosis(Questions.Count, countCorrectAnswers);
            user.BestResult = countCorrectAnswers;
        }

        protected static string GetDiagnosis(int countQuestions, int countCorrectAnswers)
        {
            Dictionary<double, string> diagnoses = GetDiagnoses(countQuestions);
            string diagnos = "гений";
            foreach (var score in diagnoses.Keys)
                if (countCorrectAnswers >= score)
                    diagnos = diagnoses[score];
                else
                    return diagnos;
            return diagnos;
        }

        protected static Dictionary<double, string> GetDiagnoses(int countQuestions) => new Dictionary<double, string>()
        {
            {0, "кретин"},
            {(double)countQuestions / 100 * 20, "идиот"},
            {(double)countQuestions / 100 * 40, "дурак"},
            {(double)countQuestions / 100 * 60, "нормальный"},
            {(double)countQuestions / 100 * 80, "талант"},
            {countQuestions, "гений"}
        };

        protected static void SaveResults(User user, string pathSave)
        {
            User.Users.Add(user);
            JSONManager.WriteJSON(pathSave, User.Users);
        }

        abstract protected void Interviewing(User user, int countCorrectAnswers = 0);

        abstract public void ShowResults(User user, int countCorrectAnswers, IMessage _message);
    }
}

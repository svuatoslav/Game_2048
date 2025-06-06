using System.Timers;

namespace GeniusIdiot.Common
{
    public class Test
    {
        private List<Question> _questions;
        private bool _time = true;
        private IMessage _message;
        private string _rootPathFiles;
        public Test(List<Question> questions, IMessage message, string rootPathFiles) 
        { 
            _questions = questions; 
            _message = message; 
            _rootPathFiles = rootPathFiles; 
        }
        public void Testing()
        {
            var user = FormFilling();

            Interviewing(user);

            SaveResults(user, _rootPathFiles);
        }
        public void Testing(User user)
        {
            Interviewing(user);

            SaveResults(user, _rootPathFiles);
        }
        private User FormFilling()
        {
            _message.Write("Заполните анкету.\nНапишите сначала фамилию, потом имя через Enter");

            var user = new User(_message.Read(), _message.Read());

            return user;
        }
        private void Interviewing(User user, int countCorrectAnswers = 0)
        {
            do
            {
                var timer = new System.Timers.Timer(10000);
                timer.Elapsed += OnTimerElapsed;
                timer.AutoReset = false;

                GeneralMethods.ShuffleList(_questions);

                for (int i = 0; i < _questions.Count; i++)
                {
                    _message.Write($"Вопрос под номером {i + 1}\nНа ответ 10 секунд.");
                    _message.Write(_questions[i].Text);
                    _time = true;
                    
                    timer.Start();
                    int? input = GeneralMethods.CheckInt(_message.Read(), ref _time, _message);
                    timer.Stop();

                    if (_time)
                        if (_questions[i].Answer == input)
                            countCorrectAnswers++;
                }

                CalculatingResults(user, countCorrectAnswers);

                ShowResults(user, countCorrectAnswers);

                _message.Write("Если хотите повторить напишите \"Yes\"");
            }
            while (_message.Read().ToLower() == "yes");
        }
        private void CalculatingResults(User user, int countCorrectAnswers)
        {
            user.LevelKnowledge = GetDiagnosis(_questions.Count, countCorrectAnswers);
            user.BestResult = countCorrectAnswers;
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _message.Write("Время истекло, нажмите Enter");
            _time = false;
        }
        public void ShowResults(User user, int countCorrectAnswers) => _message.Write(
            $"{user.LastName} {user.FirstName}, ваш диагноз: {user.LevelKnowledge} " +
            $"c {countCorrectAnswers} правильными ответами, Ваш лучший результат {user.BestResult}.");
        private static string GetDiagnosis(int countQuestions, int countCorrectAnswers)
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
        private static Dictionary<double, string> GetDiagnoses(int countQuestions) => new Dictionary<double, string>()
        {
            {0, "кретин"},
            {(double)countQuestions / 100 * 20, "идиот"},
            {(double)countQuestions / 100 * 40, "дурак"},
            {(double)countQuestions / 100 * 60, "нормальный"},
            {(double)countQuestions / 100 * 80, "талант"},
            {countQuestions, "гений"}
        };
        private static void SaveResults(User user, string pathSave)
        {
            User.Users.Add(user);
            XMLManager.WriteXML(pathSave, User.Users);
        }
    }
}
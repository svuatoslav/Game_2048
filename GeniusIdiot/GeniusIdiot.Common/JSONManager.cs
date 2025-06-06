using Newtonsoft.Json;

namespace GeniusIdiot.Common
{
    public static class JSONManager
    {
        public static void WriteJSON<T>(string path, List<T> data) where T : class
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            var fullPath = CreateFullPath(path, data[0]);

            try 
            { File.WriteAllText(fullPath, json); }
            catch (IOException ex) 
            { FileLogger.LogError($"Failed to write a file:\n{ex.Message}"); }
        }

        public static List<T>? ReadJSON<T>(string path) where T : class
        {
            List<T>? values = null;

            try
            {
                var filePath = CreateFullPath(path, typeof(T).Name);

                var file = File.ReadAllText(filePath);

                values = JsonConvert.DeserializeObject<List<T>>(file);
            }
            catch (IOException ex)
            {
                FileLogger.LogError($"The file could not be read:\n{ex.Message}");
                return values;
            }

            return values;
        }

        private static string CreateFullPath<T>(string path, T typeClass) => Path.Combine(path, typeClass is User ? "Users" : "Questions") + ".json";
        private static string CreateFullPath(string path, string typeClass) => Path.Combine(path, typeClass == "User" ? "Users" : "Questions") + ".json";
    }
}

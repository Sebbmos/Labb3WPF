using Labb3_NET22.DataModels;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Labb3_NET22
{
    public class FileManager
    {
        public static string Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SavedQuizes");

        public static async Task SaveQuiz(Quiz quiz)
        {
            Directory.CreateDirectory(Folder);
            string title = string.Join("_", quiz.Title.Split(Path.GetInvalidFileNameChars()));
            var path = Path.Combine(Folder, title + ".json");
            var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

    }
}

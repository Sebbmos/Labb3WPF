using Labb3_NET22.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Labb3_NET22
{
    public class FileManager
    {
        //public static string Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SavedQuizes");
        public static string Folder = Path.GetFullPath(
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuizJson")  //ny directory så att json sparas i repomappen
);
        public static async Task SaveQuiz(Quiz quiz)
        {
            Directory.CreateDirectory(Folder);
            string title = string.Join("_", quiz.Title.Split(Path.GetInvalidFileNameChars()));
            var path = Path.Combine(Folder, title + ".json");
            var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }
        public static async Task<Quiz?> LoadQuiz(string fullPath)
        {
            try
            {
                Directory.CreateDirectory(Folder);
                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("Filen hittades inte.");
                    return null;
                }
                await using var fp = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                return await JsonSerializer.DeserializeAsync<Quiz>(fp);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Kunde inte läsa filen.\n{ex.Message}");
                return null;
            }
        }

        public static IEnumerable<string> GetSavedQuizFiles()
        {
            Directory.CreateDirectory(Folder);
            return Directory.EnumerateFiles(Folder, "*.json");
        }
    }
}

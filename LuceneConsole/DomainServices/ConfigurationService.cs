using LuceneConsole.Entities;
using System.Text.Json;

namespace LuceneConsole.DomainServices
{
    internal static class ConfigurationService
    {
        private static string ConfigurationFilePath => Path.Combine(Path.GetTempPath(), "config.lucene.console");

        public static string GetLastFolder()
        {
            var configuration = new Configuration();

            if (!File.Exists(ConfigurationFilePath))
            {
                configuration.FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                CreateConfiguration(configuration);
            }

            string configurationFileContent = File.ReadAllText(ConfigurationFilePath);
            configuration = JsonSerializer.Deserialize<Configuration>(configurationFileContent);

            return configuration.FolderPath;
        }

        public static void UpdateLastFolder(string newFolderPath)
        {
            CreateConfiguration(new Configuration { FolderPath = newFolderPath });
        }

        private static void CreateConfiguration(Configuration configuration)
        {
            var serializedConfiguration = JsonSerializer.Serialize(configuration);
            File.WriteAllText(ConfigurationFilePath, serializedConfiguration);
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using Лаб_2;

namespace Лаб_2
{
    public static class RaceTransfer
    {
        public static void SaveJson(string path, List<RaceResult> data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }

        public static List<RaceResult> LoadJson(string path)
        {
            string json = File.ReadAllText(path);
            var result = JsonSerializer.Deserialize<List<RaceResult>>(json);
            return result ?? new List<RaceResult>();
        }

        public static void SaveXml(string path, List<RaceResult> data)
        {
            var serializer = new XmlSerializer(typeof(List<RaceResult>));
            using var stream = File.Create(path);
            serializer.Serialize(stream, data);
        }

        public static List<RaceResult> LoadXml(string path)
        {
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null
            };

            using var reader = XmlReader.Create(path, settings);
            var serializer = new XmlSerializer(typeof(List<RaceResult>));
            var result = serializer.Deserialize(reader) as List<RaceResult>;
            return result ?? new List<RaceResult>();
        }
    }
}
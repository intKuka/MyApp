using System.Text.Json;

namespace MyApp.Data
{
    public class JsonHandler<T> : IJsonHandler<T>
    {
        public string JsonPath { get; set; } = "";
        public void LoadJsonToList(List<T> listT)
        {
            using var fs = new FileStream(JsonPath, FileMode.OpenOrCreate, FileAccess.Read);
            if (fs.Length == 0) return;
            var list = JsonSerializer.Deserialize<List<T>>(fs);
            if(list == null) return;
            listT.AddRange(list);
        }

        public void DumpJsonFromList(List<T> listT)
        {
            using var fs = new FileStream(JsonPath, FileMode.Create);
            JsonSerializer.Serialize(fs, listT);

        }
    }
}

namespace MyApp.Data
{
    public interface IJsonHandler<T>
    {
        public string JsonPath { get; set; }

        public void LoadJsonToList(List<T> listT);
        public void DumpJsonFromList(List<T> listT);

    }
}

namespace ClientHandler.ClientHandlers
{
    public class SettingsFactoryOptions<T> where T : class
    {
        public string Name { get; set; }
        public T Settings { get; set; }

        public SettingsFactoryOptions(string name, T settings)
        {
            this.Name = name;
            this.Settings = settings;
        }
    }
}

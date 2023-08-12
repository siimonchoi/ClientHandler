namespace ClientHandler.ClientHandlers
{
    public class SettingsFactory<T> where T : class, new()
    {
        // concurrent dictionary?
        Dictionary<string, T> settingsRegistrations = new Dictionary<string, T>();

        public SettingsFactory(IEnumerable<SettingsFactoryOptions<T>> settingsOptions)
        {
            foreach (var settingsOption in settingsOptions)
            {
                settingsRegistrations.Add(settingsOption.Name, settingsOption.Settings);
            }
        }

        public T CreateSettings(string name)
        {
            if (settingsRegistrations.TryGetValue(name, out var settings))
            {
                return settings;
            }

            return new();   // default settings
        }
    }
}

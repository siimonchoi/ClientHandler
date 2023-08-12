namespace ClientHandler.ClientHandlers
{
    public class OutgoingRequestHandlerFactory
    {
        private SettingsFactory<OutgoingRequestHandlerSettings> settingsFactory;

        public OutgoingRequestHandlerFactory(SettingsFactory<OutgoingRequestHandlerSettings> settingsFactory)
        {
            this.settingsFactory = settingsFactory;
        }

        public OutgoingRequestHandler CreateHandler(string name)
        {
            var settings = this.settingsFactory.CreateSettings(name);

            return new OutgoingRequestHandler(settings);
        }
    }
}

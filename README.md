# ClientHandler

This project shows how you can register a global client handler that will be resolved with client specific settings. You dont need to manually register the handler for every client you are creating. You can just register the handler globally and provide the settings when setting up the client (the Pokedex client in this example).


This project registers a OutgoingRequestHandlerSettings for the typed client. When the HttpClientFactory will attempt to resolves the global handler OutgoingRequestHandler using the OutgoingRequestHandlerFactory. The OutgoingRequestHandlerFactory will use the SettingsFactory to resolve which settings has been registered for the client and create a OutgoingRequestHandler using the OutgoingRequestHandlerSettings that has been registered for the client.

todo: 
* default OutgoingRequestHandlerSettings if not settings has been registered.
* unit tests.



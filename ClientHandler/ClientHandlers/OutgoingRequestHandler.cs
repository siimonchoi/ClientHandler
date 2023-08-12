namespace ClientHandler.ClientHandlers
{
    public class OutgoingRequestHandler : DelegatingHandler
    {
        readonly OutgoingRequestHandlerSettings settings;
        public OutgoingRequestHandler(OutgoingRequestHandlerSettings settings)
        {
            this.settings = settings;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

                if (!string.IsNullOrWhiteSpace(settings.ResponseHeader))
                {
                    response.Headers.Add("ResponseHeader", settings.ResponseHeader);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

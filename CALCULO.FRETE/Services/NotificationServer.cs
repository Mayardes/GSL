using CALCULOFRETE.Model;
using CALCULOFRETE.Service;

namespace CALCULOFRETE.Services
{
    public interface INotificationServer<T>
    {
        Task NotifyUser(T model);
    }
    public class NotificationServer<T> : INotificationServer<T>
    {
        private readonly ClienteServices _clienteServices;
        public NotificationServer(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public async Task NotifyUser(T model)
        {
            await _clienteServices.CadastrarAsync(model as Cliente);
        }
    }
}

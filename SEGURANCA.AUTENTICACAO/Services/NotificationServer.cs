using SEGURANCAAUTENTICACAO.Model;
using SEGURANCAAUTENTICACAO.Service;

namespace SEGURANCAAUTENTICACAO.Services
{
    public interface INotificationServer<T>
    {
        Task NotifyUser(T model);
    }
    public class NotificationServer<T> : INotificationServer<T>
    {
        private readonly UsuarioServices _UsuarioServices;
        public NotificationServer(UsuarioServices UsuarioServices)
        {
            _UsuarioServices = UsuarioServices;
        }

        public async Task NotifyUser(T model)
        {
            await _UsuarioServices.CadastrarAsync(model as Usuario);
        }
    }
}

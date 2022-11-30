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
        private readonly ClienteServices _clienteServices;
        private readonly DepositoServices _depositoServices;
        private readonly FornecedorServices _fornecedorServices;
        private readonly MercadoriaServices _mercadoriaServices;
        public NotificationServer(ClienteServices clienteServices, DepositoServices depositoServices, FornecedorServices fornecedorServices, MercadoriaServices mercadoriaServices)
        {
            _clienteServices = clienteServices;
            _depositoServices = depositoServices;
            _fornecedorServices = fornecedorServices;
            _mercadoriaServices = mercadoriaServices;
        }

        public async Task NotifyUser(T model) 
        {
            if (model is Cliente)
                await _clienteServices.CadastrarAsync(model as Cliente);
            else
               if (model is Deposito)
                await _depositoServices.CadastrarAsync(model as Deposito);
            else
               if(model is Fornecedor)
                await _fornecedorServices.CadastrarAsync(model as Fornecedor);
            else 
               if(model is Mercadoria)
                await _mercadoriaServices.CadastrarAsync(model as Mercadoria);
        }
    }
}

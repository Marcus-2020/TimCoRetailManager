using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _events;
        private readonly SalesViewModel _salesVm;
        private readonly SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, 
            SalesViewModel salesVm, SimpleContainer container)
        {
            _events = events;
            _salesVm = salesVm;
            _container = container;

            _events.SubscribeOnPublishedThread(this);

            Task.Run(async () => 
                await ActivateItemAsync(_container.GetInstance<LoginViewModel>()));
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVm, cancellationToken);
        }
    }
}
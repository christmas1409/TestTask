using System.Collections.Generic;

namespace TextMessengerAPI.Web.Core
{
    public interface IDialogsRepository
    {
        IReadOnlyCollection<RGDialogsClients> Get();
    }

    public class DialogsRepository : IDialogsRepository
    {
        private static readonly List<RGDialogsClients> _dialogsClients = new RGDialogsClients().Init();

        public IReadOnlyCollection<RGDialogsClients> Get()
        {
            return _dialogsClients;
        }
    }
}

using System;
using System.Linq;
using TextMessengerAPI.Web.Core;

namespace TextMessengerAPI.Web.Features
{
    public interface IGetIDRGDialogQueryHandler
    {
        Guid Handle(GetIDRGDialogQuery query);
    }

    public class GetIDRGDialogQueryHandler : IGetIDRGDialogQueryHandler
    {
        private const string NotAnyClientExceptionMessage = "Пользователи не заданы";
        private readonly IDialogsRepository _dialogsRepository;

        public GetIDRGDialogQueryHandler(IDialogsRepository dialogsRepository)
        {
            _dialogsRepository = dialogsRepository;
        }

        public Guid Handle(GetIDRGDialogQuery query)
        {
            ThrowIfNotAnyClient(query);
            var dialogGroup = FindDialogGroup(query);
            return dialogGroup?.Key ?? Guid.Empty;
        }

        private static void ThrowIfNotAnyClient(GetIDRGDialogQuery query)
        {
            if (query.ClientIds == null || !query.ClientIds.Any())
            {
                throw new Exception(NotAnyClientExceptionMessage);
            }
        }

        private IGrouping<Guid, RGDialogsClients> FindDialogGroup(GetIDRGDialogQuery query)
        {
            return _dialogsRepository
                .Get()
                .GroupBy(o => o.IDRGDialog)
                .Where(dialog =>
                    query.ClientIds.All(q =>
                        dialog.Any(client => client.IDClient == q)))
                .ToList()
                .FirstOrDefault();
        }
    }
}

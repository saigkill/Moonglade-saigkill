using MediatR;

using Moonglade.Configuration;

namespace Moonglade.Notification.Client;

public record ContactNotification : INotification;

public class ContactNotificationHandler : INotificationHandler<ContactNotification>
{
    private readonly IMoongladeNotification _moongladeNotification;
    private readonly IBlogConfig _blogConfig;

    public ContactNotificationHandler(IMoongladeNotification moongladeNotification, IBlogConfig blogConfig)
    {
        _moongladeNotification = moongladeNotification;
        _blogConfig = blogConfig;
    }

    public async Task Handle(ContactNotification notification, CancellationToken ct)
    {
        var dl = new[] { _blogConfig.GeneralSettings.OwnerEmail };
        await _moongladeNotification.EnqueueNotification(MailMesageTypes.ContactNotification, dl, EmptyPayload.Default);
    }
}


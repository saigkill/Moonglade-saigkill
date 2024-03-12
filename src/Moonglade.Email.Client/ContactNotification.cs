using MediatR;

using Moonglade.Configuration;

namespace Moonglade.Email.Client
{
    public record ContactNotification(
    string Name,
    string Subject,
    string Email,
    string Body) : INotification;

    internal record ContactPayload(
        string Name,
        string Subject,
        string Email,
        string Body);

    public class ContactNotificationHandler(IMoongladeEmailClient moongladeEmailClient, IBlogConfig blogConfig) : INotificationHandler<ContactNotification>
    {
        public async Task Handle(ContactNotification notification, CancellationToken ct)
        {
            var dl = new[] { blogConfig.GeneralSettings.OwnerEmail };
            var payload = new ContactNotification(
                notification.Name,
                notification.Subject,
                notification.Email,
                notification.Body
            );


            await moongladeEmailClient.SendEmail(MailMesageTypes.NewCommentNotification, dl, payload);
        }
    }
}

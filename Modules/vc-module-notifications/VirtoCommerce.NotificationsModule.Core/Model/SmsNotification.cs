using System.Collections.Generic;
using VirtoCommerce.NotificationsModule.Core.Extensions;
using VirtoCommerce.NotificationsModule.Core.Services;

namespace VirtoCommerce.NotificationsModule.Core.Model
{
    /// <summary>
    /// Sms - Kind of Notification
    /// </summary>
    public class SmsNotification : Notification
    {
        public SmsNotification()
        {
            Kind = nameof(SmsNotification);
            Templates = new List<NotificationTemplate>();
        }

        /// <summary>
        /// Number for sms notification
        /// </summary>
        public string Number { get; set; }

        public override NotificationMessage ToMessage(NotificationMessage message, INotificationTemplateRender render)
        {
            var smsNotificationMessage = (SmsNotificationMessage) message;
            var template = (SmsNotificationTemplate)Templates.FindWithLanguage(message.LanguageCode);
            if (template != null)
            {
                smsNotificationMessage.Number = Number;
                smsNotificationMessage.Message = render.Render(template.Message, this);
            }
            
            return base.ToMessage(message, render);
        }
    }
}
using System.Collections.Generic;
using ChallengeMobills.Business.Notifications;

namespace ChallengeMobills.Business.Intefaces
{
    public interface INotify
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
// A class should have only one reason to change.
namespace SingleResponsibilityPrinciple
{
    namespace Bad_Example
    {
        public class PolicyHolderService
        {
            public bool UpdatePolicyHolderName()
            {
                throw new NotImplementedException();
            }

            public bool UpdatePolicyHolderDOB()
            {
                throw new NotImplementedException();
            }

            public bool MailPolicyHolderWithUpdatedData()
            {
                // Implementing all mailing things over here
                throw new NotImplementedException();
            }
        }
    }

    namespace Good_Example
    {
        public interface INotificationService
        {
            bool Mail();
        }

        public class PolicyHolderService
        {
            private readonly INotificationService _notificationService;

            public PolicyHolderService(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            public bool UpdatePolicyHolderName()
            {
                throw new NotImplementedException();
            }

            public bool UpdatePolicyHolderDOB()
            {
                throw new NotImplementedException();
            }

            public bool MailPolicyHolderWithUpdatedData()
            {
                // Get the data and delegate the Task to Notifcation Service
                return _notificationService.Mail();
            }
        }

        public class NotificationService : INotificationService
        {
            public bool Mail()
            {
                // Implementing all mailing things over here
                throw new NotImplementedException();
            }
        }
    }
}

// High-level modules should depend on abstractions, not concrete implementations.
namespace SOLID
{
    namespace DependencyInversionPrinciple
    {
        namespace Bad_Example
        {
            // Low-level module
            public class EmailNotificationService
            {
                public void SendEmail(string to, string message)
                {
                    // Send email implementation
                }
            }

            // Low-level module
            public class SMSNotificationService
            {
                public void SendSMS(string to, string message)
                {
                    // Send SMS implementation
                }
            }

            // High-level module directly depends on low-level concrete classes
            public class PolicyHolderService
            {
                private readonly EmailNotificationService _emailService = new EmailNotificationService(); // ❌ Concrete dependency
                private readonly SMSNotificationService _smsService = new SMSNotificationService();       // ❌ Concrete dependency

                public void NotifyPolicyHolder(string to, string message)
                {
                    _emailService.SendEmail(to, message);  // ❌ Tightly coupled
                    _smsService.SendSMS(to, message);      // ❌ Tightly coupled
                }
            }
        }

        namespace Good_Example
        {
            // Abstraction — both high and low level modules depend on this
            public interface INotificationService
            {
                void Send(string to, string message);
            }

            // Low-level module depends on abstraction
            public class EmailNotificationService : INotificationService
            {
                public void Send(string to, string message)
                {
                    // Send email implementation
                }
            }

            // Low-level module depends on abstraction
            public class SMSNotificationService : INotificationService
            {
                public void Send(string to, string message)
                {
                    // Send SMS implementation
                }
            }

            // Low-level module depends on abstraction
            public class PushNotificationService : INotificationService
            {
                public void Send(string to, string message)
                {
                    // Send push notification implementation
                }
            }

            // High-level module depends on abstraction, not concrete class
            public class PolicyHolderService
            {
                private readonly INotificationService _notificationService; // ✅ Depends on abstraction

                public PolicyHolderService(INotificationService notificationService) // ✅ Injected from outside
                {
                    _notificationService = notificationService;
                }

                public void NotifyPolicyHolder(string to, string message)
                {
                    _notificationService.Send(to, message); // ✅ Loosely coupled
                }
            }
        }
    }
}
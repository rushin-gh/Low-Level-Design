using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class FactoryPattern
    {
    }
}

/* 
    Factory Pattern
    The Factory Pattern defines an interface for creating an object, 
    but lets subclasses decide which class to instantiate. 
    It centralizes object creation logic.

    When to use: When you don't know ahead of time what class you need to instantiate, 
    or when subclasses should control what gets created.
*/

//INotificationService notification = NotificationFactory.GetNotificationService(NotificationServiceEnum.Email);
//notification.Notify("Claude");

public enum NotificationServiceEnum
{
    Email,
    Sms,
    Push
}

public interface INotificationService
{
    public void Notify(string msg);
}

public class EmailNotificationService : INotificationService
{
    public void Notify(string msg) => Console.WriteLine($"Sending email : {msg}");
}

public class SmsNotificationService : INotificationService
{
    public void Notify(string msg) => Console.WriteLine($"Sending SMS : {msg}");
}

public class PushNotificationService : INotificationService
{
    public void Notify(string msg) => Console.WriteLine($"Sending push notification : {msg}");
}

public class NotificationFactory
{
    public static INotificationService GetNotificationService(NotificationServiceEnum notificationServiceEnum)
        => notificationServiceEnum
        switch
        {
           NotificationServiceEnum.Email => new EmailNotificationService(),
           NotificationServiceEnum.Sms => new SmsNotificationService(),
           NotificationServiceEnum.Push => new PushNotificationService()
        };
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    private static void Main(string[] args)
    {
        INotificationStratergy stratergy = NotificationService.GetStratergy(NotificationStratergyEnm.TeamsMsg);
        NotificationService notificationService = new NotificationService(stratergy);
        notificationService.Notify("Hello dosto!");
    }
*/

public class NotificationService
{
    private readonly INotificationStratergy _notificationStratergy;

    public NotificationService(INotificationStratergy notificationStratergy)
    {
        _notificationStratergy = notificationStratergy;
    }

    public void Notify(string message)
    {
        _notificationStratergy.Send(message);
    }

    public static INotificationStratergy GetStratergy(NotificationStratergyEnm userPreferance) => userPreferance switch
    {
        NotificationStratergyEnm.Mail => new MailNotificationStratergy(),
        NotificationStratergyEnm.Sms => new SmsNotificationStratergy(),
        NotificationStratergyEnm.TeamsMsg => new TeamsNotificationStratergy()
    };
}

public interface INotificationStratergy
{
    public void Send(string Message);
}

public class MailNotificationStratergy : INotificationStratergy
{
    public void Send(string Message)
    {
        Console.WriteLine($"Mail sent : {Message}");
    }
}

public class SmsNotificationStratergy : INotificationStratergy
{
    public void Send(string Message)
    {
        Console.WriteLine($"SMS sent : {Message}");
    }
}

public class TeamsNotificationStratergy : INotificationStratergy
{
    public void Send(string Message)
    {
        Console.WriteLine($"Teams message sent : {Message}");
    }
}


public enum NotificationStratergyEnm
{
    Mail,
    Sms,
    TeamsMsg
}


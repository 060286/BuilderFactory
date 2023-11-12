namespace BehavioralPattern.ChainOfResponsibility
{
    internal class Program
    {
        public enum NotificationType
        {
            Email,
            Sms,
            Push
        }

        public class Notification
        {
            public int Id { get; set; }

            public string Message { get; set; }

            public NotificationType Type { get; set; }
        }

        public abstract class NotificationHandler
        {
            protected NotificationHandler nextHandler;

            public void SetNextHandler(NotificationHandler nextHandler)
            {
                this.nextHandler = nextHandler;
            }

            public abstract void HandleNotification(Notification notification);
        }

        public class EmailNotificationHandler : NotificationHandler
        {
            public override void HandleNotification(Notification notification)
            {
                if(notification.Type == NotificationType.Email)
                {
                    Console.WriteLine($"Sending email notification: {notification.Message}");
                }
                else if(nextHandler != null)
                {
                    nextHandler.HandleNotification(notification);
                }
            }
        }

        public class SmsNoificationHandler : NotificationHandler
        {
            public override void HandleNotification(Notification notification)
            {
                if (notification.Type == NotificationType.Sms)
                {
                    Console.WriteLine($"Sending sms notification: {notification.Message}");
                }
                else if (nextHandler != null)
                {
                    nextHandler.HandleNotification(notification);
                }
            }
        }

        public class PushNotificationHandler : NotificationHandler
        {
            public override void HandleNotification(Notification notification)
            {
                if (notification.Type == NotificationType.Push)
                {
                    Console.WriteLine($"Sending push notification: {notification.Message}");
                }
                else if (nextHandler != null)
                {
                    nextHandler.HandleNotification(notification);
                }
            }
        }


        /// <summary>
        /// Scenario: An application that needs to handle different types of notifications, such as email notifications, SMS notifications, and push notifications.
        /// 
        /// Problem: Implementing separate code paths for each type of notification can lead to complex and difficult-to-maintain code.
        /// 
        /// Solution: Implement a Chain of Responsibility pattern to create a chain of notification handlers, each capable of handling a specific type of notification.
        /// The request is passed through the chain until a handler can process it.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Chain Of Responsibility");
            Console.WriteLine("System is creating the chain of handler");
             
            NotificationHandler emailHandler = new EmailNotificationHandler(); 
            NotificationHandler smsHandler = new SmsNoificationHandler();
            NotificationHandler pushHandler = new PushNotificationHandler();

            emailHandler.SetNextHandler(smsHandler); 
            smsHandler.SetNextHandler(pushHandler);

            Console.WriteLine("Email => SMS => Push");

            Notification emailNotification = new Notification { Id = 1, Type = NotificationType.Email, Message = "Email Notification" };
            emailHandler.HandleNotification(emailNotification);

            Notification smsNotification = new Notification { Id = 2, Type = NotificationType.Sms, Message = "SMS Notification" };
            emailHandler.HandleNotification(smsNotification);

            Notification pushNotification = new Notification { Id = 3, Type = NotificationType.Push, Message = "SMS Notification" };
            emailHandler.HandleNotification(pushNotification);

            Console.WriteLine("Completed Sending Notification");
        }
    }
}
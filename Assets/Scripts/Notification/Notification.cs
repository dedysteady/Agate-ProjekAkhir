using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Notification") == 1)
        {
            NotificationsDailyLogin();
            NotificationsDailySpin();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotificationChannel channel2 = new AndroidNotificationChannel()
        {
            Id = "channel_id2",
            Name = "Notifications Channel2",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void NotificationsDailyLogin()
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Claim Daily Rewards";
        notification.Text = "Entering Culinary Emerald Equator and Claim Daily Rewards";
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";
        notification.ShowTimestamp = true;
        notification.FireTime = System.DateTime.Now.AddHours(24);

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        /*if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            //AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }*/
        var notificationStatus = AndroidNotificationCenter.CheckScheduledNotificationStatus(id);

        if (notificationStatus == NotificationStatus.Scheduled)
        {
            // Replace the scheduled notification with a new notification.
            AndroidNotificationCenter.UpdateScheduledNotification(id, notification, "channel_id");
        }
        else if (notificationStatus == NotificationStatus.Delivered)
        {
            // Remove the previously shown notification from the status bar.
            AndroidNotificationCenter.CancelNotification(id);
        }
    }

    public void NotificationsDailySpin()
    {
        AndroidNotification notification2 = new AndroidNotification();
        notification2.Title = "Claim Free Spin";
        notification2.Text = "Free Spin Available! Spin Now! and Claim Spin Rewards";
        notification2.SmallIcon = "icon_0";
        notification2.LargeIcon = "icon_1";
        notification2.ShowTimestamp = true;
        notification2.FireTime = System.DateTime.Now.AddHours(12);

        var id2 = AndroidNotificationCenter.SendNotification(notification2, "channel_id2");

        /*if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id2) == NotificationStatus.Scheduled)
        {
            //AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification2, "channel_id2");
        }*/
        var notificationStatus = AndroidNotificationCenter.CheckScheduledNotificationStatus(id2);

        if (notificationStatus == NotificationStatus.Scheduled)
        {
            // Replace the scheduled notification with a new notification.
            AndroidNotificationCenter.UpdateScheduledNotification(id2, notification2, "channel_id");
        }
        else if (notificationStatus == NotificationStatus.Delivered)
        {
            // Remove the previously shown notification from the status bar.
            AndroidNotificationCenter.CancelNotification(id2);
        }
    }
}

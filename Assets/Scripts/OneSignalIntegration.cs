using UnityEngine;
using OneSignalSDK;
using Unity.Notifications;
using System.Collections;
using Unity.Advertisement.IosSupport;

public class OneSignalIntegration : MonoBehaviour
{
    [SerializeField] private string _OneSignalKey;
    private IEnumerator RequestNotificationPermission()

    {
#if UNITY_IOS
        var request = NotificationCenter.RequestPermission();

        if (request.Status == NotificationsPermissionStatus.RequestPending)
            yield return request;
#endif
    }

    private void Start()

    {
        StartCoroutine(RequestNotificationPermission());

        OneSignal.Default.Initialize(_OneSignalKey);
    }
}



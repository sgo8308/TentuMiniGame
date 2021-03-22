using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsController : MonoBehaviour
{
    public string gameId = "4050715";
    public string surfacingId = "Banner_Android";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(surfacingId);
    }
}

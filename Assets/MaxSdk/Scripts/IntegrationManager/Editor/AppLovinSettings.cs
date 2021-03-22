//
//  AppLovinSettings.cs
//  AppLovin MAX Unity Plugin
//
//  Created by Santosh Bagadi on 1/27/20.
//  Copyright © 2019 AppLovin. All rights reserved.
//

using AppLovinMax.Scripts.IntegrationManager.Editor;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// A <see cref="ScriptableObject"/> representing the AppLovin Settings that can be set in the Integration Manager Window.
///
/// The scriptable object asset is created with the name <c>AppLovinSettings.asset</c> and is placed under the directory <c>Assets/MaxSdk/Resources</c>.
///
/// NOTE: Not name spacing this class since it is reflected upon by the Google adapter and will break compatibility.
/// </summary>
public class AppLovinSettings : ScriptableObject
{
    public const string SettingsExportPath = "MaxSdk/Resources/AppLovinSettings.asset";

    public const string DefaultUserTrackingDescriptionEn = "Pressing \\\"Allow\\\" uses device info for more relevant ad content";
    public const string DefaultUserTrackingDescriptionDe = "\\\"Erlauben\\\" drücken benutzt Gerätinformationen für relevantere Werbeinhalte";
    public const string DefaultUserTrackingDescriptionEs = "Presionando \\\"Permitir\\\", se usa la información del dispositivo para obtener contenido publicitario más relevante";
    public const string DefaultUserTrackingDescriptionFr = "\\\"Autoriser\\\" permet d'utiliser les infos du téléphone pour afficher des contenus publicitaires plus pertinents";
    public const string DefaultUserTrackingDescriptionJa = "\\\"許可\\\"をクリックすることで、デバイス情報を元により最適な広告を表示することができます";
    public const string DefaultUserTrackingDescriptionKo = "\\\"허용\\\"을 누르면 더 관련성 높은 광고 콘텐츠를 제공하기 위해 기기 정보가 사용됩니다";
    public const string DefaultUserTrackingDescriptionZhHans = "点击\\\"允许\\\"以使用设备信息获得更加相关的广告内容";

    private static AppLovinSettings instance;

    [SerializeField] private bool qualityServiceEnabled = true;
    [SerializeField] private string sdkKey;

    [SerializeField] private bool consentFlowEnabled;
    [SerializeField] private string consentFlowPrivacyPolicyUrl = string.Empty;
    [FormerlySerializedAs("userTrackingUsageDescription")] [SerializeField] private string userTrackingUsageDescriptionEn = string.Empty;
    [SerializeField] private bool userTrackingUsageLocalizationEnabled;
    [SerializeField] private string userTrackingUsageDescriptionDe = string.Empty;
    [SerializeField] private string userTrackingUsageDescriptionEs = string.Empty;
    [SerializeField] private string userTrackingUsageDescriptionFr = string.Empty;
    [SerializeField] private string userTrackingUsageDescriptionJa = string.Empty;
    [SerializeField] private string userTrackingUsageDescriptionKo = string.Empty;
    [SerializeField] private string userTrackingUsageDescriptionZhHans = string.Empty;

    [SerializeField] private string adMobAndroidAppId = string.Empty;
    [SerializeField] private string adMobIosAppId = string.Empty;

    /// <summary>
    /// An instance of AppLovin Setting.
    /// </summary>
    public static AppLovinSettings Instance
    {
        get
        {
            if (instance == null)
            {
                string settingsFilePath;
                // The settings file should be under the Assets/ folder so that it can be version controlled and cannot be overriden when updating.
                // If the plugin is outside the Assets folder, create the settings asset at the default location.
                if (AppLovinIntegrationManager.IsPluginOutsideAssetsDirectory)
                {
                    // Note: Can't use absolute path when calling `CreateAsset`. Should use relative path to Assets/ directory.
                    settingsFilePath = Path.Combine("Assets", SettingsExportPath);

                    var maxSdkDir = Path.Combine(Application.dataPath, "MaxSdk");
                    if (!Directory.Exists(maxSdkDir))
                    {
                        Directory.CreateDirectory(maxSdkDir);
                    }
                }
                else
                {
                    settingsFilePath = Path.Combine(AppLovinIntegrationManager.PluginParentDirectory, SettingsExportPath);
                }

                var settingsDir = Path.GetDirectoryName(settingsFilePath);
                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                instance = AssetDatabase.LoadAssetAtPath<AppLovinSettings>(settingsFilePath);
                if (instance != null) return instance;

                instance = CreateInstance<AppLovinSettings>();
                AssetDatabase.CreateAsset(instance, settingsFilePath);
            }

            return instance;
        }
    }

    /// <summary>
    /// Whether or not to install Quality Service plugin.
    /// </summary>
    public bool QualityServiceEnabled
    {
        get { return Instance.qualityServiceEnabled; }
        set { Instance.qualityServiceEnabled = value; }
    }

    /// <summary>
    /// AppLovin SDK Key.
    /// </summary>
    public string SdkKey
    {
        get { return Instance.sdkKey; }
        set { Instance.sdkKey = value; }
    }

    /// <summary>
    /// Whether or not AppLovin Consent Flow is enabled.
    /// </summary>
    public bool ConsentFlowEnabled
    {
        get { return Instance.consentFlowEnabled; }
        set
        {
            var previousValue = Instance.consentFlowEnabled;
            Instance.consentFlowEnabled = value;

            if (value)
            {
                // If the value didn't change, we don't need to update anything.
                if (previousValue) return;
                
                Instance.UserTrackingUsageDescriptionEn = DefaultUserTrackingDescriptionEn;
                Instance.UserTrackingUsageLocalizationEnabled = true;
            }
            else
            {
                Instance.ConsentFlowPrivacyPolicyUrl = string.Empty;
                Instance.UserTrackingUsageDescriptionEn = string.Empty;
                Instance.UserTrackingUsageLocalizationEnabled = false;
            }
        }
    }

    /// <summary>
    /// A URL pointing to the Privacy Policy for the app to be shown when prompting the user for consent.
    /// </summary>
    public string ConsentFlowPrivacyPolicyUrl
    {
        get { return Instance.consentFlowPrivacyPolicyUrl; }
        set { Instance.consentFlowPrivacyPolicyUrl = value; }
    }

    /// <summary>
    /// A User Tracking Usage Description in English to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionEn
    {
        get { return Instance.userTrackingUsageDescriptionEn; }
        set { Instance.userTrackingUsageDescriptionEn = value; }
    }

    /// <summary>
    /// Whether or not to localize User Tracking Usage Description.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public bool UserTrackingUsageLocalizationEnabled
    {
        get { return Instance.userTrackingUsageLocalizationEnabled; }
        set
        {
            var previousValue = Instance.userTrackingUsageLocalizationEnabled;
            Instance.userTrackingUsageLocalizationEnabled = value;

            if (value)
            {
                // If the value didn't change or the english localization text is not the default one, we don't need to update anything.
                if (previousValue || !DefaultUserTrackingDescriptionEn.Equals(Instance.UserTrackingUsageDescriptionEn)) return;

                Instance.UserTrackingUsageDescriptionDe = DefaultUserTrackingDescriptionDe;
                Instance.UserTrackingUsageDescriptionEs = DefaultUserTrackingDescriptionEs;
                Instance.UserTrackingUsageDescriptionFr = DefaultUserTrackingDescriptionFr;
                Instance.UserTrackingUsageDescriptionJa = DefaultUserTrackingDescriptionJa;
                Instance.UserTrackingUsageDescriptionKo = DefaultUserTrackingDescriptionKo;
                Instance.UserTrackingUsageDescriptionZhHans = DefaultUserTrackingDescriptionZhHans;
            }
            else
            {
                Instance.UserTrackingUsageDescriptionZhHans = string.Empty;
                Instance.UserTrackingUsageDescriptionFr = string.Empty;
                Instance.UserTrackingUsageDescriptionDe = string.Empty;
                Instance.UserTrackingUsageDescriptionJa = string.Empty;
                Instance.UserTrackingUsageDescriptionKo = string.Empty;
                Instance.UserTrackingUsageDescriptionEs = string.Empty;
            }
        }
    }

    /// <summary>
    /// A User Tracking Usage Description in German to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionDe
    {
        get { return Instance.userTrackingUsageDescriptionDe; }
        set { Instance.userTrackingUsageDescriptionDe = value; }
    }

    /// <summary>
    /// A User Tracking Usage Description in Spanish to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionEs
    {
        get { return Instance.userTrackingUsageDescriptionEs; }
        set { Instance.userTrackingUsageDescriptionEs = value; }
    }

    /// <summary>
    /// A User Tracking Usage Description in French to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionFr
    {
        get { return Instance.userTrackingUsageDescriptionFr; }
        set { Instance.userTrackingUsageDescriptionFr = value; }
    }

    /// <summary>
    /// A User Tracking Usage Description in Japanese to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionJa
    {
        get { return Instance.userTrackingUsageDescriptionJa; }
        set { Instance.userTrackingUsageDescriptionJa = value; }
    }

    /// <summary>
    /// A User Tracking Usage Description in Korean to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionKo
    {
        get { return Instance.userTrackingUsageDescriptionKo; }
        set { Instance.userTrackingUsageDescriptionKo = value; }
    }

    /// <summary>
    /// A User Tracking Usage Description in Chinese (Simplified) to be shown to users when requesting permission to use data for tracking.
    /// For more information see <see cref="https://developer.apple.com/documentation/bundleresources/information_property_list/nsusertrackingusagedescription">Apple's documentation</see>.
    /// </summary>
    public string UserTrackingUsageDescriptionZhHans
    {
        get { return Instance.userTrackingUsageDescriptionZhHans; }
        set { Instance.userTrackingUsageDescriptionZhHans = value; }
    }

    /// <summary>
    /// AdMob Android App ID.
    /// </summary>
    public string AdMobAndroidAppId
    {
        get { return Instance.adMobAndroidAppId; }
        set { Instance.adMobAndroidAppId = value; }
    }

    /// <summary>
    /// AdMob iOS App ID
    /// </summary>
    public string AdMobIosAppId
    {
        get { return Instance.adMobIosAppId; }
        set { Instance.adMobIosAppId = value; }
    }

    /// <summary>
    /// Saves the instance of the settings.
    /// </summary>
    public void SaveAsync()
    {
        EditorUtility.SetDirty(instance);
    }
}
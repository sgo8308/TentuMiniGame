//// Decompiled with JetBrains decompiler
//// Type: UnityEngine.Advertisements.Platform.Editor.EditorBanner
//// Assembly: UnityEngine.Advertisements.Editor, Version=3.6.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 91220002-A2FD-403A-BD0D-44E0C6CD5F2C
//// Assembly location: C:\Users\jiwoo\Desktop\새 폴더\TentuMiniGamevideo\Assets\UnityAds\UnityEngine.Advertisements.Editor.dll

//using System;

//namespace UnityEngine.Advertisements.Platform.Editor
//{
//    internal class EditorBanner 
//    {
//        private BannerPlaceholder m_BannerPlaceholder;
//        private BannerPosition m_CurrentBannerPosition;
//        private BannerPosition m_TargetBannerPosition;
//        private BannerOptions m_BannerShowOptions;

//        public bool IsLoaded { get; private set; }


//        public void Load(string placementId, BannerLoadOptions loadOptions)
//        {
//            this.IsLoaded = true;
//            this.m_CurrentBannerPosition = this.m_TargetBannerPosition;

//        }


//        public void Hide(bool destroy = false)
//        {
//            if (destroy)
//            {
//                this.IsLoaded = false;
//            }
//            else
//            {
//                this.m_BannerPlaceholder.HideBanner();
//                this.m_Banner.UnityLifecycleManager.Post((Action)(() =>
//                {
//                    if (this.m_BannerShowOptions == null)
//                        return;
//                    this.m_BannerShowOptions.hideCallback();
//                }));
//            }
//        }

//        public void SetPosition(BannerPosition position) => this.m_TargetBannerPosition = position;

//        private BannerPlaceholder CreateBannerPlaceholder()
//        {
//            GameObject gameObject1 = new GameObject("UnityAdsBanner(Placeholder)");
//            ((Object)gameObject1).set_hideFlags((HideFlags)63);
//            GameObject gameObject2 = gameObject1;
//            Object.DontDestroyOnLoad((Object)gameObject2);
//            return (BannerPlaceholder)gameObject2.AddComponent<BannerPlaceholder>();
//        }
//    }
//}

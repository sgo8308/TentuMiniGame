
namespace appnext
{
	public class Interstitial : Ad
    {
        public const string TYPE_MANAGED = "managed";
        public const string TYPE_VIDEO = "video";
        public const string TYPE_STATIC = "static";

		public Interstitial(string placementID) : base(placementID)
		{
		}

		public Interstitial(string placementID, InterstitialConfig config) : base(placementID, config)
        {           
            setButtonColor(config.ButtonColor);
            setCreativeType(config.CreativeType);
            setSkipText(config.SkipText);
            setAutoPlay(config.AutoPlay);
            setBackButtonCanClose(config.BackButtonCanClose);
        }
        
		protected override void initAd(params object[] args)
		{
			#if UNITY_ANDROID
		        createInstance("getInterstitial", args);
			#elif UNITY_IPHONE
                this.adKey = AppnextIOSSDKBridge.createAd(AppnextIOSSDKBridge.AD_TYPE_INTERSTITIAL, args[0].ToString());
            #endif
        }

		public void setSkipText(string skipText)
        {
			#if UNITY_ANDROID
			    instance.Call("setSkipText", skipText);
			#elif UNITY_IPHONE
			    AppnextIOSSDKBridge.setSkipText(adKey, skipText);
			#endif
        }

        public void setCreativeType(string creativeType)
        {
			#if UNITY_ANDROID
			instance.Call("setCreativeType", creativeType);
			#elif UNITY_IPHONE
			AppnextIOSSDKBridge.setCreativeType(adKey, creativeType);
			#endif
        }

        public void setAutoPlay(bool autoPlay)
        {
			#if UNITY_ANDROID
			    instance.Call("setAutoPlay", autoPlay);
			#elif UNITY_IPHONE
			    AppnextIOSSDKBridge.setAutoPlay(adKey, autoPlay);
			#endif
        }

        public void setButtonColor(string buttonColor)
        {
            #if UNITY_ANDROID
                instance.Call("setButtonColor", buttonColor);
            #elif UNITY_IPHONE
                AppnextIOSSDKBridge.setButtonColor(adKey, buttonColor);
            #endif
        }

        public void setBackButtonCanClose(bool canClose)
        {
            #if UNITY_ANDROID
             instance.Call("setBackButtonCanClose", canClose);
            #elif UNITY_IPHONE
            			
            #endif
        }

       
    }
}

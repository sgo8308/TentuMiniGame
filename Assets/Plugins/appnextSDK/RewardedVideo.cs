
namespace appnext
{
	public class RewardedVideo : Video
    {
		public RewardedVideo(string placementID) : base(placementID)
        {
			
        }

		public RewardedVideo(string placementID, RewardedConfig config) : base(placementID, config)
        {
            setMode(config.Mode);
            setMultiTimerLength(config.MultiTimerLength);
        }


        protected override void initAd(params object[] args)
        {
            #if UNITY_ANDROID
               createInstance("getRewardedVideo", args);
            #elif UNITY_IPHONE
			   this.adKey = AppnextIOSSDKBridge.createAd(AppnextIOSSDKBridge.AD_TYPE_INTERSTITIAL, args[0].ToString());
            #endif
        }

        public void setMultiTimerLength(int time)
        {
        #if UNITY_ANDROID
                    instance.Call("setMultiTimerLength", time);
        #elif UNITY_IPHONE
        		
        #endif
        }

        public void setMode(string mode)
        {
        #if UNITY_ANDROID
                    instance.Call("setMode", mode);
        #elif UNITY_IPHONE
        		
        #endif
        }

        public void setRewardedServerSidePostback(string rewardsTransactionId, string rewardsUserId,
                                                  string rewardsRewardTypeCurrency, string rewardsAmountRewarded,
                                                  string rewardsCustomParameter)
        {
			#if UNITY_ANDROID
			instance.Call("setRewardedServerSidePostback", rewardsTransactionId, rewardsUserId, rewardsRewardTypeCurrency, rewardsAmountRewarded, rewardsCustomParameter);
			#elif UNITY_IPHONE
			AppnextIOSSDKBridge.setRewardsTransactionId(adKey, rewardsTransactionId);
			AppnextIOSSDKBridge.setRewardsUserId(adKey, rewardsUserId);
			AppnextIOSSDKBridge.setRewardsRewardTypeCurrency(adKey, rewardsRewardTypeCurrency);
			AppnextIOSSDKBridge.setRewardsAmountRewarded(adKey, rewardsAmountRewarded);
			AppnextIOSSDKBridge.setRewardsCustomParameter(adKey, rewardsCustomParameter);
			#endif
        }

		public void setRewardedMode(string mode)
		{
			#if UNITY_ANDROID
			instance.Call("setRewardedMode", mode);
			#elif UNITY_IPHONE
			#endif
		}

    }
}

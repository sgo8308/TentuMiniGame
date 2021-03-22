
namespace appnext
{
	public class FullScreenVideo : Video
    {
		public FullScreenVideo(string placementID) : base(placementID)
        {
        }

		public FullScreenVideo(string placementID, FullscreenConfig config) : base(placementID, config)
        {
#if UNITY_ANDROID
            setBackButtonCanClose(config.BackButtonCanClose);            
            setShowClose(config.ShowClose,config.Delay);
#elif UNITY_IPHON
#endif

        }

        protected override void initAd(params object[] args)
        {
#if UNITY_ANDROID
                createInstance("getFullScreenVideo", args);
#elif UNITY_IPHONE
                this.adKey = AppnextIOSSDKBridge.createAd(AppnextIOSSDKBridge.AD_TYPE_INTERSTITIAL, args[0].ToString());
#endif
        }
#if UNITY_ANDROID
        public void setBackButtonCanClose(bool can_close)
        {
            instance.Call("setBackButtonCanClose", can_close);
        }
        public void setShowClose(bool show_close)
        {
            instance.Call("setShowClose", show_close);
        }
        public void setShowClose(bool show_close,long delay_time)
        {
            instance.Call("setShowClose", show_close, delay_time);
        }
#endif
    }
}

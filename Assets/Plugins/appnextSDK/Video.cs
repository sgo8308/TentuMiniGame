using UnityEngine;
using System.Collections;

namespace appnext
{
	public abstract class Video : Ad
	{
		public const string PROGRESS_CLOCK = "clock";
		public const string PROGRESS_BAR = "bar";
		public const string PROGRESS_NONE = "none";
		public const string PROGRESS_DEFAULT = "default";

		public const string VIDEO_LENGTH_SHORT = "15";
		public const string VIDEO_LENGTH_LONG = "30";
		public const string VIDEO_LENGTH_DEFAULT = "default";

		public delegate void OnVideoEndedDelegate(Video ad);
		public event OnVideoEndedDelegate onVideoEndedDelegate;

		protected Video(string placementID) : base(placementID)
		{
		}

		protected Video(string placementID, VideoConfig config) : base(placementID, config)
		{
			setVideoLength(config.VideoLength);
            setShowCta(config.ShowCta);
            setRollCaptionTime(config.RollCaptionTime);
		}

		protected override void registerAdGameObjectForEvents()
		{
			base.registerAdGameObjectForEvents();
			setOnVideoEndedCallback(this.adGameObject.name, "onVideoEndedCallback");
		}

		private void setOnVideoEndedCallback(string gameObject, string method)
		{
			#if UNITY_ANDROID
			instance.Call("setOnVideoEndedCallback", gameObject, method);
			#elif UNITY_IPHONE
			AppnextIOSSDKBridge.setOnVideoEndedCallback(adKey, gameObject, method);
			#endif
		}

		private void onVideoEndedCallback(string message)
		{
			Ad thisAd;
			bool success = Ad.gameObjectNameToAdDictionary.TryGetValue(this.name, out thisAd);
			if (success) {
				if (((Video)thisAd).onVideoEndedDelegate != null) {
					((Video)thisAd).onVideoEndedDelegate(((Video)thisAd));
				}
			}
		}



		public void setVideoLength(string videoLength)
		{
			#if UNITY_ANDROID
			instance.Call("setVideoLength", videoLength);
			#elif UNITY_IPHONE
			AppnextIOSSDKBridge.setVideoLength(adKey, videoLength);
			#endif
		}

        public void setShowCta(bool cta)
        {
#if UNITY_ANDROID
            instance.Call("setShowCta", cta);
#elif UNITY_IPHONE			
#endif
        }

        public void setRollCaptionTime(int time)
        {
#if UNITY_ANDROID
            instance.Call("setRollCaptionTime", time);
#elif UNITY_IPHONE			
#endif
        }

    }
}

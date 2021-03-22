using UnityEngine;

namespace appnext
{
	public abstract class VideoConfig : AdConfig
	{

        public string VideoLength {get; set;}
        public bool ShowCta { get; set; }
        public int RollCaptionTime { get; set; }

       
#if UNITY_ANDROID

        protected override void initParamsFromAndroidJavaObject(AndroidJavaObject instance)
		{
			base.initParamsFromAndroidJavaObject(instance);
            VideoLength = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getVideoLength", "()Ljava/lang/String"), new jvalue[0] { });           
            RollCaptionTime = AndroidJNI.CallIntMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getRollCaptionTime", "()I"), new jvalue[0] { });
            ShowCta = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isShowCta", "()Z"), new jvalue[0] { });
        }

#elif UNITY_IPHONE

		protected override void initConfig()
		{
			base.initConfig ();
            this.VideoLength = AppnextIOSSDKBridge.getConfigDefaultString(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_VIDEO_LENGTH);
		}

#endif


    }
}

﻿using UnityEngine;

namespace appnext
{
	public class RewardedConfig : VideoConfig
    {
        int multiTimerLength;
        string mode;

        public int MultiTimerLength
        {
            get; set;
        }

        public string Mode
        {
            get; set;
        }

        public RewardedConfig() : base()
        {
			#if UNITY_ANDROID
			AndroidJavaObject instance = new AndroidJavaObject("com.appnext.ads.fullscreen.RewardedConfig");
			initParamsFromAndroidJavaObject(instance);
			#elif UNITY_IPHONE
			#endif
        }

        #if UNITY_ANDROID
        protected override void initParamsFromAndroidJavaObject(AndroidJavaObject instance)
        {
            multiTimerLength = AndroidJNI.CallIntMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getMultiTimerLength", "()I"), new jvalue[0] { });
            mode = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getMode", "()Ljava/lang/String"), new jvalue[0] { });
        }
        #elif UNITY_IPHONE
        #endif

    }
}

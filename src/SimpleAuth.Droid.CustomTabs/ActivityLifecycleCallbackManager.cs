﻿using System;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using SimpleAuth.Droid.CustomTabs;
namespace SimpleAuth
{
    internal class ActivityLifecycleCallbackManager : Java.Lang.Object, global::Android.App.Application.IActivityLifecycleCallbacks
    {
        public Activity CurrentActivity { get; private set; }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity as Activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
            if (activity == CurrentActivity)
            CurrentActivity = null;
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CurrentActivity = activity as Activity;
			if (!(activity is SimpleAuthCallbackActivity))
				NativeCustomTabsAuthenticator.OnResume();
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CurrentActivity = activity as Activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}

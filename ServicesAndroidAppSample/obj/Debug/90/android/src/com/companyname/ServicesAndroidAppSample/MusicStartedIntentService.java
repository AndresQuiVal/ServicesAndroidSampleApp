package com.companyname.ServicesAndroidAppSample;


public class MusicStartedIntentService
	extends mono.android.app.IntentService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHandleIntent:(Landroid/content/Intent;)V:GetOnHandleIntent_Landroid_content_Intent_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("ServicesAndroidAppSample.Services.MusicStartedIntentService, ServicesAndroidAppSample", MusicStartedIntentService.class, __md_methods);
	}


	public MusicStartedIntentService (java.lang.String p0)
	{
		super (p0);
		if (getClass () == MusicStartedIntentService.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Services.MusicStartedIntentService, ServicesAndroidAppSample", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public MusicStartedIntentService ()
	{
		super ();
		if (getClass () == MusicStartedIntentService.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Services.MusicStartedIntentService, ServicesAndroidAppSample", "", this, new java.lang.Object[] {  });
	}


	public void onHandleIntent (android.content.Intent p0)
	{
		n_onHandleIntent (p0);
	}

	private native void n_onHandleIntent (android.content.Intent p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

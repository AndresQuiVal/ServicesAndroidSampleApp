package crc64ca0bdc8ed54c941e;


public class MusicServiceConnection
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.ServiceConnection
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onServiceConnected:(Landroid/content/ComponentName;Landroid/os/IBinder;)V:GetOnServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_Handler:Android.Content.IServiceConnectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onServiceDisconnected:(Landroid/content/ComponentName;)V:GetOnServiceDisconnected_Landroid_content_ComponentName_Handler:Android.Content.IServiceConnectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("ServicesAndroidAppSample.Service_connection.MusicServiceConnection, ServicesAndroidAppSample", MusicServiceConnection.class, __md_methods);
	}


	public MusicServiceConnection ()
	{
		super ();
		if (getClass () == MusicServiceConnection.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Service_connection.MusicServiceConnection, ServicesAndroidAppSample", "", this, new java.lang.Object[] {  });
	}

	public MusicServiceConnection (crc64533a6edbde7719b1.MainActivity p0)
	{
		super ();
		if (getClass () == MusicServiceConnection.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Service_connection.MusicServiceConnection, ServicesAndroidAppSample", "ServicesAndroidAppSample.MainActivity, ServicesAndroidAppSample", this, new java.lang.Object[] { p0 });
	}


	public void onServiceConnected (android.content.ComponentName p0, android.os.IBinder p1)
	{
		n_onServiceConnected (p0, p1);
	}

	private native void n_onServiceConnected (android.content.ComponentName p0, android.os.IBinder p1);


	public void onServiceDisconnected (android.content.ComponentName p0)
	{
		n_onServiceDisconnected (p0);
	}

	private native void n_onServiceDisconnected (android.content.ComponentName p0);

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

package crc648c77f94e0b38ad13;


public class MusicBinder
	extends android.os.Binder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ServicesAndroidAppSample.Bound_service_connections.MusicBinder, ServicesAndroidAppSample", MusicBinder.class, __md_methods);
	}


	public MusicBinder ()
	{
		super ();
		if (getClass () == MusicBinder.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Bound_service_connections.MusicBinder, ServicesAndroidAppSample", "", this, new java.lang.Object[] {  });
	}

	public MusicBinder (com.companyname.ServicesAndroidAppSample.MusicService p0)
	{
		super ();
		if (getClass () == MusicBinder.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Bound_service_connections.MusicBinder, ServicesAndroidAppSample", "ServicesAndroidAppSample.Services.MusicService, ServicesAndroidAppSample", this, new java.lang.Object[] { p0 });
	}

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

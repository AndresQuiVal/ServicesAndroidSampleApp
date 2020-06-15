package crc6428abe9f69c8919b3;


public class UserModel
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ServicesAndroidAppSample.Models.UserModel, ServicesAndroidAppSample", UserModel.class, __md_methods);
	}


	public UserModel ()
	{
		super ();
		if (getClass () == UserModel.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Models.UserModel, ServicesAndroidAppSample", "", this, new java.lang.Object[] {  });
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

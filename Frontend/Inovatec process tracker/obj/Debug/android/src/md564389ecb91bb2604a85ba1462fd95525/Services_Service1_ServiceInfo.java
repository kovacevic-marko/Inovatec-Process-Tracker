package md564389ecb91bb2604a85ba1462fd95525;


public class Services_Service1_ServiceInfo
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Inovatec_process_tracker.Activities.Services_Service1_ServiceInfo, Inovatec process tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Services_Service1_ServiceInfo.class, __md_methods);
	}


	public Services_Service1_ServiceInfo ()
	{
		super ();
		if (getClass () == Services_Service1_ServiceInfo.class)
			mono.android.TypeManager.Activate ("Inovatec_process_tracker.Activities.Services_Service1_ServiceInfo, Inovatec process tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

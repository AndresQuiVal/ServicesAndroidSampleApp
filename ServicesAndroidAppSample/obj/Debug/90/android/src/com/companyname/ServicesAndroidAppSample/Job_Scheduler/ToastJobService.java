package com.companyname.ServicesAndroidAppSample.Job_Scheduler;


public class ToastJobService
	extends android.app.job.JobService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStartJob:(Landroid/app/job/JobParameters;)Z:GetOnStartJob_Landroid_app_job_JobParameters_Handler\n" +
			"n_onStopJob:(Landroid/app/job/JobParameters;)Z:GetOnStopJob_Landroid_app_job_JobParameters_Handler\n" +
			"";
		mono.android.Runtime.register ("ServicesAndroidAppSample.Job_Scheduler.ToastJobService, ServicesAndroidAppSample", ToastJobService.class, __md_methods);
	}


	public ToastJobService ()
	{
		super ();
		if (getClass () == ToastJobService.class)
			mono.android.TypeManager.Activate ("ServicesAndroidAppSample.Job_Scheduler.ToastJobService, ServicesAndroidAppSample", "", this, new java.lang.Object[] {  });
	}


	public boolean onStartJob (android.app.job.JobParameters p0)
	{
		return n_onStartJob (p0);
	}

	private native boolean n_onStartJob (android.app.job.JobParameters p0);


	public boolean onStopJob (android.app.job.JobParameters p0)
	{
		return n_onStopJob (p0);
	}

	private native boolean n_onStopJob (android.app.job.JobParameters p0);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;


public class AppoD : MonoBehaviour {
	 
	public const string app_key = "c9dfedda72ea91c3b7363f7a4b79c7b09eb61536f893427a";

	public void Start () {
		
		Appodeal.disableNetwork("inmobi");
		Appodeal.disableNetwork("mmedia");
		Appodeal.disableLocationPermissionCheck();
		Appodeal.initialize(app_key, Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO);
		
	}

	public void Interstitial ()
	{
		Appodeal.show(Appodeal.INTERSTITIAL);
		Appodeal.isLoaded(Appodeal.INTERSTITIAL);
	}

	public void Rewarded_Video ()
	{

	}

	public void Banner ()
	{
		Appodeal.show(Appodeal.BANNER_BOTTOM);
		Appodeal.isLoaded (Appodeal.BANNER);

	}

}

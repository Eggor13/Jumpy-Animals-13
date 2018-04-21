using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;


public class AdManager : MonoBehaviour {

	int timesTriedToShowInterstitial = 0;

	void Start () {
		
		string appKey = "3218b67bd51978487d9734c2810b2926a85d71bc562cb419";
		Appodeal.disableLocationPermissionCheck ();
		Appodeal.setTesting(true);
		Appodeal.initialize(appKey, Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
	}
	
	public void ShowBanner()
	{
		if (Appodeal.isLoaded (Appodeal.BANNER))
			Appodeal.show (Appodeal.BANNER_BOTTOM);
	}

	public void ShowInterstitial()
	{
		timesTriedToShowInterstitial++;
		if (Appodeal.isLoaded (Appodeal.INTERSTITIAL) && timesTriedToShowInterstitial >= 5) 
		{
			Appodeal.show (Appodeal.INTERSTITIAL);
			timesTriedToShowInterstitial = 0;
		}
	}
 
	}   

using UnityEngine;
using System.Collections;

using GoogleMobileAds.Api;

public class AdHolder : MonoBehaviour {
	
	public static BannerView bannerView;
	
	void Start () {
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1685157087617386/5409201759";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		AdPosition adPos = AdPosition.Bottom;
		if (Application.loadedLevelName == "LogrosScene") {
			adPos = AdPosition.Top;
		} 
		bannerView = new BannerView(adUnitId, AdSize.Banner, adPos);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
		if (Application.loadedLevelName == "GameScene") {
			bannerView.Hide ();
		} else {
			bannerView.Show ();
		}
	}
	
	public void Show() {
		bannerView.Show ();
	}

}
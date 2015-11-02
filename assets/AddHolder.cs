using UnityEngine;
using System.Collections;

using GoogleMobileAds.Api;

public class AddHolder : MonoBehaviour {
	
	private BannerView bannerView;
	
	void Start () {
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1685157087617386/5409201759";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopLeft);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
		bannerView.Show ();
	}
	
	public void Show() {
		bannerView.Show ();
	}
	
	public void Hide() {
		bannerView.Hide ();
	}
}
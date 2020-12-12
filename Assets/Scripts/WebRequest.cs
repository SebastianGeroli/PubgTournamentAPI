using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequest
{

	public static Data Data;
	public static IEnumerator RequestTournaments(Action<string>callback)
	{
		UnityWebRequest myWww = UnityWebRequest.Get("https://api.pubg.com/tournaments");
		myWww.SetRequestHeader("accept", "application/vnd.api+json");
		myWww.SetRequestHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJmYTRjNWVmMC0xZTllLTAxMzktODA2Zi02ZGJhODM4MmNiYjQiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjA3Nzc0MTgyLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InRlc3RpbmdhcGkifQ.dlCPoKv7uWpgjLC_mylZvpwONDy1M9VQ6NCjNrxeA40");

		yield return myWww.SendWebRequest();

		if (myWww.isNetworkError || myWww.isHttpError) {
			Debug.Log(myWww.error);
		}
		else
		{
			//Debug.Log(myWww.downloadHandler.text); 
			callback(myWww.downloadHandler.text);
		}


		yield return null;
	}
}

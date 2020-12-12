using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequest
{

	public static IEnumerator RequestTournaments()
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
			var N = SimpleJSON.JSON.Parse(myWww.downloadHandler.text);
			foreach (var item in N["data"]) {
				Debug.Log(item.Value["id"]);
				Debug.Log(item.Value["attributes"]["createdAt"]);

			}
		}


		yield return null;
	}

	public struct Data {
		List<TournamentData> tournamentDatas;
	}

	public struct TournamentData {
		string type;
		string id;
		List<Attribute> attributes;
	}

	public struct Attribute {
		string name;
		string value;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{

	public Data Data;
	private void Start()
	{
		StartCoroutine(WebRequest.RequestTournaments(ManageData));
	}

	public void ManageData(string json)
	{
		Data.tournamentDatas = new List<TournamentData>();

		var N = SimpleJSON.JSON.Parse(json);
		foreach (var item in N["data"])
		{
			TournamentData tournamentData = new TournamentData();
			tournamentData.id = item.Value["id"];
			tournamentData.date = item.Value["attributes"]["createdAt"];

			Data.tournamentDatas.Add(tournamentData);

			//Debug.Log(item.Value["id"]);
			//Debug.Log(item.Value["attributes"]["createdAt"]);
		}

		foreach (var data in Data.tournamentDatas)
		{
			Debug.Log($"Tournament id: {data.id} Tournament Date: {data.date} ");
		}

	}
}

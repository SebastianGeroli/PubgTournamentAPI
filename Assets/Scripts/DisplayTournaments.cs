using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTournaments : MonoBehaviour
{
	public GameObject content;
	public GameObject row;

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
		}
		InstanciateRows();
	}

	public void InstanciateRows()
	{
		foreach (var tournament in Data.tournamentDatas)
		{
			GameObject newRow = Instantiate(row);
			newRow.transform.SetParent(content.transform, false);

			if (newRow.GetComponent<UITournamentRow>())
			{
				UITournamentRow tournamentRow = newRow.GetComponent<UITournamentRow>();
				tournamentRow.SetTextID(tournament.id);
				tournamentRow.SetTextDate(tournament.date);
			}

		}


	}
}

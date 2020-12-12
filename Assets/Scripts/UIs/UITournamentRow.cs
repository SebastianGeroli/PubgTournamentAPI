using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class used to hold references of texts needed to change per row when displaying
/// </summary>
public class UITournamentRow : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI tournamentID;
	[SerializeField]
	private TextMeshProUGUI tournamentDate;

	public void SetTextID(string id)
	{
		tournamentID.text = id;
	}

	public void SetTextDate(string date)
	{
		tournamentDate.text = date;
	}
}

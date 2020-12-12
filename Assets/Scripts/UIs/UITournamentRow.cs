using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

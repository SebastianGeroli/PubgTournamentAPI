using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewData",menuName ="Scriptables/Data")]
public class Data : ScriptableObject
{

#if UNITY_EDITOR
	[Multiline]
	public string DeveloperNotes;
#endif

	[SerializeField]
	public List<TournamentData> tournamentDatas; 


}

[System.Serializable]
public struct TournamentData
{
	public string id;
	public string date;
}

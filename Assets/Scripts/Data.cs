using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewData",menuName ="Scriptables/Data")]
public class Data : ScriptableObject
{

#if UNITY_EDITOR
	[Multiline]
	public string DeveloperNotes; //Developer notes to see in the inspector in case its needed
#endif

	[SerializeField]
	public List<TournamentData> tournamentDatas; //tournaments


}

[System.Serializable]
public struct TournamentData
{
	public string id;
	public string date;
}

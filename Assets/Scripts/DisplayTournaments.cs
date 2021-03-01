using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays Tournaments on start
/// </summary>
public class DisplayTournaments : MonoBehaviour
{

    public GameObject content;// gameobject parent where the rows will hook up
    public GameObject row; // prefab of the row desing

    public Data Data;//scriptable where information is going to be hold

    [SerializeField]
    private WebRequestInformation requestInformation;
    private void Start()
    {
        RequestTournaments();
    }

    /// <summary>
    /// Transforms the json from the tournaments api to data more easy to acces and control
    /// </summary>
    /// <param name="json">json from the api without modifications</param>
    public void ManageData(string json)
    {
        Data.tournamentDatas = new List<TournamentData>();//Clean the list of tournaments if it has something

        var N = SimpleJSON.JSON.Parse(json);

        foreach (var item in N["data"])
        {
            TournamentData tournamentData = new TournamentData();
            tournamentData.id = item.Value["id"];
            tournamentData.date = item.Value["attributes"]["createdAt"];

            Data.tournamentDatas.Add(tournamentData);
        }

        InstanciateRows();//Instanciate the rows in the scene
    }

    /// <summary>
    /// Use the list of tournamentDatas to create all the rows needed.
    /// </summary>
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

    /// <summary>
    /// Destroys all the childs in content, and makes a new request of tournaments.
    /// Note: this can be improved instead of destroying every child, we could change 
    /// its values and destroy/hide the necessary ones, and only instanciate if more are needed.
    /// </summary>
    public void RefreshTournaments()
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
     
        RequestTournaments();
    }

    private void RequestTournaments()
    {
        if (requestInformation == null)
        {
            Debug.LogError("WebRequestInformation missing, maybe set it in the editor?", this);
            return;
        }

        StartCoroutine(WebRequest.WebRequestGet(requestInformation.Uri, ManageData, requestInformation.Headers)); // request tournaments

    }
}

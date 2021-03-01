using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWebRequestInformation", menuName = "WebRequestInformation")]
public class WebRequestInformation : ScriptableObject
{

    [SerializeField]
    private string uri = "";

    public string Uri => uri;

    [SerializeField]
    private List<Header> headers = new List<Header>();

    public List<Header> Headers => headers;

}

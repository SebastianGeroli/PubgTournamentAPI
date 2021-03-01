using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Class wich is responsible for handling Web Requests
/// </summary>
public static class WebRequest
{
    /// <summary>
    /// Request All Tournaments in the api OLD
    /// </summary>
    /// <param name="callback">is called when the request is succesfull and has the json string</param>
    /// <returns></returns>
    public static IEnumerator RequestTournaments(Action<string> callback)
    {
        //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJiNTNhNjk5MC01YjUyLTAxMzktNzhhNi03ZGE4YmZmYTllYzAiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE0NDQ4NDQ1LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6Ii02Mjk3YWU3OC02ZTU4LTQ4M2YtOWI0YS01NTA3YTU1ZWRjYzQifQ.4dDeddiz_r8sjKyH8zgd4b8PPp165KbE2QvvslPg-dc
        //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJmYTRjNWVmMC0xZTllLTAxMzktODA2Zi02ZGJhODM4MmNiYjQiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjA3Nzc0MTgyLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InRlc3RpbmdhcGkifQ.dlCPoKv7uWpgjLC_mylZvpwONDy1M9VQ6NCjNrxeA40
        UnityWebRequest myWww = UnityWebRequest.Get("https://api.pubg.com/tournaments");
        myWww.SetRequestHeader("accept", "application/vnd.api+json");
        myWww.SetRequestHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJiNTNhNjk5MC01YjUyLTAxMzktNzhhNi03ZGE4YmZmYTllYzAiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE0NDQ4NDQ1LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6Ii02Mjk3YWU3OC02ZTU4LTQ4M2YtOWI0YS01NTA3YTU1ZWRjYzQifQ.4dDeddiz_r8sjKyH8zgd4b8PPp165KbE2QvvslPg-dc");

        yield return myWww.SendWebRequest();

        if (myWww.isNetworkError || myWww.isHttpError)
        {//handle errors here
            Debug.Log(myWww.error);
        }
        else
        {
            //Debug.Log(myWww.downloadHandler.text); 
            callback(myWww.downloadHandler.text);//callback with the json from the web request
        }


        yield return null;
    }

    /// <summary>
    /// Make a web request with method GET
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="headers">Headers to be passsed to the request</param>
    /// <param name="callback">method thats going to handle the response</param>
    /// <returns></returns>
    public static IEnumerator WebRequestGet(string uri, Action<string> callback, List<Header> headers = null)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);

        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.SetRequestHeader(header.name, header.value);
            }
        }

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)//handle errors here
        {
            Debug.LogError(request.error);
        }
        else
        {
            callback(request.downloadHandler.text);//callback with the response from the web
        }
    }
}

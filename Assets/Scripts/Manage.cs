using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(WebRequest.RequestTournaments());
	}
}

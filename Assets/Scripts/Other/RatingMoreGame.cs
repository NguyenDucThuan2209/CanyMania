﻿using UnityEngine;
using System.Collections;

public class RatingMoreGame : MonoBehaviour {

	public UnityEngine.UI.Image Rating;      // button rating
	public UnityEngine.UI.Image MoreGame;      // button more game
	public string package;
	public string developer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Rating
	/// </summary>
	public void GotoPlayStore()
	{		
		//Application.OpenURL ("market://details?id="+package+"");
		//Application.OpenURL ("market://details?q=pname:com.vinpearl.jewelsdeluxe");
		Application.OpenURL ("market://details?id="+Application.identifier+"");
	}



	// <summary>
	/// More game
	/// </summary>
	public void GotoMoreGame()
	{		
		//Application.OpenURL ("market://search?id=Vinpearl+Studio");
		//Application.OpenURL ("market://search?id="+developer+"");
		Application.OpenURL ("market://search?id="+Application.companyName+"");
	}
}

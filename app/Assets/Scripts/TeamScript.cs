﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TeamScript : MonoBehaviour {
	
	public void homeClicked() {
		SceneManager.LoadScene("HomeScene");
	}

}

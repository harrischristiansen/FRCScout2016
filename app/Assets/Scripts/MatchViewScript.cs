using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MatchViewScript : MonoBehaviour {
	
	public void homeClicked() {
		SceneManager.LoadScene("HomeScene");
	}

}

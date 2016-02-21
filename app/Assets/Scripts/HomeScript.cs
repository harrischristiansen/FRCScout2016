using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HomeScript : MonoBehaviour {

	public static string mode = "Scouting";

	public void pitClicked() {
		mode = "Scouting";
		SceneManager.LoadScene("TeamsScene");
	}

	public void matchClicked() {
		mode = "Scouting";
		SceneManager.LoadScene("MatchesScene");
	}

	public void teamsClicked() {
		mode = "Viewing";
		SceneManager.LoadScene("TeamsScene");
	}

	public void matchesClicked() {
		mode = "Viewing";
		SceneManager.LoadScene("MatchesScene");
	}
	
	public void logoutClicked() {
		LoginScript.logout();
		SceneManager.LoadScene("LoginScene");
	}
}

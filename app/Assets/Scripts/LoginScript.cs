using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginScript : MonoBehaviour {

	public static string teamNum;
	public static string username;

	private string password;

	void Start () {
		string user = PlayerPrefs.GetString("username", "");
		if(user != "") {
			username = user;
			teamNum = PlayerPrefs.GetString("teamNum", "");
			SceneManager.LoadScene("HomeScene");
		}
		// TODO: Check if already logged in
	}

	public void setUsername(string user) {
		username = user;
	}

	public void setPassword(string pass) {
		this.password = pass;
	}
	
	public void loginClicked() {
		// TODO: Login Validation/Check

		PlayerPrefs.SetString("username", username);
		PlayerPrefs.SetString("teamNum", "TODO");
		PlayerPrefs.Save();
		Debug.Log("Login Clicked: "+username+", "+password);
		SceneManager.LoadScene("HomeScene");
	}

	public void registerClicked() {
		SceneManager.LoadScene("RegisterScene");
	}

	public static void logout() { // Call to logout user
		PlayerPrefs.SetString("username", "");
		PlayerPrefs.SetString("teamNum", "");
		PlayerPrefs.Save();
	}
}

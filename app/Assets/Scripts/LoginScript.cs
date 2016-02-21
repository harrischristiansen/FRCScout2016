using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoginScript : MonoBehaviour {
	public static string APIURL = "http://localhost:8888/";

	public static string teamNum;
	public static string username;

	private string password;
	private bool loggedIn = false;

	private Text errorMsg;

	void Start() {
		loggedIn = false;
		errorMsg = GameObject.Find("ErrorMsg").GetComponent<Text>();

		string user = PlayerPrefs.GetString("username", "");
		if(user != "") {
			username = user;
			teamNum = PlayerPrefs.GetString("teamNum", "");
			SceneManager.LoadScene("HomeScene");
		}
	}

	void Update() {
		if(loggedIn) {
			loggedIn = false;
			PlayerPrefs.SetString("username", username);
			PlayerPrefs.SetString("teamNum", teamNum);
			PlayerPrefs.Save();
			SceneManager.LoadScene("HomeScene");
		}
	}

	public void setUsername(string user) {
		username = user;
	}

	public void setPassword(string pass) {
		password = pass;
	}

	public void loginClicked() {
		if(username == null || username == "") {
			errorMsg.text = "Please Enter A Username";
		} else if(password == null || password == "") {
			errorMsg.text = "Please Enter A Password";
		} else {
			StartCoroutine(checkLogin());
		}
	}

	IEnumerator checkLogin() { // Verify username and password
		string passHash = formatScript.GetMd5Hash(password);
		string loginURL = APIURL + "login/" + WWW.EscapeURL(username) + "/" + passHash;
		WWW loginObject = new WWW(loginURL);
		yield return loginObject;
		if (loginObject.error != null) { Debug.Log("Connection Failed: " + loginObject.error); }

		if(loginObject.text != "true") {
			if(loginObject.text == "invalid") {
				errorMsg.text = "Invalid Username Or Password";
			} else {
				errorMsg.text = "An Unknown Error Occured";
			}
			return false;
		}

		string getTeamURL = APIURL + "user-team/" + WWW.EscapeURL(username);
		WWW getTeamObject = new WWW(getTeamURL);
		yield return getTeamObject;
		if (getTeamObject.error != null) { Debug.Log("Connection Failed: " + getTeamObject.error); }
		teamNum = getTeamObject.text;

		loggedIn = true;
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

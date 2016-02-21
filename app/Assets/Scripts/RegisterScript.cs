using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class RegisterScript : MonoBehaviour {
	private string username;
	private string password;
	private string password2;
	private string team;
	private bool registered;

	private Text errorMsg;

	void Start () {
		registered = false;
		errorMsg = GameObject.Find("ErrorMsg").GetComponent<Text>();
	}

	void Update() {
		if(registered) { // Register Success, Login User
			registered = false;
			PlayerPrefs.SetString("username", username);
			LoginScript.username = username;
			PlayerPrefs.SetString("teamNum", team);
			LoginScript.teamNum = team;
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

	public void setPassword2(string pass) {
		password2 = pass;
	}

	public void setTeam(string team) {
		this.team = team;
	}
	
	public void backClicked() {
		SceneManager.LoadScene("LoginScene");
	}

	public void registerClicked() {
		if(username == null || username == "") {
			errorMsg.text = "Please Enter A Username";
		} else if(password == null || password == "") {
			errorMsg.text = "Please Enter A Password";
		} else if(password != password2) {
			errorMsg.text = "Passwords Do Not Match";
		} else if(team == null || team == "") {
			errorMsg.text = "Please Enter A Team";
		} else {
			StartCoroutine(attemptRegister());
		}
	}

	IEnumerator attemptRegister() { // Verify username and password
		string passHash = formatScript.GetMd5Hash(password);
		string registerURL = LoginScript.APIURL + "register/" + WWW.EscapeURL(username) + "/" + passHash + "/" + team;
		WWW registerObject = new WWW(registerURL);
		yield return registerObject;
		if (registerObject.error != null) { Debug.Log("Connection Failed: " + registerObject.error); }

		if(registerObject.text != "true") {
			if(registerObject.text == "invalid") {
				errorMsg.text = "Invalid Team Number";
			} else if(registerObject.text == "taken") {
				errorMsg.text = "Username Unavailable";
			} else {
				errorMsg.text = "An Unknown Error Occured";
			}
			return false;
		}

		registered = true;
	}

}

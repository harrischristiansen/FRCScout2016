using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class RegisterScript : MonoBehaviour {

	private string username;
	private string password;
	private string password2;
	private string team;

	// Use this for initialization
	void Start () {
	
	}

	public void setUsername(string user) {
		this.username = user;
	}

	public void setPassword(string pass) {
		this.password = pass;
	}

	public void setPassword2(string pass) {
		this.password2 = pass;
	}

	public void setTeam(string team) {
		this.team = team;
	}
	
	public void backClicked() {
		SceneManager.LoadScene("LoginScene");
	}

	public void registerClicked() {
		// TODO: Register Submission/Validation

		Debug.Log("Register Clicked: "+username+", "+password+", "+password2+", "+team);
		SceneManager.LoadScene("HomeScene");
	}
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TeamSelectionScript : MonoBehaviour {

	public static int selectedTeam = 0;

	public GameObject GridForList;
	public GameObject ListPrefab;

	void Start () {
		// TODO: Load Teams
		int[] teams = new int[7] {3245, 3166, 987, 1717, 4166, 1234, 4321};
		foreach (int team in teams) {
			GameObject newItem = Instantiate (ListPrefab);
			newItem.transform.SetParent(GridForList.transform);
			newItem.GetComponentsInChildren<Text> ()[0].text = "Team "+team;
			newItem.name = "Team" + team;
			newItem.GetComponent<Button> ().onClick.AddListener (delegate { // Add On Click Event
				teamClicked(team);
			});
		}
	}
	
	public void backClicked() {
		SceneManager.LoadScene("HomeScene");
	}

	public void teamClicked(int team) {
		selectedTeam = team;

		if(HomeScript.mode == "Scouting") {
			SceneManager.LoadScene("PitScoutScene");
		} else if(HomeScript.mode == "Viewing") {
			SceneManager.LoadScene("TeamScene");
		}
	}
}

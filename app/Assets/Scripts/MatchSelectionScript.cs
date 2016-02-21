using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MatchSelectionScript : MonoBehaviour {

	public static int selectedMatch = 0;

	public GameObject GridForList;
	public GameObject ListPrefab;

	void Start () {
		// TODO: Load Matches
		int[] matches = new int[7] {1, 2, 3, 4, 5, 6, 7};
		foreach(int match in matches) {
			GameObject newItem = Instantiate (ListPrefab);
			newItem.transform.SetParent(GridForList.transform);
			newItem.GetComponentsInChildren<Text>()[0].text = "Match "+match;
			newItem.name = "Match" + match;
			newItem.GetComponent<Button>().onClick.AddListener (delegate { // Add On Click Event
				matchClicked(match);
			});
		}
	}
	
	public void backClicked() {
		SceneManager.LoadScene("HomeScene");
	}

	public void matchClicked(int match) {
		selectedMatch = match;

		if(HomeScript.mode == "Scouting") {
			SceneManager.LoadScene("MatchScoutScene");
		} else if(HomeScript.mode == "Viewing") {
			SceneManager.LoadScene("MatchViewScene");
		}
	}
}

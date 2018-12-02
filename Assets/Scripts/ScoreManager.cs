using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public int score;
	// Update is called once per frame
	public void Update() {
        GetComponent<TextMeshProUGUI>().SetText(score.ToString());
	}
}

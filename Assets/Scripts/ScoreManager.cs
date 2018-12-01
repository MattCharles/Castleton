using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public int score;
    private TextMeshProUGUI textMeshProUGUI;
	// Update is called once per frame
	public void Update() {
        GetComponent<TextMeshProUGUI>().SetText(score.ToString());
	}
}

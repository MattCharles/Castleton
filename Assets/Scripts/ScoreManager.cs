using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public Player player;
	// Update is called once per frame
	public void Update() {
        GetComponent<TextMeshProUGUI>().SetText(player.GetScore().ToString());
	}
}

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public IActor actor;
	// Update is called once per frame
	public void Update() {
        GetComponent<TextMeshProUGUI>().SetText(actor.GetScore().ToString());
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PH : MonoBehaviour {

    public bool player1;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player1)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.HSVToRGB((GameController.player1Ph + 7f) / 14f, 0.8f, 0.8f);
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().color = Color.HSVToRGB((GameController.player2Ph + 7f) / 14f, 0.8f, 0.8f);
        }
    }
}

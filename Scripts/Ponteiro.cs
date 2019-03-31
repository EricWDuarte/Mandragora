using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponteiro : MonoBehaviour {

    public bool player1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30f * GameController.player1Temperature / 80f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 30f * GameController.player2Temperature / 80f);
        }
    }
}

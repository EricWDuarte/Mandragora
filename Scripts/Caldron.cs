using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caldron : MonoBehaviour {


    public void CallEffect(Card card)
    {
        if (transform.parent.GetComponentInChildren<Hand>().player1 == true)
        {
            GameController.player1Ph += card.ph;
            GameController.player1Temperature += card.temperature;
        } else
        {
            GameController.player2Ph += card.ph;
            GameController.player2Temperature += card.temperature;
        }

        GameController.player1Turn = !GameController.player1Turn;
        GameController.NewTurn();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

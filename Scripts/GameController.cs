using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public static int player1Ph = 0;
    public static int player2Ph = 0;

    public static int player1Temperature = 0;
    public static int player2Temperature = 0;

    float player1TruePh = 0;
    float player2TruePh = 0;


    public static int pressure = 10000;

    public static bool player1Turn = true;

    public static bool loseGame = true;


    public Hand player1Hand;
    public Hand player2Hand;

    public Text ph1;
    public Text ph2;
    public Text temp1;
    public Text temp2;
    public Text press;

    public Text loseScreen;
    public GameObject lose;

    public static void NewTurn()
    {
        GameController game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (game.player1Hand.player1 == player1Turn)
        {
            game.player1Hand.NewTurn();
        } else
        {
            game.player2Hand.NewTurn();
        }


        if (player1Temperature * player1Ph > 0)
        {
            game.player1TruePh = player1Ph * ((player1Temperature / 80f * 0.25f) + 1f);
        } else
        {
            game.player1TruePh = player1Ph * (1f - (player1Temperature / 80f * 0.25f));
        }

        if (player2Temperature * player2Ph > 0)
        {
            game.player2TruePh = player2Ph * ((player2Temperature / 80f * 0.25f) + 1f);
        }
        else
        {
            game.player2TruePh = player2Ph * (1f - (player2Temperature / 80f * 0.25f));
        }

        pressure = Mathf.RoundToInt(10000f + (10000f * (player1Temperature + player2Temperature) / 120f));

        



        if (game.player1TruePh > 7 || game.player1TruePh < -7 || player1Temperature > 80 || player1Temperature < -80)
        {
            game.Player1Lose();
        }
        if (game.player2TruePh > 7 || game.player2TruePh < -7 || player2Temperature > 80 || player2Temperature < -80)
        {
            game.Player2Lose();
        }
        if (pressure > 20000 || pressure < 0)
        {
            game.Empate();
        }
    }

    private void Update()
    {
        ph1.text = "Ph: " + player1TruePh;
        ph2.text = "Ph: " + player2TruePh;
        temp1.text = "Temperature: " + player1Temperature;
        temp2.text = "Temperature: " + player2Temperature;
        press.text = "Pressure: " + pressure;
    }


    void Player1Lose()
    {
        loseScreen.text = "Player 1 Lost";
        loseGame = true;
        lose.SetActive(true);
    }

    void Player2Lose()
    {
        loseScreen.text = "Player 2 Lost";
        loseGame = true;
        lose.SetActive(true);

    }

    void Empate()
    {
        loseScreen.text = "Draw";
        loseGame = true;
        lose.SetActive(true);


    }

    public void Restart ()
    {
    player1Ph = 0;
    player2Ph = 0;

    player1Temperature = 0;
    player2Temperature = 0;

    player1TruePh = 0;
    player2TruePh = 0;


    pressure = 10000;

    player1Turn = true;

    loseGame = false;
    lose.SetActive(false);


    }

}

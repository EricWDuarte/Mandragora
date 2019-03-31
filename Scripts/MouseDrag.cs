using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    private Transform player;
    private Hand hand;
    private CardDisplay card;

    public static Transform CardHold;
    private float distance = 10f;
    private Vector3 initPos;

    private Deck deck;

    private bool holding = false;

    private void Start()
    {
        hand = transform.parent.GetComponent<Hand>();
        player = transform.parent.parent.GetComponent<Transform>();
        deck = player.GetComponentInChildren<Deck>();

    }

    private void OnMouseDown()
    {
        if (hand.player1 == GameController.player1Turn && GameController.loseGame == false)
        {
            holding = true;
            CardHold = transform;
            Cursor.visible = false;
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 ObjPos = Camera.main.ScreenToWorldPoint(mousePos);

            initPos = -transform.position + ObjPos;
        }
    }

    private void OnMouseDrag()
    {
        if (hand.player1 == GameController.player1Turn && GameController.loseGame == false)
        {
            Cursor.visible = false;
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 ObjPos = Camera.main.ScreenToWorldPoint(mousePos) - initPos;

            transform.position = ObjPos;
        }
    }

    private void OnMouseUp()
    {
        if (hand.player1 == GameController.player1Turn && GameController.loseGame == false)
        {
            Cursor.visible = true;
            holding = false;
            Invoke("ClearHold", 0.2f);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hand.player1 == GameController.player1Turn && GameController.loseGame == false)
        {
            if (CardHold != null && holding == false && collision.transform.tag == "Caldron")
            {
                collision.transform.GetComponent<Caldron>().CallEffect(card.card);
                GoToDeck();
            }
        }
    }

    private void ClearHold ()
    {
        CardHold = null;
    }

    public void GoToDeck ()
    {
        transform.position = deck.transform.position;
        transform.GetComponentInChildren<CardDisplay>().card = Deck.empty;
        hand.cardsInHand.Remove(transform.GetComponentInChildren<CardDisplay>().card);
        hand.Reorganize(transform);
        gameObject.SetActive(false);
    }

    

    void Update () {
        card = transform.GetComponentInChildren<CardDisplay>();
    }
}

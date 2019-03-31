using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    private Transform player;

    public ArrayList cardsInHand = new ArrayList();
    public Transform[] cardSlots = new Transform[4];
    private Deck deck;

    public bool player1;

    void Start () {
        player = transform.parent.GetComponent<Transform>();
        deck = player.GetComponentInChildren<Deck>();
        NewTurn();

        for (int i = 0; i < cardSlots.Length; i++)
        {
            Card newCard = Draw();
            cardSlots[i].GetComponentInChildren<CardDisplay>().card = newCard;
            cardsInHand.Add(newCard);

            cardSlots[i].position = new Vector3(transform.position.x - 0.75f + (0.5f * i), transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    Card Draw()
    {
        return deck.cards[Random.Range(0, deck.cards.Length)];
    }

    public void Reorganize(Transform slot)
    {
        int index = 0;

        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (cardSlots[i] == slot)
            {
                index = i;
                break;
            }
        }

        for (int i = index; i > 0; i--)
        {
            cardSlots[i] = cardSlots[i - 1];
        }

        cardSlots[0] = slot;

    }

    public void NewTurn()
    {

        cardSlots[0].GetComponentInChildren<CardDisplay>().card = Draw();
        cardSlots[0].gameObject.SetActive(true);

        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (cardSlots[i].GetComponentInChildren<CardDisplay>().card = Deck.empty)
            {
                Card newCard = Draw();
                cardSlots[i].GetComponentInChildren<CardDisplay>().card = newCard;
                cardsInHand.Add(newCard);

            }

            cardSlots[i].position = new Vector3(transform.position.x - 0.75f + (0.5f * i), transform.position.y, 0);
        }
    }
}

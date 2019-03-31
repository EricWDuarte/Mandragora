using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

    public Card card = Deck.empty;
    private SpriteRenderer Art;

    private void Start()
    {
        Art = GetComponent<SpriteRenderer>();
        Art.sprite = card.artwork;
    }

    private void Update()
    {
        Art.sprite = card.artwork;
    }
}

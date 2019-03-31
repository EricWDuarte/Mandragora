using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public Card[] cards;
    public Card vazio;
    public static Card empty;

    private void Start()
    {
        empty = vazio;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO DO
public class spawnDeck : MonoBehaviour
{
    public makeDeck makeDeck;
    // Start is called before the first frame update
    void Start()
    {
        makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>();

    }

    // Update is called once per frame
    void Update()
    {
        //makeDeck.decks["deck1"];
    }

    void spawnCard() {

    }
}

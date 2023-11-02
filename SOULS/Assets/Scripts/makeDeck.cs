using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

//public class Card : MonoBehaviour { 

//    [JsonProperty("cardName")]
//    public string CardName { get; set; }
//    [JsonProperty("description")]
//    public string Description { get; set; }
//    [JsonProperty("attack")]
//    public string Attack { get; set; }
//    [JsonProperty("health")]
//    public string Health { get; set; }
//    [JsonProperty("skill")]
//    public string ?Skill { get; set; }
//    [JsonProperty("texture")]
//    public string Texture { get; set; }
//    [JsonProperty("borderColor")]
//    public string ?BorderColor { get; set; }
//    [JsonProperty("probability")]
//    public string Probability { get; set; }

//}
//public class Root : MonoBehaviour
//{
//    public List<Card>? cards {get; set; }
//}
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public int attack;
    public int health;
    public string? skill;
    public int texture;
    public string? borderColor;
    public int probability;
}

public class makeDeck : MonoBehaviour {

    public Dictionary<string, Stack<Card>> Decks;
    public Dictionary<string, List<Card>> Hands;
    //public List<Card> test;
    public List<Card> Cards;


    public void GameStart()
    {
        Decks = new(0);
        Hands = new(0);
        Decks.Add("deck1", CreateRandomDeck(25));
        Decks.Add("deck2", CreateRandomDeck(25));
        Hands.Add("hand1", new List<Card>());
        Hands.Add("hand2", new List<Card>());

        Draw("hand1", "deck1", 4);
        Draw("hand2", "deck2", 4);
    }

    void Awake()
    {
        //List<Card> cards = ScriptableObject.CreateInstance<List<Card>>();
        Cards = new(0);
        Card c1 = ScriptableObject.CreateInstance<Card>();
        c1.cardName = "Carla the Software Developer";
        c1.description = "A skilled programmer who develops software applications.";
        c1.attack = 3;
        c1.health = 4;
        c1.skill = null;
        c1.texture = 1;
        c1.borderColor = null;
        c1.probability = 1;
        Cards.Add(c1);

        Card c2 = ScriptableObject.CreateInstance<Card>();
        c2.cardName = "Carla the Software Developer";
        c2.description = "A skilled programmer who develops software applications.";
        c2.attack = 3;
        c2.health = 4;
        c2.skill = null;
        c2.texture = 1;
        c2.borderColor = null;
        c2.probability = 1;
        Cards.Add(c2);

        Card c3 = ScriptableObject.CreateInstance<Card>();
        c3.cardName = "Carla the Software Developer";
        c3.description = "A skilled programmer who develops software applications.";
        c3.attack = 3;
        c3.health = 4;
        c3.skill = null;
        c3.texture = 1;
        c3.borderColor = null;
        c3.probability = 1;
        Cards.Add(c3);

        Card c4 = ScriptableObject.CreateInstance<Card>();
        c4.cardName = "Carla the Software Developer";
        c4.description = "A skilled programmer who develops software applications.";
        c4.attack = 3;
        c4.health = 4;
        c4.skill = null;
        c4.texture = 1;
        c4.borderColor = null;
        c4.probability = 1;
        Cards.Add(c4);

        Card c5 = ScriptableObject.CreateInstance<Card>();
        c5.cardName = "Carla the Software Developer";
        c5.description = "A skilled programmer who develops software applications.";
        c5.attack = 3;
        c5.health = 4;
        c5.skill = null;
        c5.texture = 1;
        c5.borderColor = null;
        c5.probability = 1;
        Cards.Add(c5);
       
    }

    public Card DrawRandom()
    {
        var rand = new System.Random();
        return Cards[rand.Next(0,5)];
        
    }

    public Stack<Card> CreateRandomDeck(int numberOfCards)
    {
        Stack<Card> temp = new Stack<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            temp.Push(DrawRandom());
        }
        Stack<Card> deck = temp;
        return deck;
    }

    public void Draw(string hand, string deck, int draw_amount){
        if (Decks[deck].Peek() == null) return;
        while (Decks[deck].Peek() != null && draw_amount > 0) {
            Hands[hand].Add(Decks[deck].Pop());
            draw_amount--;
        }
    }

    public void Discard(string hand, Card card) {
        if (Hands[hand].Contains(card) == false) return;
        Hands[hand].Remove(card);
    }

}



//public void GameStart() {
//    Dictionary<string, Stack<Card>> decks = new();
//    decks.Add("deck1", CreateRandomDeck(25));
//    decks.Add("deck2", CreateRandomDeck(25));
//    Decks = decks;
//    Dictionary<string, List<Card>> hands = new();
//    hands.Add("hand1", new List<Card>());
//    hands.Add("hand2", new List<Card>());
//    Hands = hands;
//    Draw("hand1", "deck1", 4);
//    Draw("hand2", "deck2", 4);
//}

//void Awake()
//{
//    List<Card> cards = new List<Card>();

//    cards.Add(new Card
//    {
//        cardName = "Carla the Software Developer",
//        description = "A skilled programmer who develops software applications.",
//        attack = 3,
//        health = 4,
//        skill = null,
//        texture = 1,
//        borderColor = null,
//        probability = 1
//    });

//    cards.Add(new Card
//    {
//        cardName = "Samuel the Doctor",
//        description = "A medical professional who diagnoses and treats illnesses.",
//        attack = 2,
//        health = 6,
//        skill = null,
//        texture = 2,
//        borderColor = null,
//        probability = 1
//    });

//    cards.Add(new Card
//    {
//        cardName = "Eric the Architect",
//        description = "A professional who designs buildings and structures.",
//        attack = 2,
//        health = 3,
//        skill = null,
//        texture = 3,
//        borderColor = null,
//        probability = 1
//    });

//    cards.Add(new Card
//    {
//        cardName = "Jason the Chef",
//        description = "A culinary expert who creates delicious dishes.",
//        attack = 5,
//        health = 2,
//        skill = null,
//        texture = 4,
//        borderColor = null,
//        probability = 1
//    });

//    cards.Add(new Card
//    {
//        cardName = "Nikki the Lawyer",
//        description = "A legal expert who provides advice and represents clients in court.",
//        attack = 3,
//        health = 4,
//        skill = null,
//        texture = 5,
//        borderColor = null,
//        probability = 1
//    });

//    Cards = cards;
//}
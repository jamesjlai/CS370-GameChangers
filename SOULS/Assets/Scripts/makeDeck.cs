using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;

public class Card : MonoBehaviour { // card class for card variables
    public string CardName { get; set; }
    public string Description { get; set; }
    public int Attack { get; set; }
    public int Health { get; set; }
    public string Skill { get; set; }
    public int Texture { get; set; }
    public string BorderColor { get; set; }
    public int Probability { get; set; }

    public override string ToString()
    {
        return $"{CardName} - {Description} (Attack: {Attack}, Health: {Health}, Skill: {Skill ?? "None"}, Texture: {Texture}, BorderColor: {BorderColor ?? "None"}, Probability: {Probability})";
    }
}
//public class CardsContainer
//{
//    List<Card> cp { get; set; }
//}

public class makeDeck : MonoBehaviour{ // make deck class, instatiate for decks and card_pool
    
    
    public Dictionary<string, object> globalVariables = new Dictionary<string, object>();
    public List<Card> card_pool;
    
    public void GameStart(){
        DeserializeCards();
        //globalVariables.Add("deck1", CreateRandomDeck(card_pool, 25));
        //globalVariables.Add("deck2", CreateRandomDeck(card_pool, 25));
        //globalVariables.Add("hand1", new List<Card>());
        //globalVariables.Add("hand2", new List<Card>());
        //Draw(hand1, deck1, 4);
        //Draw(hand2, deck2, 4);
    }

    public void DeserializeCards()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "Cards.json";
        string jsonData = File.ReadAllText(path);
        this.card_pool = JsonConvert.DeserializeObject<List<Card>>(jsonData);
    }

    public static Card DrawRandom(List<Card> pool)
    {
        Random random = new();
        int randomIndex = random.Next(pool.Count);
        Card originalCard = pool[randomIndex];
        return originalCard;
    }

    public static Stack<Card> CreateRandomDeck(List<Card> pool, int numberOfCards)
    {
        Stack<Card> deck = new Stack<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            deck.Push(DrawRandom(pool));
        }
        Stack<Card> temp = deck;
        return deck;
    }

    public void Draw(string hand, string deck, int draw_amount){
        if (globalVariables[deck].Peek() == null) throw new InvalidOperationException("Deck Empty");;
        while(deck.Peek() != null && draw_amount > 0) {
            globalVariables[hand].Add(globalVariables[deck].Pop());
            draw_amount--;
        }
    }

    public void Discard(string hand, Card card) {
        if (globalVaraibles[hand].Contains(card) == false) throw new InvalidOperationException("Card not in hand.");
        globalVariables[hand].Remove(card);
    }

}

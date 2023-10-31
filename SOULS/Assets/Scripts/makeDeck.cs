using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Random = System.Random;
using UnityEngine;
using UnityEngine.Events;

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

public class makeDeck : MonoBehaviour{ // make deck class, instatiate for decks and card_pool


    public Dictionary<string, Stack<Card>> decks = new();
    public Dictionary<string, List<Card>> hands = new();
    public List<Card> card_pool;

    void Start()
    {
        this.GameStart();
    }
    public void GameStart(){
        DeserializeCards();
        decks.Add("deck1", CreateRandomDeck(card_pool, 25));
        decks.Add("deck2", CreateRandomDeck(card_pool, 25));
        hands.Add("hand1", new List<Card>());
        hands.Add("hand2", new List<Card>());
        Draw("hand1", "deck1", 4);
        Draw("hand2", "deck2", 4);
    }

    public void DeserializeCards()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Cards/Cards.Json");
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
        if (decks[deck].Peek() == null) return;
        while (decks[deck].Peek() != null && draw_amount > 0) {
            hands[hand].Add(decks[deck].Pop());
            draw_amount--;
        }
    }

    public void Discard(string hand, Card card) {
        if (hands[hand].Contains(card) == false) return;
        hands[hand].Remove(card);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{   public GameObject cardPrefab; // Reference to your card prefab
    public Transform[] cardPositions;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateCards(){
        foreach (Transform position in cardPositions)
        {
            Instantiate(cardPrefab, position.position, position.rotation);
        }
    
    }
}

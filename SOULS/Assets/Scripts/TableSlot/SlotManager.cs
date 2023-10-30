using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject selectedCard;  // Reference to the card object
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    private int userNumber = 0;
    private bool isInputValid = false; // Flag to control input validation

    public void slot()
    {
        while (!isInputValid)
        {
            CheckForNumberInput();
        }
    }

    private void CheckForNumberInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            userNumber = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            userNumber = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            userNumber = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            userNumber = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            userNumber = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            userNumber = 6;
        }

        if (userNumber >= 1 && userNumber <= 6)
        {
            Debug.Log("Valid input: " + userNumber);
            isInputValid = true; // Set the flag to true to exit input checking
        }
        else
        {
            Debug.Log("Please enter a number from 1 to 6.");
        }
    }
}

/*
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cardHolders.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }

        // Check for input to place the selected card
        if (selectedCard != null && selectedSlot >= 0 && !IsSlotOccupied(selectedSlot))
        {
            PlaceCard(selectedSlot);
        }
    }

    void SelectSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < cardHolders.Length)
        {
            selectedSlot = slotIndex;
            Debug.Log("Selected slot: " + cardHolders[slotIndex].name);
        }
    }

    bool IsSlotOccupied(int slotIndex)
    {
        return occupiedSlots[slotIndex] != null;
    }

    void PlaceCard(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < cardHolders.Length)
        {
            if (!IsSlotOccupied(slotIndex))
            {
                GameObject cardHolder = cardHolders[slotIndex];
                GameObject newCardObject = Instantiate(cardObjectPrefab, cardHolder.transform);
                newCardObject.transform.localPosition = Vector3.zero; // You may need to adjust the card's position.
                occupiedSlots[slotIndex] = newCardObject; // Mark the slot as occupied
                selectedCard = null; // Reset the selected card
                selectedSlot = -1; // Reset the selected slot
                Debug.Log("Placed card in slot: " + cardHolders[slotIndex].name);
            }
            else
            {
                Debug.Log("Slot " + cardHolders[slotIndex].name + " is already occupied.");
            }
        }
    }
}
*/
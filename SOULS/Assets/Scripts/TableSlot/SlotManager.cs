using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject selectedCard;  // Reference to the card object
    public GameObject[] slots = new GameObject[6]; // Use an array to store slots

    private int userNumber = 0;

    public void slot()
    {
        Debug.Log("Button is clicked");

        int num = GetUserInput();

        // Use the valid user input for further logic here
        Debug.Log("User input: " + num);
    }

    private int GetUserInput()
    {
        int input = -1; // Initialize input to an invalid value

        while (input < 1 || input > 6)
        {
            Debug.Log("Enter a number from 1 to 6");

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                input = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                input = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                input = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                input = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                input = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                input = 6;
            }
        }

        // At this point, 'input' contains a valid number between 1 and 6
        HandleInput(input);

        return input;
    }

    private void HandleInput(int number)
    {
        // Input is a valid number between 1 and 6
        Debug.Log("Valid input between 1 and 6 detected: " + number);
        userNumber = number; // Store the input for later use
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
namespace TableSlot;
using UnityEngine;

public class CardSlotManager : MonoBehaviour
{
    public Transform[] backSlots;
    public Transform[] frontSlots;
    public GameObject cardPrefab; // Prefab of your card object.

    void Update()
    {
        // Check if the front slots are empty.
        bool frontSlotsEmpty = true;
        foreach (Transform slot in frontSlots)
        {
            if (slot.childCount > 0)
            {
                frontSlotsEmpty = false;
                break;
            }
        }

        if (frontSlotsEmpty)
        {
            // Move cards from back slots to front slots.
            foreach (Transform backSlot in backSlots)
            {
                if (backSlot.childCount > 0)
                {
                    Transform card = backSlot.GetChild(0);
                    card.SetParent(null);
                    card.SetParent(GetAvailableFrontSlot());
                }
            }
        }
    }

    private Transform GetAvailableFrontSlot()
    {
        // Find an available front slot.
        foreach (Transform slot in frontSlots)
        {
            if (slot.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }

    public void AddCardToBackSlot()
    {
        // Instantiate and add a new card to a back slot.
        Instantiate(cardPrefab, GetAvailableBackSlot());
    }

    private Transform GetAvailableBackSlot()
    {
        // Find an available back slot.
        foreach (Transform slot in backSlots)
        {
            if (slot.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }
}

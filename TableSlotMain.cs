namespace TableSlot;
using System;

class TableSlotMain
{
    static void Main()
    {
        // Create some game pieces
        GamePiece piece1 = new GamePiece("Piece 1");
        GamePiece piece2 = new GamePiece("Piece 2");

        // Create table slots
        TableSlot slot1 = new TableSlot();
        TableSlot slot2 = new TableSlot();

        // Place game pieces into slots
        slot1.PlacePiece(piece1);
        slot2.PlacePiece(piece2);

        // Check if slots are occupied
        Console.WriteLine($"Slot 1 occupied: {slot1.IsOccupied}");
        Console.WriteLine($"Slot 2 occupied: {slot2.IsOccupied}");

        // Get the names of occupying pieces
        if (slot1.IsOccupied)
        {
            Console.WriteLine($"Slot 1 contains {slot1.OccupyingPiece.Name}");
        }

        if (slot2.IsOccupied)
        {
            Console.WriteLine($"Slot 2 contains {slot2.OccupyingPiece.Name}");
        }

        // Remove pieces from slots
        slot1.RemovePiece();
        slot2.RemovePiece();

        Console.WriteLine($"Slot 1 occupied: {slot1.IsOccupied}");
        Console.WriteLine($"Slot 2 occupied: {slot2.IsOccupied}");
    }
}

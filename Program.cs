using System;

namespace ChipSecuritySystem
{
    class Program
    {

        static void Main(string[] args)
        {
            // Create a sample chip
            ChipBag chip = new ChipBag();

            //Example 1
            //chip.AddChipCombination(5, new ColorChip(Color.Orange, Color.Purple), 1);
            //chip.AddChipCombination(2, new ColorChip(Color.Blue, Color.Yellow), 2);
            //chip.AddChipCombination(0, new ColorChip(Color.Red, Color.Green), 3);
            //chip.AddChipCombination(3, new ColorChip(Color.Yellow, Color.Red), 4);


            ////Example 2
            chip.AddChipCombination(2, new ColorChip(Color.Blue, Color.Green), 1);
            chip.AddChipCombination(2, new ColorChip(Color.Blue, Color.Green), 2);
            chip.AddChipCombination(2, new ColorChip(Color.Blue, Color.Yellow), 3);
            chip.AddChipCombination(1, new ColorChip(Color.Green, Color.Yellow), 4);
            chip.AddChipCombination(5, new ColorChip(Color.Orange, Color.Green), 5);
            chip.AddChipCombination(0, new ColorChip(Color.Red, Color.Orange), 6);
            chip.AddChipCombination(3, new ColorChip(Color.Yellow, Color.Blue), 7);
            chip.AddChipCombination(3, new ColorChip(Color.Yellow, Color.Red), 8);

            // Assumption of start and end color
            int StartColor = (int)Color.Blue;
            int EndColor = (int)Color.Green;

            Console.WriteLine($"Following are chip set from {(Color)StartColor}  to  {(Color)EndColor}");

            Console.WriteLine("\n");

            chip.CheckAllSequence(StartColor, EndColor);


            Console.Read();
        }


    }
}

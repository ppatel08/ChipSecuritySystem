using System;
using System.Collections.Generic;
using System.Linq;


namespace ChipSecuritySystem
{
    public class ChipBag
    {
        int NumOfColors;
        int index;
        List<VisitedChipSet> VisitedChipSetList = new List<VisitedChipSet>();
        List<ChipSet>[] ChipSetCombinationList;
        List<string> FinalColorChipList = new List<string>();


        // Constructor
        public ChipBag()
        {
            this.NumOfColors = Enum.GetNames(typeof(Color)).Length;

            InitChipSetCombinationList();
        }

        // Initialization chipset combination list
        private void InitChipSetCombinationList()
        {
            ChipSetCombinationList = new List<ChipSet>[NumOfColors];

            for (int i = 0; i < NumOfColors; i++)
            {
                ChipSetCombinationList[i] = new List<ChipSet>();
            }
        }

        // Add chip combination
        public void AddChipCombination(int startingNode, ColorChip colorChip, int sequence)
        {
            ChipSetCombinationList[startingNode].Add(new ChipSet(sequence, colorChip));
            VisitedChipSetList.Add(new VisitedChipSet() { Visited = false, ColorChip = colorChip, Sequence = sequence });
        }

        // Check all sequence of color chip
        public void CheckAllSequence(int start, int end)
        {
           
            FindAllPossiblePath(start, end, VisitedChipSetList, null);

            //Print output
            Console.WriteLine(FinalColorChipList.OrderByDescending(x => x.Length).First());
        }


       //Recursive function
        private void FindAllPossiblePath(int start, int end,
                                       List<VisitedChipSet> VisitedChipSetList,
                                       List<ChipSet> tempColorChipsList)
        {
            if (tempColorChipsList == null)
            {
                tempColorChipsList = new List<ChipSet>();
            }


            //If start and end chip are same then add to final list
            if (start.Equals(end))
            {
                //Add start color manually to print
                string message = Color.Blue.ToString();

                //Add subsequent color chips
                foreach (var l in tempColorChipsList)
                {
                    message += $" [{l.ColorChip.StartColor},{l.ColorChip.EndColor}] ";
                }

                //Add end color manually to print
                message += Color.Green.ToString();

                //Insert Distinct message only
                if (!FinalColorChipList.Contains(message))
                {
                    FinalColorChipList.Add(message);
                }
                return;
            }


            foreach (var i in ChipSetCombinationList[start])
            {
                index = VisitedChipSetList.FindIndex(x => x.Sequence == i.Sequence && x.Visited == false);

                if (index >= 0)
                {
                    VisitedChipSetList[index].Visited = true;

                    tempColorChipsList.Add(i);

                    FindAllPossiblePath((int)i.ColorChip.EndColor, end, VisitedChipSetList,
                                      tempColorChipsList);

                    tempColorChipsList.Remove(i);
                }
            }

            foreach (var item in VisitedChipSetList)
            {
                item.Visited = false;
            }

        }
    }
}

namespace ChipSecuritySystem
{
    public class ChipSet
    {
        public int Sequence { get; set; }
        public ColorChip ColorChip { get; set; }

        public ChipSet(int sequence, ColorChip colorChip)
        {
            this.Sequence = sequence;
            this.ColorChip = colorChip;
        }
    }
}

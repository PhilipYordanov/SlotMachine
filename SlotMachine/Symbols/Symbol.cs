namespace SlotMachine.Symbols
{
    public abstract class Symbol
    {
        public abstract char Sign { get; }

        public abstract double Coefficient { get; }

        public abstract int Probability { get; }

        public override string ToString()
        {
            return Sign.ToString();
        }
    }
}

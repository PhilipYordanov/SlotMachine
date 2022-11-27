namespace SlotMachine.Symbols
{
    public sealed class Wildcard : Symbol
    {
        public override char Sign => '*';

        public override double Coefficient => 0;

        public override int Probability => 5;
    }
}

using SlotMachine.Symbols;

internal sealed class AppleCoefficientProvider : SymbolCoefficientProvider
{
    protected override Type SymbolType() => typeof(Apple);
}

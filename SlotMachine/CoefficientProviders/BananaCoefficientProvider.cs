using SlotMachine.Symbols;

internal sealed class BananaCoefficientProvider : SymbolCoefficientProvider
{
    protected override Type SymbolType() => typeof(Banana);
}

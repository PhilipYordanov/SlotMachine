using SlotMachine.Symbols;

internal abstract class SymbolCoefficientProvider
{
    protected SymbolCoefficientProvider _successor;

    public void SetSuccessor(SymbolCoefficientProvider symbolCoefficientProvider)
    {
        _successor = symbolCoefficientProvider;
    }

    public double GetCoefficient(List<Symbol> symbols)
    {
        double coefficient = 0;
        int sameItemsCount = 0;

        foreach (var symbol in symbols)
        {
            if (symbol.GetType() == SymbolType() || symbol is Wildcard)
            {
                sameItemsCount++;
                coefficient += symbol.Coefficient;
            }
        }

        if (sameItemsCount == symbols.Count)
        {
            return coefficient;
        }

        if (_successor == null)
        {
            return 0;
        }

        return _successor.GetCoefficient(symbols);
    }

    protected abstract Type SymbolType();
}

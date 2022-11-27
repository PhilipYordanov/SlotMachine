using SlotMachine.Symbols;

public sealed class SimpleSlotMachine
{
    private const int Rows = 4;
    private const int NumberOfSymbolsOnARow = 3;
    private readonly Player _player;
    private readonly RandomSymbolGenerator _randomSymbolGenerator;

    public SimpleSlotMachine(Player player)
    {
        _player = player;
        _randomSymbolGenerator = new RandomSymbolGenerator();
    }

    public SpinResult Spin(decimal stakeAmount)
    {
        var rowsOfSymbols = new List<List<Symbol>>();
        double coefficient = 0;

        SymbolCoefficientProvider symbolCoefficientProvider;
        var pineappleCoefficientProvider = new PineapleCoefficientProvider();
        var bananaCoefficientProvider = new BananaCoefficientProvider();
        var appleCoefficientProvider = new AppleCoefficientProvider();

        pineappleCoefficientProvider.SetSuccessor(bananaCoefficientProvider);
        bananaCoefficientProvider.SetSuccessor(appleCoefficientProvider);
        symbolCoefficientProvider = pineappleCoefficientProvider;
        
        for (int i = 0; i < Rows; i++)
        {
            List<Symbol> symbols = _randomSymbolGenerator.Generate(NumberOfSymbolsOnARow);
            rowsOfSymbols.Add(symbols);
            coefficient += symbolCoefficientProvider.GetCoefficient(symbols);
        }

        decimal winAmount = (decimal)coefficient * stakeAmount;
        _player.IncreaseBalance(winAmount);

        var spinResult = new SpinResult(_player.Balance, winAmount, isSuccess: true);
        spinResult.Symbols = rowsOfSymbols;

        return spinResult;
    }
}

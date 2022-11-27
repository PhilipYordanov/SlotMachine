using SlotMachine.Symbols;

public class SpinResult
{
    public SpinResult(decimal playerBalance, decimal winAmount, bool isSuccess)
    {
        PlayerBalance = playerBalance;
        WinAmount = winAmount;
        IsSuccess = isSuccess;
    }

    public SpinResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public List<List<Symbol>> Symbols { get; set; } = new List<List<Symbol>>();

    public decimal PlayerBalance { get; }

    public decimal WinAmount { get; }

    public bool IsSuccess { get; }

    public string Message { get; }
}
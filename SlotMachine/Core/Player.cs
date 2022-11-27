public sealed class Player
{
    private decimal _balance;

    public Player(decimal balance)
    {
        this._balance = balance;
    }

    public decimal Balance => _balance;

    public void IncreaseBalance(decimal amount)
    {
        this._balance += Math.Round(amount, 2);
    }

    public void DecreaseBalance(decimal amount)
    {
        this._balance -= Math.Round(amount, 2);
    }
}

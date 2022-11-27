public sealed class ConsoleGameEngine
{
    private SimpleSlotMachine _slotMachine;
    private Player _player;
    private bool _isGameOver => _player.Balance <= 0;

    public void Run()
    {
        CreateNewGame();

        bool gameRun = true;
        while (gameRun)
        {
            decimal stake = RequestStake();
            SpinResult result = SpinMachine(stake);

            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                continue;
            }

            foreach (var rowOfSymbols in result.Symbols)
            {
                Console.WriteLine(string.Join(", ", rowOfSymbols));
            }

            Console.WriteLine($"You have won: {result.WinAmount:f2}");
            Console.WriteLine($"Current balance is: {result.PlayerBalance:f2}");

            if (_isGameOver)
            {
                gameRun = RequestNewGame();

                if (gameRun)
                {
                    CreateNewGame();
                }
            }
        }
    }

    private void CreateNewGame()
    {
        var deposit = DepositMoney();
        _player = new Player(deposit);

        _slotMachine = new SimpleSlotMachine(_player);
    }

    private SpinResult SpinMachine(decimal stakeAmount)
    {
        if (_player.Balance <= 0 || _player.Balance < stakeAmount)
        {
            return new SpinResult(isSuccess: false, string.Format($"Deposit more money to play. Current balance is {_player.Balance}"));
        }

        _player.DecreaseBalance(stakeAmount);
        SpinResult spinResult = _slotMachine.Spin(stakeAmount);

        return spinResult;
    }

    private decimal DepositMoney()
    {
        Console.WriteLine("Please deposit money you would like to play with:");
        bool isMoney = decimal.TryParse(Console.ReadLine(), out decimal money);
        while (!isMoney || money <= 0)
        {
            Console.WriteLine("Please enter a valid positive number");
            isMoney = decimal.TryParse(Console.ReadLine(), out money);
        }

        return money;
    }

    private decimal RequestStake()
    {
        Console.WriteLine("Enter stake amount:");
        bool isNumber = decimal.TryParse(Console.ReadLine(), out decimal stake);
        while (!isNumber || stake <= 0)
        {
            Console.WriteLine("Please enter a valid number for stake amount that is bigger than 0");
            isNumber = decimal.TryParse(Console.ReadLine(), out stake);
        }

        return stake;
    }

    private bool RequestNewGame()
    {
        Console.WriteLine("Your balance is 0. Would you like to insert more to play again? Y/N");
        string result = Console.ReadLine().ToLower();
        while (result != "y" && result != "n")
        {
            Console.WriteLine("Your balance is 0. Would you like to insert more to play again? Y/N");
            result = Console.ReadLine().ToLower();
        }

        return result == "y";
    }
}

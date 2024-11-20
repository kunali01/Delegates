using System;

// Define delegate for balance notifications
public delegate void BalanceNotification();

public class Bank
{
    private double balance;

    // Events for balance conditions
    public event BalanceNotification InsufficientBalance;
    public event BalanceNotification LowBalance;
    public event BalanceNotification ZeroBalance;

    // Constructor to set default balance
    public Bank(double initialBalance)
    {
        balance = initialBalance;
        CheckBalance();
    }

    // Credit method to add an amount to the balance
    public void Credit(double amount)
    {
        balance += amount;
        Console.WriteLine($"Credited: {amount}");
        CheckBalance();
    }

    // Debit method to deduct an amount from the balance
    public void Debit(double amount)
    {
        if (amount > balance)
        {
            InsufficientBalance?.Invoke(); // Trigger insufficient balance event
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Debited: {amount}");
            CheckBalance();
        }
    }

    // Check balance and trigger appropriate events
    private void CheckBalance()
    {
        if (balance == 0)
        {
            ZeroBalance?.Invoke(); // Trigger zero balance event
        }
        else if (balance < 3000)
        {
            LowBalance?.Invoke(); // Trigger low balance event
        }
    }

    // Method to get the current balance
    public double GetBalance() => balance;
}

public class Program
{
    static void InsufficientBalanceMsg()
    {
        Console.WriteLine("Insufficient balance for this transaction.");
    }

    static void LowBalanceMsg()
    {
        Console.WriteLine("Warning: Low balance.");
    }

    static void ZeroBalanceMsg()
    {
        Console.WriteLine("Balance is zero.");
    }

    public static void Main()
    {
        // Initialize bank account with a default balance
        Bank account = new Bank(2000);

        // Subscribe to events
        account.InsufficientBalance += InsufficientBalanceMsg;
        account.LowBalance += LowBalanceMsg;
        account.ZeroBalance += ZeroBalanceMsg;

        // Perform transactions
        account.Credit(1000);  // Adds to balance
        Console.WriteLine("Current Balance: " + account.GetBalance());

        account.Debit(500);    // Deducts from balance
        Console.WriteLine("Current Balance: " + account.GetBalance());

        account.Debit(3000);   // Should trigger insufficient balance event
        Console.WriteLine("Current Balance: " + account.GetBalance());

        account.Debit(2500);   // Brings balance to zero and triggers zero balance event
        Console.WriteLine("Current Balance: " + account.GetBalance());
    }
}

Bank bank = new(new ConsoleAuditLog());

bank.AddAccount(new CheckingAccount("CHK-1001", "Alice", 500M, overdraftLimit: 100M));
bank.AddAccount(new SavingsAccount("SAV-2001", "Bob", 1000M, interestRate: 0.05M));

bank.ProcessMonthlyUpdate();

foreach (Account account in bank.Accounts)
{
    account.Deposit(100M);
    bool withdrew = account.Withdraw(50M);

    Console.WriteLine($"{account.AccountNumber} {account.OwnerName}");
    Console.WriteLine($"  Type: {account.GetType().Name}");
    Console.WriteLine($"  Withdrawal succeeded: {withdrew}");
    Console.WriteLine($"  Balance: {account.Balance:C}");
}

public interface IAuditLog
{
    void Write(string message);
}

public class ConsoleAuditLog : IAuditLog
{
    public void Write(string message)
    {
        Console.WriteLine($"AUDIT: {message}");
    }
}

public abstract class Account
{
    public string AccountNumber { get; }
    public string OwnerName { get; }
    public decimal Balance { get; private set; }

    protected Account(string accountNumber, string ownerName, decimal openingBalance)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
        {
            throw new ArgumentException("Account number is required.");
        }

        if (string.IsNullOrWhiteSpace(ownerName))
        {
            throw new ArgumentException("Owner name is required.");
        }

        if (openingBalance < 0)
        {
            throw new ArgumentException("Opening balance cannot be negative.");
        }

        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = openingBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }

        Balance += amount;
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            return false;
        }

        Balance -= amount;
        return true;
    }

    protected void SetBalance(decimal value)
    {
        Balance = value;
    }

    public virtual void ApplyMonthlyUpdate()
    {
    }
}

public class CheckingAccount : Account
{
    public decimal OverdraftLimit { get; }

    public CheckingAccount(
        string accountNumber,
        string ownerName,
        decimal openingBalance,
        decimal overdraftLimit)
        : base(accountNumber, ownerName, openingBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (Balance - amount < -OverdraftLimit)
        {
            return false;
        }

        SetBalance(Balance - amount);
        return true;
    }
}

public class SavingsAccount : Account
{
    public decimal InterestRate { get; }

    public SavingsAccount(
        string accountNumber,
        string ownerName,
        decimal openingBalance,
        decimal interestRate)
        : base(accountNumber, ownerName, openingBalance)
    {
        InterestRate = interestRate;
    }

    public override void ApplyMonthlyUpdate()
    {
        Deposit(Balance * InterestRate / 12M);
    }
}

public class Bank
{
    private readonly List<Account> accounts = new();
    private readonly IAuditLog auditLog;

    public Bank(IAuditLog auditLog)
    {
        this.auditLog = auditLog;
    }

    public IReadOnlyList<Account> Accounts => accounts;

    public void AddAccount(Account account)
    {
        accounts.Add(account);
        auditLog.Write($"Added account {account.AccountNumber} for {account.OwnerName}.");
    }

    public void ProcessMonthlyUpdate()
    {
        foreach (Account account in accounts)
        {
            account.ApplyMonthlyUpdate();
            auditLog.Write($"Processed monthly update for {account.AccountNumber}.");
        }
    }
}

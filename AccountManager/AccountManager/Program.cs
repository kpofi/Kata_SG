// See https://aka.ms/new-console-template for more information

using AccountManager.Business;
using AccountManager.DataAccessLayer;
using AccountManager.Repository;
using System.Globalization;

var transactionRepository = new CsvTransactionRepository();
var balanceRepository = new CsvBalanceRepository();
var fxRateRepository = new CsvFxRateRepository();

var transactionDal = new TransactionDal(transactionRepository);
var balanceDal = new BalanceDal(balanceRepository);
var fxRateDal = new FxRateDal(fxRateRepository);
var accountService = new AccountService(transactionDal, balanceDal, fxRateDal);

while (true)
{
    Console.WriteLine("A quelle date voulez-vous consulter le solde de votre compte ? (format de date : JJ/MM/AAAA)");

    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
    {
        var balance = accountService.ComputeBalanceAt(date);
        Console.WriteLine($"Le solde du compte au {date.ToString("dd/MM/yyyy")} est de {Math.Round(balance, 2)} euros");
    }
    else
    {
        Console.WriteLine("Le format de la date n'est pas valide !");
    }
    Console.ReadKey();
}


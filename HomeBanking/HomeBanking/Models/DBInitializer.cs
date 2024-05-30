
namespace HomeBanking.Models
{
    public class DBInitializer
    {
        public static void Initialize(HomeBankingContext context)
        {
            if (!context.Clients.Any())
            {
                var clients = new Client[]
                {
                    new Client { Email = "vcoronado@gmail.com", FirstName="Victor", LastName="Coronado", Password="123456"},
                    new Client { Email = "marcos@gmail.com", FirstName="Marcos", LastName="Rodriguez", Password="123456"},
                    new Client { Email = "carlos@gmail.com", FirstName="Carlos", LastName="Gonzalez", Password="123456"},
                    new Client { Email = "agustina@gmail.com", FirstName="Agustina", LastName="Jimenez", Password="123456"},
                    new Client { Email = "ricardo@gmail.com", FirstName="Ricardo", LastName="Perez", Password="123456"}

                };

                context.Clients.AddRange(clients);

                //guardamos
                context.SaveChanges();

            }

            if (!context.Account.Any())
            {
                var client = context.Clients.FirstOrDefault(c => c.Email == "vcoronado@gmail.com");

                if (client != null)
                {
                    var accounts = new Account[]
                    {
                        new Account {ClientId = client.Id, CreationDate = DateTime.Now, Number = "VIN001", Balance = 100000 }
                    };

                    context.Account.AddRange(accounts);
                    context.SaveChanges();

                }
            }

            if (!context.Transactions.Any())
            {
                var account1 = context.Account.FirstOrDefault(c => c.Number == "VIN001");

                if (account1 != null)
                {
                    var transactions = new Transaction[]
                    {
                        new Transaction { AccountId= account1.Id, Amount = 20000, Date= DateTime.Now.AddHours(-5), Description = "Dinero acreditado en cuenta", Type = TransactionType.CREDIT },
                        new Transaction { AccountId= account1.Id, Amount = -2500, Date= DateTime.Now.AddHours(-6), Description = "Compra en verduleria", Type = TransactionType.DEBIT },
                        new Transaction { AccountId= account1.Id, Amount = -3500, Date= DateTime.Now.AddHours(-7), Description = "Compra en carniceria", Type = TransactionType.DEBIT },
                    };

                    context.Transactions.AddRange(transactions);
                 
                    context.SaveChanges();

                }
            }

            if (!context.Loans.Any())
            {
                //crearemos 3 prestamos Hipotecario, Personal y Automotriz
                var loans = new Loan[]
                {
                    new Loan { Name = "Hipotecario", MaxAmount = 500000, Payments = "12,24,36,48,60" },
                    new Loan { Name = "Personal", MaxAmount = 100000, Payments = "6,12,24" },
                    new Loan { Name = "Automotriz", MaxAmount = 300000, Payments = "6,12,24,36" },
                };

                context.Loans.AddRange(loans);

                context.SaveChanges();

                //ahora agregaremos los clientloan (Prestamos del cliente)
                //usaremos al primer cliente que tenemos y le agregaremos un préstamo de cada item
                var client1 = context.Clients.FirstOrDefault(c => c.Email == "vcoronado@gmail.com");
                if (client1 != null)
                {
                    //ahora usaremos los 3 tipos de prestamos
                    var loan1 = context.Loans.FirstOrDefault(l => l.Name == "Hipotecario");
                    if (loan1 != null)
                    {
                        var clientLoan1 = new ClientLoan
                        {
                            Amount = 450000,
                            ClientId = client1.Id,
                            LoanId = loan1.Id,
                            Payments = "48"
                        };
                        context.ClientLoans.Add(clientLoan1);
                    }

                    var loan2 = context.Loans.FirstOrDefault(l => l.Name == "Personal");
                    if (loan2 != null)
                    {
                        var clientLoan2 = new ClientLoan
                        {
                            Amount = 75000,
                            ClientId = client1.Id,
                            LoanId = loan2.Id,
                            Payments = "6"
                        };
                        context.ClientLoans.Add(clientLoan2);
                    }

                    var loan3 = context.Loans.FirstOrDefault(l => l.Name == "Automotriz");
                    if (loan3 != null)
                    {
                        var clientLoan3 = new ClientLoan
                        {
                            Amount = 230000,
                            ClientId = client1.Id,
                            LoanId = loan3.Id,
                            Payments = "36"
                        };
                        context.ClientLoans.Add(clientLoan3);
                    }

                    //guardamos todos los prestamos
                    context.SaveChanges();

                }

            }



        }
    }
}
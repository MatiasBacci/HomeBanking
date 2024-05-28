
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
                        new Account {ClientId = client.Id, CreationDate = DateTime.Now, Number = "VIN001", Balance = 0 }
                    };


                    context.Account.AddRange(accounts);
                    
                    context.SaveChanges();

                }
            }
        }
    }
}
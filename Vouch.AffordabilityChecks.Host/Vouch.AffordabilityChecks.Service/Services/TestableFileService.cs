using System;
using System.Collections.Generic;
using Vouch.AffordabilityChecks.Service.Models;

namespace Vouch.AffordabilityChecks.Service
{
    public class TestableFileService : IFileService
    {
        public UserFeed ReadFeed(string path)
        {
            List<BankStatement> statements = new() 
            {
                new BankStatement { Date = DateTime.Parse("01/12/2021"), Balance = 900, Details = "Food Exp", MoneyIn = 0, MoneyOut = 100, PaymentType = "BankCredit" },
                new BankStatement { Date = DateTime.Parse("02/12/2021"), Balance = 700, Details = "Car Insurance", MoneyIn = 0, MoneyOut = 200, PaymentType = "ATM " },
                new BankStatement { Date = DateTime.Parse("03/12/2021"), Balance = 800, Details = "Interest", MoneyIn = 100, MoneyOut = 0, PaymentType = "BankCredit" },
                new BankStatement { Date = DateTime.Parse("04/12/2021"), Balance = 700, Details = "Movie", MoneyIn = 0, MoneyOut = 100, PaymentType = "BankCredit" },
                new BankStatement { Date = DateTime.Parse("31/12/2021"), Balance = 2700, Details = "Salary", MoneyIn = 2000, MoneyOut = 0, PaymentType = "BankCredit" },

            };
            List<Property> properties = new()
            {
                new Property(1, "Property A", 700),
                new Property(2, "Property B", 800),
                new Property(3, "Property C", 2000)
            };

            return new UserFeed
            {
                BankStatements = statements,
                Properties = properties
            };
        }

    }
}

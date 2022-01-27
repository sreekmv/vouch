using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Vouch.AffordabilityChecks.Service;
using Vouch.AffordabilityChecks.Service.Models;
using Xunit;

namespace Vouch.AffordabilityChecks.Tests
{
    public class VerifyAffordabilityServiceFeature
    {
        public Mock<IFileService> mockFileService = new();
        public Mock<IAffordabilityService> affordabilityService = new();

        [Fact]
        public void CheckAffordabilityShouldReturnCountOfProperties()
        {
            //Arrange
            IAffordabilityService affordabilityService = new AffordabilityService();

            var expectedProperties = new List<Property>()
            {
                new Property(1,"Property A", 1000)
            };

            var statements = new List<BankStatement>()
            {
            new BankStatement{Date = DateTime.Parse("01/12/2021"),Balance = 900, Details = "Food Exp",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("02/12/2021"), Balance = 700, Details = "Car Insurance", MoneyIn = 0, MoneyOut = 200, PaymentType = "ATM "},
            new BankStatement{Date = DateTime.Parse("03/12/2021"),Balance = 800, Details = "Interest",MoneyIn = 100, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("04/12/2021"),Balance = 700, Details = "Movie",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/12/2021"),Balance = 2700, Details = "Salary",MoneyIn = 2000, MoneyOut = 0,PaymentType = "BankCredit"},


            new BankStatement{Date = DateTime.Parse("01/01/2022"),Balance = 2600, Details = "Food Exp",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("02/01/2022"), Balance = 2400, Details = "Car Insurance", MoneyIn = 0, MoneyOut = 200, PaymentType = "ATM "},
            new BankStatement{Date = DateTime.Parse("03/01/2022"), Balance = 1400, Details = "Car Insurance fine", MoneyIn = 0, MoneyOut = 1000, PaymentType = "ATM "},
            new BankStatement{Date = DateTime.Parse("05/01/2022"),Balance = 1500, Details = "Interest",MoneyIn = 100, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("11/01/2022"),Balance = 1400, Details = "Movie",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/01/2022"),Balance = 2400, Details = "Salary",MoneyIn = 2000, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/01/2022"),Balance = 3400, Details = "Friend",MoneyIn = 1000, MoneyOut = 0,PaymentType = "BankCredit"},

            };

            var properties = new List<Property>()
            {
                new Property(1,"Property A", 1000),
                new Property(2,"Property B", 2000),
                new Property(3,"Property C", 2500),
            };

            //Act
            var returnProperties = affordabilityService.Check(statements, properties);

            //Assert
            Assert.Equal(expectedProperties.Count, returnProperties.Count);
        }

        [Fact]
        public void AffordabilityCheckShouldReturnNullWhenRentIsMoreThanIncome()
        {
            //Arrange
            IAffordabilityService affordabilityService = new AffordabilityService();

            var statements = new List<BankStatement>()
            {
            new BankStatement{Date = DateTime.Parse("01/12/2021"),Balance = 900, Details = "Food Exp",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("02/12/2021"), Balance = 700, Details = "Car Insurance", MoneyIn = 0, MoneyOut = 200, PaymentType = "ATM "},
            new BankStatement{Date = DateTime.Parse("03/12/2021"),Balance = 800, Details = "Interest",MoneyIn = 100, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("04/12/2021"),Balance = 700, Details = "Movie",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/12/2021"),Balance = 2700, Details = "Salary",MoneyIn = 2000, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/12/2021"),Balance = 1200, Details = "Friend",MoneyIn = 0, MoneyOut = 500,PaymentType = "BankCredit"},

            };

            var properties = new List<Property>()
            {
                new Property(1,"Property A", 1500),
                new Property(2,"Property B", 2000),
                new Property(3,"Property C", 2500),
            };

            //Act
            var returnProperties = affordabilityService.Check(statements, properties);

            //Assert
            Assert.False(returnProperties.Any());
        }

        [Fact]
        public void AffordabilityCheckShouldReturnNullWhenExpensesAreMoreThanIncome()
        {
            //Arrange
            IAffordabilityService affordabilityService = new AffordabilityService();

            var statements = new List<BankStatement>()
            {
            new BankStatement{Date = DateTime.Parse("01/12/2021"),Balance = 900, Details = "Food Exp",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("02/12/2021"), Balance = 700, Details = "Car Insurance", MoneyIn = 0, MoneyOut = 200, PaymentType = "ATM "},
            new BankStatement{Date = DateTime.Parse("03/12/2021"),Balance = 800, Details = "Interest",MoneyIn = 100, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("04/12/2021"),Balance = 700, Details = "Movie",MoneyIn = 0, MoneyOut = 100,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/12/2021"),Balance = 2700, Details = "Salary",MoneyIn = 2000, MoneyOut = 0,PaymentType = "BankCredit"},
            new BankStatement{Date = DateTime.Parse("31/12/2021"),Balance = 1700, Details = "Friend",MoneyIn = 0, MoneyOut = 1000,PaymentType = "BankCredit"},

            };

            var properties = new List<Property>()
            {
                new Property(1,"Property A", 1000),
                new Property(2,"Property B", 2000),
                new Property(3,"Property C", 2500),
            };

            //Act
            var returnProperties = affordabilityService.Check(statements, properties);

            //Assert
            Assert.False(returnProperties.Any());
        }
    }
}

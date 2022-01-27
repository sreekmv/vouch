using System.Collections.Generic;
using System.Linq;
using Vouch.AffordabilityChecks.Service.Models;

namespace Vouch.AffordabilityChecks.Service
{
    public class AffordabilityService : IAffordabilityService
    {
        public List<Property> Check(List<BankStatement> statements, List<Property> properties)
        {
            List<Property> affordableProperties = new();

            statements = statements.Select(c => new BankStatement
            {
                Date = c.Date,
                Balance = c.Balance,
                Details = c.Details,
                MoneyIn = c.MoneyIn,
                MoneyOut = c.MoneyOut,
                Month = c.Date.Month
            }).ToList();

            //group by month, each month will have variations in expenses/income
            var statementsGroup = statements.GroupBy(c => c.Month)
                                    .Select(g => new 
                                    {
                                        Month = g.Key,
                                        Statements = g.ToList()
                                    }).ToList();

            foreach (var item in statementsGroup)
            {
                var monthlyRecIncome = item.Statements.Sum(c => c.MoneyIn);
                var monthlyRecExpense = item.Statements.Sum(c => c.MoneyOut);
                var leftOverByBal = monthlyRecIncome - monthlyRecExpense;

                //var leftOverByBal = item.Statements.OrderByDescending(c => c.Date).First().Balance;

                foreach (var prop in properties)
                {
                    if (leftOverByBal > (prop.RentPerMonthPence * 125 / 100))
                    {
                        if (!affordableProperties.Any(c => c.Id == prop.Id))
                            affordableProperties.Add(prop);
                    }
                    else if (affordableProperties.Any(c => c.Id == prop.Id))
                    {
                        affordableProperties.Remove(prop);
                    }
                }
            }

            return affordableProperties;
        }
    }
}

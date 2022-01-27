using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vouch.AffordabilityChecks.Service.Models;

namespace Vouch.AffordabilityChecks.Service
{
    public class FileService : IFileService
    {
        public UserFeed ReadFeed(string path)
        {
            List<BankStatement> statements = new();
            List<Property> properties = new();

            if(!Directory.Exists(path))
                return null;

            var files = Directory.GetFiles(path, "*.csv");

            if (!files.Any())
                return null;

            foreach (var item in files)
            {
                if (item.Contains("bank"))
                {
                    var statementArray = File.ReadAllLines(item);

                    foreach (var statement in statementArray)
                    {
                        var arr = statement.Split(',');
                        statements.Add(new BankStatement
                        {
                            Balance = GetValue(arr[5]),
                            Date = DateTime.Parse(arr[0]),
                            PaymentType = arr[1],
                            Details = arr[2],
                            MoneyIn = GetValue(arr[4]),
                            MoneyOut = GetValue(arr[3]),
                            
                        });
                    }
                    
                }
                else if(item.Contains("properties"))
                {
                    var propArray = File.ReadAllLines(item);

                    foreach (var prop in propArray)
                    {
                        var arr = prop.Split(',');

                        properties.Add(new Property(int.Parse(arr[0]), arr[1], int.Parse(arr[2])));

                    }
                }
            }

            return new UserFeed
            {
                BankStatements =statements,
                Properties = properties
            };
        }

        private static double GetValue(string val)
        {
           return string.IsNullOrEmpty(val) ? 0 : double.Parse(val);
        }
    }
}

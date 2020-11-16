using System;
using System.Collections.Generic;

namespace Entities.ValueObject
{
    public class Money: ValueObject
    {
        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(Amount, 2);
            yield return Currency.ToUpper();
        }
    }
}
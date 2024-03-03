using Gringotts.Banking.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Banking.Domain.Errors
{
    public class TransactionErrors
    {
        public static Error AmountInvalid => new(
        1212,
        "Transaction.Amount",
        "Transaction Amount is empty or invalid");

        public static Error TransactionTypeInvalid => new(
            1213,
            "Transaction.TransactionType",
            "Transaction TransactionType is empty or invalid");
    }
}

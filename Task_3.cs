using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Dedok
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public string OwnerName { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public string Pin { get; private set; }
        public decimal CreditLimit { get; private set; }
        public decimal Balance { get; private set; }
        public event Action<decimal> OnDeposit;
        public event Action<decimal> OnWithdraw;
        public event Action OnStartUsingCredit;
        public event Action OnLimitReached;
        public event Action OnPinChanged;
        public CreditCard(string cardNumber, string ownerName, DateTime expiryDate, string pin, decimal creditLimit)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpiryDate = expiryDate;
            Pin = pin;
            CreditLimit = creditLimit;
            Balance = 0;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            OnDeposit?.Invoke(amount);
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance + CreditLimit)
            {
                throw new InvalidOperationException("Сума перевищує доступний баланс та кредитний ліміт.");
            }

            if (amount > Balance)
            {
                OnStartUsingCredit?.Invoke();
            }

            Balance -= amount;
            OnWithdraw?.Invoke(amount);

            if (Balance < 0)
            {
                OnLimitReached?.Invoke();
            }
        }
        public void ChangePin(string newPin)
        {
            Pin = newPin;
            OnPinChanged?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        protected internal override event AccountStateHandler Added;
        protected internal override event AccountStateHandler Withdrawed;
        protected internal override event AccountStateHandler Opened;
        public DepositAccount(decimal sum, int percentage)
            : base(sum, percentage)
        {
        }
        protected internal override void OnOpened()
        {
            if (Opened != null)
                Opened(this, new AccountEventArgs("Deposit account is opened! Account Id: " + this.Id, _sum));
        }

        public override void Put(decimal sum)
        {
            if (_days % 30 == 0)
                base.Put(sum);
            else if (Added != null)
                Added(this, new AccountEventArgs("It is possible to put money to the account after 30 days only", 0));
        }

        public override decimal Withdraw(decimal sum)
        {
            if (_days % 30 == 0)
                return base.Withdraw(sum);
            else if (Withdrawed != null)
                Withdrawed(this, new AccountEventArgs("It is possible to withdraw money from the account after 30 days only", 0));
            return 0;
        }

        protected internal override void Calculate()
        {
            if (_days % 30 == 0)
                base.Calculate();
        }
    }
}

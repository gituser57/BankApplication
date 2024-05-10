using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class DemandAccount : Account
    {
        
        protected internal override event AccountStateHandler Opened;

        public DemandAccount(decimal sum, int percentage)
            : base(sum, percentage)
        {
        }

        protected internal override void OnOpened()
        {
            Opened(this, new AccountEventArgs("On demand account is open! Account Id: " + this.Id, _sum));
        }
    }
}

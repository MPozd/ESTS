using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Receiver
    {
        public bool SMSTransfer { get; set; }
        public bool WalletTransfer { get; set; }
        public bool BankingTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt)
        {
            SMSTransfer = bt;
            WalletTransfer = mt;
            BankingTransfer = ppt;
        }
    }
    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }
    class PaymentSMS : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.SMSTransfer == true)
                Console.WriteLine("Выполняем перевод через SMS");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class PaymentOnlineWallet : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.WalletTransfer == true)
                Console.WriteLine("Выполняем перевод через онлайн-кошелёк");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class PaymentBanking : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankingTransfer == true)
                Console.WriteLine("Выполняем перевод через банковский терминал");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
}

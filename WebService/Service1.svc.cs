using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebService.Models;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public WebServiceDbContext db = new WebServiceDbContext();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Acount GetAccount(string code, string pass)
        {
            var account = db.Acounts.Where(p => p.CustomerCode == code).Where(p => p.SercurityCode == pass).FirstOrDefault();
            return account;
        }

        public Boolean TransferMoney(string sCode, string rCode, double amount)
        {
            var sAcc = db.Acounts.Where(p => p.CustomerCode == sCode).FirstOrDefault();
            var rAcc = db.Acounts.Where(p => p.CustomerCode == rCode).FirstOrDefault();
            if (sAcc == null || rAcc == null || (sAcc.Money - rAcc.Money) < 0)
            {
                return false;
            }
            sAcc.Money -= amount;
            rAcc.Money += amount;
            db.SaveChanges();
            return true;
        }
    }
}

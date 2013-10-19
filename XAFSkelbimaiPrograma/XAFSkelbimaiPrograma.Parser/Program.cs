using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Core;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace XAFSkelbimaiPrograma.Parser
{
    class Program
    {
        static void Main(string[] args){
            UnitOfWork session2 = new UnitOfWork();
            session2.ConnectionString = "XpoProvider = Firebird; DataSource = localhost; User = sysdba; Password = masterkey; Database = XAF_DB; ServerType = 0; Charset = UTF8";
            var me = session2.FindObject<DLCEmployee>(CriteriaOperator.Parse("FullName = 'Ignas Bagdonas'"));
            Console.ReadKey(true);
        }

       
    }
}

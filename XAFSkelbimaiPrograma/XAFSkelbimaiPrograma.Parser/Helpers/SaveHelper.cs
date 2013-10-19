using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using XAFSkelbimaiPrograma.Parser.Plugins;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    class SaveHelper
    {
        public void SaveAdverts(List<AdvertDto> adverts)
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };

            foreach (AdvertDto advert in adverts)
            {
                SKAdvert advertXpo = new SKAdvert(session);
                advertXpo.Name = advert.Name;
                advertXpo.FoundDate = Convert.ToDateTime(advert.Date);
            }
        }
    }
}

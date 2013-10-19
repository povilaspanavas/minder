using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using XAFSkelbimaiPrograma.Module.SecurityModule;
using XAFSkelbimaiPrograma.Parser.Plugins;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    class SaveHelper
    {
       private Session m_session;

        public void SaveAdverts(List<AdvertDto> adverts)
        {
            m_session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            m_session.BeginTransaction();

            foreach (AdvertDto advert in adverts)
            {
                if (NeedSave(advert) == false)
                    continue;

                SKAdvert advertXpo = new SKAdvert(m_session);
                advertXpo.Name = advert.Name;
                advertXpo.FoundDate = advert.Date;
                advertXpo.FuelType = string.Empty; //TODO čia reikia padaryt
                advertXpo.Year = advert.Year;
                advertXpo.Link = advert.UrlLink;
                advertXpo.Price = advert.Price;
                advertXpo.SearchSetting = m_session.GetObjectByKey<SKUserSearchSettings>(advert.SettingsId);
                advertXpo.SKUser = m_session.GetObjectByKey<DLCEmployee>(advert.UserId);

                advertXpo.Save();
            }
            m_session.CommitTransaction();
        }

        private bool NeedSave(AdvertDto advert)
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            SKAdvert advertXpo = session.FindObject<SKAdvert>
                (CriteriaOperator.Parse(string.Format("Link = '{0}' And SKUser.Oid = '{1}'", 
               advert.UrlLink, advert.UserId)));

            if (advertXpo == null)
                return true;
            return false;
        }
    }
}

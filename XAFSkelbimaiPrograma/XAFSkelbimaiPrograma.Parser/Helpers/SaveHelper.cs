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
        private UserParseInfoDto m_info;

        public SaveHelper(Session session, UserParseInfoDto info)
        {
            m_session = session;
            m_info = info;
        }

        public void SaveAdverts(List<AdvertDto> adverts)
        {
            //m_session.BeginTransaction();
            lock (m_session)
            {
                List<SKAdvert> savedAdverts = new List<SKAdvert>();
                foreach (AdvertDto advert in adverts)
                {
                    if (NeedSave(advert) == false)
                        continue;

                    SKAdvert advertXpo = new SKAdvert(m_session);
                    advertXpo.Name = advert.Name;
                    advertXpo.FoundDate = advert.Date;
                    advertXpo.FuelType = advert.Column1; //TODO čia reikia padaryt
                    advertXpo.Year = advert.Year;
                    advertXpo.Link = advert.UrlLink;
                    advertXpo.Price = advert.Price;
                    advertXpo.Image = advert.Image;
                    advertXpo.SearchSetting = m_session.GetObjectByKey<SKUserSearchSettings>(advert.SettingsId);
                    advertXpo.SKUser = m_session.GetObjectByKey<DLCEmployee>(advert.UserId);
                    savedAdverts.Add(advertXpo);
                    advertXpo.Save();
                }
                if (m_info.Email && savedAdverts.Count != 0)
                    new EmailHelper(m_session).SendEmail(savedAdverts);
            }
            //m_session.CommitTransaction();

            
        }

        private bool NeedSave(AdvertDto advert)
        {
            //Using DirectSql

            //Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            //session.e
            string query = string.Format("SELECT \"Oid\" from \"SKAdvert\" where \"SKUser\" = '{0}' and \"Link\" = '{1}'", 
                advert.UserId, advert.UrlLink);
            object result = m_session.ExecuteScalar(query);
            //SKAdvert advertXpo = m_session.FindObject<SKAdvert>
            //    (CriteriaOperator.Parse(string.Format("Link = '{0}' And SKUser.Oid = '{1}'",
            //   advert.UrlLink, advert.UserId)));

            //if (advertXpo == null)
            //    return true;
            if (result != null)
                return false;
            return true;
        }
    }
}

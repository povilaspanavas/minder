//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
namespace XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects
{
  [DefaultClassOptions]
  public partial class SKUserSearchSettings : DevExpress.Persistent.BaseImpl.BaseObject
  {
    private XAFSkelbimaiPrograma.Module.SecurityModule.DLCEmployee _sKUser;
    private XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Classificators.SKPlugin _plugin;
    private System.String _url;
    private System.String _name;
    public SKUserSearchSettings(DevExpress.Xpo.Session session)
      : base(session)
    {
    }
    public System.String Name
    {
      get
      {
        return _name;
      }
      set
      {
        SetPropertyValue("Name", ref _name, value);
      }
    }
    public System.String Url
    {
      get
      {
        return _url;
      }
      set
      {
        SetPropertyValue("Url", ref _url, value);
      }
    }
    public XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Classificators.SKPlugin Plugin
    {
      get
      {
        return _plugin;
      }
      set
      {
        SetPropertyValue("Plugin", ref _plugin, value);
      }
    }
    public XAFSkelbimaiPrograma.Module.SecurityModule.DLCEmployee SKUser
    {
      get
      {
        return _sKUser;
      }
      set
      {
        SetPropertyValue("SKUser", ref _sKUser, value);
      }
    }
  }
}

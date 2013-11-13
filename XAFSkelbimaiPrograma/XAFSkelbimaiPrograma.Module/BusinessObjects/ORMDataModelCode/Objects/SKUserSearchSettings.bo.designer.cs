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
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.SecurityModule;
namespace XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects
{
  [DefaultClassOptions]
  public partial class SKUserSearchSettings : DevExpress.Persistent.BaseImpl.BaseObject
  {
    private System.Boolean _loadPhoto;
    private System.Boolean _blocked;
    private System.DateTime _lastParseDate;
    private System.Boolean _sendEmail;
    private XAFSkelbimaiPrograma.Module.SecurityModule.DLCEmployee _sKUser;
    private XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Classificators.SKPlugin _plugin;
    private System.String _url;
    private System.String _name;
    public SKUserSearchSettings(DevExpress.Xpo.Session session)
      : base(session)
    {
    }
    [RuleRequiredField(DefaultContexts.Save)]
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
    //[EditorAlias("HyperLinkPropertyEditor")]
    [RuleRequiredField(DefaultContexts.Save)]
    [DevExpress.Xpo.SizeAttribute(1000)]
    [RuleRegularExpression("SKUserSearchSettings.Url.RuleRegularExpression", DefaultContexts.Save, @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})")]
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
    [RuleRequiredField(DefaultContexts.Save)]
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
    protected override void OnSaving()
    {
      DLCEmployee currentUser = Session.FindObject<DLCEmployee>(CriteriaOperator.Parse("Oid = ?", SecuritySystem.CurrentUserId));
      SKUser = currentUser;
      base.OnSaving();
    }
    public System.Boolean SendEmail
    {
      get
      {
        return _sendEmail;
      }
      set
      {
        SetPropertyValue("SendEmail", ref _sendEmail, value);
      }
    }
    public System.DateTime LastParseDate
    {
      get
      {
        return _lastParseDate;
      }
      set
      {
        SetPropertyValue("LastParseDate", ref _lastParseDate, value);
      }
    }
    public System.Boolean Blocked
    {
      get
      {
        return _blocked;
      }
      set
      {
        SetPropertyValue("Blocked", ref _blocked, value);
      }
    }
    public System.Boolean LoadPhoto
    {
      get
      {
        return _loadPhoto;
      }
      set
      {
        SetPropertyValue("LoadPhoto", ref _loadPhoto, value);
      }
    }
  }
}

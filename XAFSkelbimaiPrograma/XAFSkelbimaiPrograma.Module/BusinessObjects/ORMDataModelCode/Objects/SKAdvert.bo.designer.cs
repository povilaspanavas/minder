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
  public partial class SKAdvert : DevExpress.Persistent.BaseImpl.BaseObject
  {
    private System.Boolean _deleted;
    private XAFSkelbimaiPrograma.Module.SecurityModule.DLCEmployee _sKUser;
    private System.Boolean _mark;
    private System.Boolean _read;
    private XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects.SKUserSearchSettings _searchSetting;
    private System.String _fuelType;
    private System.String _price;
    private System.String _link;
    private System.String _year;
    private System.DateTime _foundDate;
    private System.String _name;
    public SKAdvert(DevExpress.Xpo.Session session)
      : base(session)
    {
    }
    [DevExpress.Xpo.SizeAttribute(300)]
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
    //[Custom("DisplayFormat", "{0ddd, dd MMMM yyyy hh:mm:ss tt}")]
    public System.DateTime FoundDate
    {
      get
      {
        return _foundDate;
      }
      set
      {
        SetPropertyValue("FoundDate", ref _foundDate, value);
      }
    }
    [DevExpress.Xpo.SizeAttribute(300)]
    public System.String Year
    {
      get
      {
        return _year;
      }
      set
      {
        SetPropertyValue("Year", ref _year, value);
      }
    }
    [DevExpress.Xpo.SizeAttribute(500)]
    public System.String Link
    {
      get
      {
        return _link;
      }
      set
      {
        SetPropertyValue("Link", ref _link, value);
      }
    }
    [DevExpress.Xpo.SizeAttribute(300)]
    public System.String Price
    {
      get
      {
        return _price;
      }
      set
      {
        SetPropertyValue("Price", ref _price, value);
      }
    }
    [DevExpress.Xpo.SizeAttribute(300)]
    public System.String FuelType
    {
      get
      {
        return _fuelType;
      }
      set
      {
        SetPropertyValue("FuelType", ref _fuelType, value);
      }
    }
    public XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects.SKUserSearchSettings SearchSetting
    {
      get
      {
        return _searchSetting;
      }
      set
      {
        SetPropertyValue("SearchSetting", ref _searchSetting, value);
      }
    }
    public System.Boolean Read
    {
      get
      {
        return _read;
      }
      set
      {
        SetPropertyValue("Read", ref _read, value);
      }
    }
    public System.Boolean Mark
    {
      get
      {
        return _mark;
      }
      set
      {
        SetPropertyValue("Mark", ref _mark, value);
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
    public System.Boolean Deleted
    {
      get
      {
        return _deleted;
      }
      set
      {
        SetPropertyValue("Deleted", ref _deleted, value);
      }
    }
  }
}
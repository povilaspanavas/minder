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
  public partial class SKParserLog : DevExpress.Persistent.BaseImpl.BaseObject
  {
    private System.String _logType;
    private System.DateTime _logDate;
    private System.String _message;
    public SKParserLog(DevExpress.Xpo.Session session)
      : base(session)
    {
    }
    [DevExpress.Xpo.SizeAttribute(5000)]
    public System.String Message
    {
      get
      {
        return _message;
      }
      set
      {
        SetPropertyValue("Message", ref _message, value);
      }
    }
    public System.DateTime LogDate
    {
      get
      {
        return _logDate;
      }
      set
      {
        SetPropertyValue("LogDate", ref _logDate, value);
      }
    }
    public System.String LogType
    {
      get
      {
        return _logType;
      }
      set
      {
        SetPropertyValue("LogType", ref _logType, value);
      }
    }
  }
}

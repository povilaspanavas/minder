using Core.DB;
using Core.Tools.DBVersionSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertModel.DbVersions
{
    [DBHistory]
    public class DbVersion_1
    {
        [DBVersion(1, "Adds DBVersion's table", "2013.10.14 19:37:00")]
        public void Version()
        {
            GenericDbHelper.CreateTable(typeof(DBVersion));
        }
    }
}

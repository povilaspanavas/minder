using AdvertModel;
using Core.Objects;
using Core.Tools.DBVersionSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SystemUpdater.Runable
{
    public class DbVersionRunner
    {
        private string m_assemblyPath;

        public DbVersionRunner(string assemblyPath)
        {
            m_assemblyPath = assemblyPath;
        }

        //Main method
        public void Execute()
        {
            if (string.IsNullOrEmpty(m_assemblyPath))
                throw new Exception("Assembly path is null or empty!");
            if (File.Exists(m_assemblyPath) == false)
                throw new FileNotFoundException("Not found file", m_assemblyPath);
            Assembly ass = Assembly.LoadFile(m_assemblyPath);

            new DBVersionSystem(new DBVersionRepository().AddVersions(ass)).UpdateToNewest();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAFSkelbimaiPrograma.Parser.Helpers;
using XAFSkelbimaiPrograma.Parser.Plugins;

namespace XAFSkelbimaiPrograma.Parser.Tests
{
    [TestClassAttribute]
    public class TestPlugins
    {
        [TestMethod]
        public void TestAllPlugins()
        {

            Assembly parserAssembly = Assembly.Load("XAFSkelbimaiPrograma.Parser");

            var plugins = from t in parserAssembly.GetTypes()
                            where t.GetInterfaces().Contains(typeof(IPlugin))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IPlugin;

            foreach (IPlugin plugin in plugins)
            {
                foreach (string link in plugin.TestLinks)
                {
                    try
                    {
                        List<AdvertDto> adverts = plugin.Parse(link, new UserParseInfoDto { Photo = true });
                        Assert.AreNotEqual(0, adverts.Count);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(string.Format("Plugin: {0} Link: {1}, Message: {2}", 
                            plugin.UniqueCode, link, e));
                    }
                }
            }
        }

        //[TestMethod]
        //public void TestSimple()
        //{
        //    HashSet<string> hashSet = new HashSet<string>();
        //    bool result = hashSet.Add("Labas");
        //    bool result1 = hashSet.Add("Labas");
           
        //}

    }
}

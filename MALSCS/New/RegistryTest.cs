using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALSCS.New
{
    class RegistryTest
    {
        RegistryKey registryTest = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("RegistryTest");

        public void regtestSet()
        {
            // string text = System.IO.File.ReadAllText(@"C:\Users\USER\Documents\q.xml");
            string path = @"C:\Users\USER\Documents\q.xml";

            registryTest.SetValue("test", path);
            registryTest.Close();
        }

        public void regtestGet()
        {            
            registryTest.GetValue("test", "없다");
        }
    }
}

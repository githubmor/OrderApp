using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorys
{
    public static class ChangeConnectionExample
    {
        public static Context ChangeConnection(string newMDFFile)
        {
            // assumes a connectionString name in .config of MyDbEntities
            var selectedDb = new Context();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + newMDFFile;
            if (!File.Exists(path))
            {
                using (var stream = File.Create(path)) { }
            }
            // so only reference the changed properties
            // using the object parameters by name
            selectedDb.ChangeDatabase(initialCatalog: path, configConnectionStringName: "OrderDbConnectionString");

            return selectedDb;
        }
    }
}

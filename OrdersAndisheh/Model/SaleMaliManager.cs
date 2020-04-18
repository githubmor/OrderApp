using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdersAndisheh.Model
{
    public class SaleMaliManager : ISaleMaliManager
    {
        private int thisYear;

        public bool CheckOutSalMali()
        {
            thisYear = PersianDateTime.Now.Year;
            
            if (IsCreateThisYearDatabase()  )
            {
                if (!IsCurrentSalMaliThisYear())
                {
                    ChangeCurrentSalMaliToThisYear();
                    return true;
                }else
                    return false;
            }
            else
            {
                CreateThisYearDatabase();
                ChangeCurrentSalMaliToThisYear();
                return true;
            }
        }

        public List<int> GetSalMalis()
        {
            return null;
        }

        public void ChangeSalMaliTo(int seletedSalMali)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(
                new ConnectionStringSettings("OrderDbConnectionString", getConnectionString(seletedSalMali), "System.Data.SqlClient"));
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private string getConnectionString(int seletedSalMali)
        {
            var path = seletedSalMali + ".mdf";
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\" + path
                +";Integrated Security=True;Connect Timeout=30";
        }

        private void CreateThisYearDatabase()
        {
            throw new NotImplementedException();
        }

        private void ChangeCurrentSalMaliToThisYear()
        {
            ChangeSalMaliTo(thisYear);
        }

        private bool IsCreateThisYearDatabase()
        {
            throw new NotImplementedException();
        }

        private bool IsCurrentSalMaliThisYear()
        {
            throw new NotImplementedException();
        }
    }
}

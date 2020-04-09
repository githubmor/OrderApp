using System;
using System.Collections.Generic;

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

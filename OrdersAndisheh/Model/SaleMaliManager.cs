using System;
using System.Collections.Generic;

namespace OrdersAndisheh.Model
{
    public class SaleMaliManager : ISaleMaliManager
    {
        private int thisYear;

        public void CheckOutSalMali()
        {
            thisYear = PersianDateTime.Now.Year;
            
            if ( IsCreateThisYearSalMali() && !IsCurrentSalMaliThisYear() )
            {
                ChangeCurrentSalMaliToThisYear();
                OnChangeSalaMali.Invoke();
            }
            else
            {
                CreateThisYearSalMali();
                ChangeCurrentSalMaliToThisYear();
                OnChangeSalaMali.Invoke();
            }
        }

        public List<int> GetSalMalis()
        {
            return null;
        }

        public void ChangeSalMaliTo(int seletedSalMali)
        {
            OnChangeSalaMali.Invoke();
        }

        private void CreateThisYearSalMali()
        {
            throw new NotImplementedException();
        }

        private void ChangeCurrentSalMaliToThisYear()
        {
            ChangeSalMaliTo(thisYear);
        }

        private bool IsCreateThisYearSalMali()
        {
            throw new NotImplementedException();
        }

        private bool IsCurrentSalMaliThisYear()
        {
            throw new NotImplementedException();
        }

        public static Action OnChangeSalaMali;
    }
}

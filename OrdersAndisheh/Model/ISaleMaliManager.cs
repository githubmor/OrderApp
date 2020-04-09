using System;
using System.Collections.Generic;

namespace OrdersAndisheh.Model
{
    public interface ISaleMaliManager
    {
        void ChangeSalMaliTo(int seletedSalMali);
        //return true if salMali is this year
        bool CheckOutSalMali();
        List<int> GetSalMalis();
    }
}
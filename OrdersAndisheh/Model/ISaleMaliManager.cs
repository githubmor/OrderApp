using System.Collections.Generic;

namespace OrdersAndisheh.Model
{
    public interface ISaleMaliManager
    {
        void ChangeSalMaliTo(int seletedSalMali);
        void CheckOutSalMali();
        List<int> GetSalMalis();
        
    }
}
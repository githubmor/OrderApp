using System;

namespace OrderAndisheh.Domain.Entity
{
    public class SalMaliEntity
    {
        public SalMaliEntity(int sal)
        {
            if (!IsYearInRange(sal))
            {
                throw new ArgumentException("سال در سال مالی صحیح وارد نشده", "sal");
            }

            Sal = sal;
        }

        public int Sal { get; private set; }

        private bool IsYearInRange(int year)
        {
            return 1300 < year && year < 1500;
        }
    }
}
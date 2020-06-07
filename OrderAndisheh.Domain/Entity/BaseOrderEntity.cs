using System;

namespace OrderAndisheh.Domain.Entity
{
    public class BaseOrderEntity
    {
        public BaseOrderEntity(int tarikh, int version = 0, bool isAccepted = false)
        {
            if (!IsDateNumber(tarikh))
            {
                throw new IndexOutOfRangeException("فرمت تاریخ سفارش درست نمی باشد");
            }
            Tarikh = tarikh;
            IsAccepted = isAccepted;
            Version = version;
        }

        public int Tarikh { get; private set; }
        public bool IsAccepted { get; private set; }
        public int Version { get; private set; }

        public void VersionIncrease()
        {
            Version = Version + 1;
        }

        public void ChangeAccepted(bool check)
        {
            IsAccepted = check;
        }

        private bool IsDateNumber(int date)
        {
            var year = getYear(date);
            var month = getMonth(date);
            var day = getDay(date);

            return IsYearInRange(year) && IsMonthInRange(month) && IsDayInRange(day, month);
        }

        private bool IsDayInRange(int day, int month)
        {
            return 0 < day && (month < 7 ? day < 31 : day < 30);
        }

        private bool IsMonthInRange(int month)
        {
            return 0 < month && month < 13;
        }

        private bool IsYearInRange(int year)
        {
            return 1300 < year && year < 1500;
        }

        private int getDay(int date)
        {
            return date % 100;
        }

        private int getMonth(int date)
        {
            return (date / 100) % 100;
        }

        private int getYear(int date)
        {
            return date / 10000;
        }
    }
}
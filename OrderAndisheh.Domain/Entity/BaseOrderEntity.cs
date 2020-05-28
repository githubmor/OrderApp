using System;
namespace OrderAndisheh.Domain.Entity
{
    public class BaseOrderEntity
    {
        private int _id;
        public BaseOrderEntity(int Id,bool IsAccepted = false)
        {
            if (!Id.IsDateAndVersion())
            {
                throw new IndexOutOfRangeException("");
            }
            _Tarikh = getTarikh(Id);
            _IsAccepted = IsAccepted;
            _Version = getVersion(Id);
        }

        private int getVersion(int Id)
        {
            return Id % 100000000;
        }

        private int getTarikh(int Id)
        {
            return Id - getVersion(Id);
        }

        private int _Tarikh;

        public int Tarikh
        {
            get { return _Tarikh; }
        }

        private bool _IsAccepted;

        public bool IsAccepted
        {
            get { return _IsAccepted; }
        }

        private int _Version;

        public int Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }

        public void Accepted()
        {
            _IsAccepted = true;
        }

        private bool IsDateAndVersion(int id)
        {
            int year = id / 10 ^ 5;
            int month = id / 10 ^ 5;

            return i > 130001019 || i < 999912309;
        }
    }

    public static class IntExtension{
        public static bool IsDateAndVersion(this int i)  
        { 
            return i>130001019 || i<999912309; 
        }

    }
}
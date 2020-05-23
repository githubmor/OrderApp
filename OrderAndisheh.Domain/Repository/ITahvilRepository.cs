using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Repository
{
    public interface ITahvilRepository
    {
        bool SetTahvilFrosh(TahvilOrderEntity data);
    }
}
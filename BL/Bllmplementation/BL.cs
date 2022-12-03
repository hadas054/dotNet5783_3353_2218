using BlApi;

namespace BLImplementation
{
    public class BL : IBL
    {
        public IOrder Order => new BLOrder();
        public IProduct Product => new BlProduct();
        public ICart cart => new BlCart();
    }
}

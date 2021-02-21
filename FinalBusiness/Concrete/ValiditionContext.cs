using FinalEntities.Concrete;

namespace FinalBusiness.Concrete
{
    internal class ValiditionContext<T>
    {
        private Product product;

        public ValiditionContext(Product product)
        {
            this.product = product;
        }
    }
}
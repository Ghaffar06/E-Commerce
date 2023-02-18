using AppDbContext.IRepos;

namespace AppDbContext.UOW
{
    public interface IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; set; }
        public IProductRepo ProductRepo { get; set; }
        public IAttributeRepo AttributeRepo { get; set; }
        public IValueTypeRepo ValueTypeRepo { get; set; }
        public ICategoryAttributeRepo CategoryAttributeRepo { get; set; }
        public ICategoryProductRepo CategoryProductRepo { get; set; }
        public IProductAttributeRepo ProductAttributeRepo { get; set; }
        public IOrderRepo OrderRepo { get; set; }

        public void SaveChanges();

        public void RollBack();
    }
}

using AppDbContext.IRepos;
using AppDbContext.Models;
using AppDbContext.Repos;

namespace AppDbContext.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; set; }
        public IProductRepo ProductRepo { get; set; }
        public IAttributeRepo AttributeRepo { get; set; }
        public IValueTypeRepo ValueTypeRepo { get; set; }
        public ICategoryAttributeRepo CategoryAttributeRepo { get; set; }
        public ICategoryProductRepo CategoryProductRepo { get; set; }
        public IProductAttributeRepo ProductAttributeRepo { get; set; }
        public IOrderRepo OrderRepo { get; set; }


        protected readonly EcommerceDbContext _db;

        public UnitOfWork(EcommerceDbContext db)
        {
            _db = db;
            CategoryRepo = new CategoryRepo(db);
            ProductRepo = new ProductRepo(db);
            AttributeRepo = new AttributeRepo(db);
            ValueTypeRepo = new ValueTypeRepo(db);
            CategoryAttributeRepo = new CategoryAttributeRepo(db);
            CategoryProductRepo = new CategoryProductRepo(db);
            ProductAttributeRepo = new ProductAttributeRepo(db);
            OrderRepo = new OrderRepo(db);
        }

        public void RollBack()
        {
            _db.Dispose();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}

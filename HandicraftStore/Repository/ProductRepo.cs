using HandicraftStore.Data;
using HandicraftStore.Interface;
using HandicraftStore.Models;
using System;

namespace HandicraftStore.Repository
{
  
    public class ProductRepo : IProduct
    {
        private ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       public  void Delete( Product prod)
        {
            _context.Products.Remove(prod);
        }

        public  List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
      

        public Product GetById(int Id)
        {
            return _context.Products.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Product prod)
        {
      _context.Products.Add(prod);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

       public void Update(Product prod)
        {
          _context.Products.Update(prod);
        }
    }
}

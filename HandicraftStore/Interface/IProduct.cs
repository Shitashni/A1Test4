using HandicraftStore.Models;

namespace HandicraftStore.Interface
{
    public interface IProduct
    {
        List<Product> GetAll();
        Product GetById(int Id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();
    }
}

using HandicraftStore.Models;
namespace HandicraftStore.Interface
{
    public interface IOrders
    {
     
      
        List<Orders> GetAll();
        List<Orders> GetAllByStatus(string status);
        List<Orders> GetAllByStatus(string stat, string customerid);
        List<Orders> GetOrderByCustomerId(string status, string customerid);
        List<Orders> GetOrderProcessedByCustomer( string customerid);
        Orders GetById(int Id);
        void Insert(Orders txn);
        void Update(Orders txn);
        void Delete(Orders txn);

        void DeleteById(int id);
        void Save();
        
    }
}

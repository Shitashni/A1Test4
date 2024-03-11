using HandicraftStore.Data;
using HandicraftStore.Interface;
using HandicraftStore.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HandicraftStore.Repository
{
    public class OrdersRepo : IOrders
    {
        private ApplicationDbContext _context;

        //public List<Product> ProductList => throw new NotImplementedException();

        //List<Product> ITransaction.ProductList()
        //{

        //}

        public OrdersRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> ProductList()
        {
            return _context.Products.ToList();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void Delete(Orders txn)
        {
            _context.Orders.Remove(txn);
        }

        public List<Orders> GetAll()
        {
            return _context.Orders.Include(c=> c.Products).ToList();
        }
        public List<Orders> GetAllByStatus(string status, string customerid)
        {
            return _context.Orders.Include(c => c.Products).Where(c=> c.OrderStatus== status && c.Email == customerid).ToList();
        }
       
        public void DeleteById(int id)
        {
            Orders odr = _context.Orders.Where(x => x.Id == id).FirstOrDefault();
            _context.Orders.Remove(odr);
        }
        public Orders GetById(int Id)
        {
            return _context.Orders.Where(x => x.Id == Id).FirstOrDefault();
        }
        public List<Orders> GetOrderByCustomerId(string status, string customerid)
        {
            return _context.Orders.Where(c => c.OrderStatus==status && c.Email == customerid).ToList();
        }
        public List<Orders> GetOrderProcessedByCustomer( string customerid)
        {
            return _context.Orders.Where(c =>  c.Email == customerid).Include(c=>c.Products).ToList();
        }
        public List<Orders> GetAllByStatus(string status)
        {
            return _context.Orders.Where(c => c.OrderStatus == status).Include(c=> c.Products).ToList();
        }
        public void Insert(Orders txn)
        {
            _context.Orders.Add(txn);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Orders txn)
        {
            _context.Orders.Update(txn);
        }

      
    }
}

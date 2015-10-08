using System;
using System.Linq;
using HomeWork.Data.Data;
using HomeWork.Data.Model;
using HomeWork.UI.Model;
using HomeWork.UI.ModelConverter;

namespace HomeWork.UI.Service
{
  //  public delegate object GetEntityDelegate(IEntity entity);

   // public delegate TModel GetModelDel<TModel, TEntity>(TEntity del) where TModel: IModel<TE>;

    public delegate ContactModel ModelDelegate(Contact contact); 
   
    internal class OrderService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Contact> _contactRepsoitory;
        private readonly IRepository<Order> _orderRepository;
        public OrderService()
        {
            _userRepository = new EntityRepository<User>();
            _contactRepsoitory = new EntityRepository<Contact>();
            _orderRepository = new EntityRepository<Order>();
            _userRepository.Add(new User { Id = 1, Name = "User" });
            _contactRepsoitory.Add(new Phone { Id = 1, UserId = 1, OrderNumber = 1, Value = "123" });
            _contactRepsoitory.Add(new Phone { Id = 2, UserId = 1, OrderNumber = 0, Value = "321" });
            _orderRepository.Add(new Order { Id = 1, UserId = 1, OrderNumber = 5, Price = 10, Quantity = 1 });
            _orderRepository.Add(new Order { Id = 2, UserId = 1, OrderNumber = 4, Price = 4, Quantity = 7 });
        }

        public TEntity[] GetAllEntities<TEntity, TRepository>(TRepository repository, long userId)
            where TRepository : IRepository<TEntity>
            where TEntity : IEntity, IEntityByUser
        {
            return repository.GetAll().Where(o => o.UserId == userId).ToArray();
        }
        public UserModel GetUser(long id)
        {
            var user = _userRepository.GetById(id);

           // var contacts = _contactRepsoitory.GetAll().Where(o => o.UserId == id).ToArray();
            var contacts = 
                GetAllEntities<Contact, IRepository<Contact>>(_contactRepsoitory, id);

            var orders = _orderRepository.GetAll().Where(o => o.UserId == id).ToArray();
          
          
            var result = new UserModel 
            {
                Name = user.Name,
                Contacts = GetModels(contacts, ContactConverter.ConvertEntityToModel),
                Orders = GetOrders(orders)
                 
            };

            return result;
        }

    
        public TModel[] GetModels<TModel, TEntity>(TEntity[] entities, Func<TEntity, TModel> converter)
            where TEntity : IEntityOrderNumber
            where TModel : IModel<TEntity>
        {
            return entities.OrderBy(o => o.OrderNumber).Select(converter).ToArray();
        }

        //public TModel[] GetModels<TModel, TEntity>(TEntity[] entities, Func<TEntity,TModel> tFunc) 
        //{
        //    entities.Select(o => tFunc);
        //}

        //public TModel[] GetEntity<TModel, TEntity>(TEntity[] entities, Func<TModel> tFunc) where TModel: 
        //{
        //    return entities.OrderBy(o => o.OrderNumber).Select(o => tFunc).ToArray();
        //}

        private ContactModel[] GetContacts(Contact[] contacts)
        {
            return contacts.OrderBy(o => o.OrderNumber).Select(o => new ContactModel { Value = o.Value }).ToArray();
        }

        private OrderModel[] GetOrders(Order[] orders)
        {
            return orders.OrderBy(o => o.OrderNumber).Select(o => new OrderModel { Total = o.Quantity * o.Price }).ToArray();
        }
    }
}

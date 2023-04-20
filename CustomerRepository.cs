namespace LacTask1.Controllers;
public class CustomerRepository : ICustomerRepository
{
    private readonly MyContext _dbContext;

    public CustomerRepository(MyContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Customer customer)
    {
        customer.Id = Guid.NewGuid();
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
    }

    public Customer Get(Guid id)
    {
        return _dbContext.Customers.Find(id);
    }

    public Customer Update(Customer customer)
    {
        var customerInDB = _dbContext.Customers.Find(customer.Id);
        if (customerInDB != null)
        {
            customerInDB.Id = customerInDB.Id;
            customerInDB.Email = customer.Email;
            customerInDB.FirstName = customer.FirstName;
            customerInDB.LastName = customer.LastName;
        }
        _dbContext.SaveChanges();
        return customerInDB;

    }

    public void Delete(Guid id)
    {
        var customer = _dbContext.Customers.Find(id);
        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
    }

    public List<Customer> ListAll()
    {
        return _dbContext.Customers.ToList();
    }
}
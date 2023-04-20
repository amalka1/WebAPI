namespace LacTask1.Controllers;

public interface ICustomerRepository
{
    void Add(Customer customer);
    Customer Get(Guid id);
    Customer Update(Customer customer);
    void Delete(Guid id);
    List<Customer> ListAll();
}
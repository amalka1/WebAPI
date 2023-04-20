using Microsoft.AspNetCore.Mvc;
namespace LacTask1.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerRepository _customerRepository;

    public CustomerController(MyContext dbContext)
    {
        _customerRepository = new CustomerRepository(dbContext);
    }

    [HttpPost]
    public IActionResult AddCustomer(Customer customer)
    {
        _customerRepository.Add(customer);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCustomer(Guid id)
    {
        var customer = _customerRepository.Get(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPut("update")]
    public IActionResult UpdateCustomer([FromBody] Customer customer)
    {
        if (customer.Id == null)
        {
            return BadRequest();
        }
        _customerRepository.Update(customer);
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(Guid id)
    {
        _customerRepository.Delete(id);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        var customers = _customerRepository.ListAll();
        return Ok(customers);
    }
}

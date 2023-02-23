
using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;

using Microsoft.EntityFrameworkCore;

var ordCtrl = new OrdersController();
var newOrd = new Order() { Id = 0, CustomerId = 1, Date = DateTime.Now, Description = "TEST" };

var ord = await ordCtrl.InsertAsync(newOrd);
Console.WriteLine(ord);

//var startingNumber = 100;

//var sum = await SumNumber1to10();

//var total = sum + startingNumber;

//Console.WriteLine("Done ...");

//async Task<int> SumNumber1to10() {
//    await _context.Customers.ToListAsync();
//    int sum = 0;
//    sum += 1;
//    sum += 2;
//    sum += 3;
//    sum += 4;
//    sum += 5;
//    sum += 6;
//    sum += 7;
//    sum += 8;
//    sum += 9;
//    sum += 10;
//    return sum;
//}

//var custCtrl = new CustomersController();

//var success = await custCtrl.DeleteAsync(38);

//Console.WriteLine(success ? "Ok" : "Failed");



//var success = await custCtrl.UpdateAsync(bootcamp);
//var bootcamp = await custCtrl.GetByIdAsync(38);

//bootcamp.Sales = 5000;


//var cust = new Customer() {
//    Id = 0, Name = "Bootcamp", City = "Mason", State = "OH", Sales = 0, Active = true
//};

//var success = await custCtrl.InsertAsync(cust);






//var cust = await custCtrl.GetByIdAsync(1);
//Console.WriteLine(cust.Name);



//foreach(var cust in await custCtrl.GetAllAsync()) {
//    Console.WriteLine(cust.Name);
//}

//var dbc = new SalesDbContext();

////var customer = await GetById(1);

//var customers = await GetAll();

//foreach(var cust in customers) {
//    Console.WriteLine(cust.Name);
//}


//async Task<Customer> GetById(int id) {
//    return await dbc!.Customers.FindAsync(id) ?? new Customer();
//}

//async Task<List<Customer>> GetAll() {
//    return await dbc.Customers.ToListAsync();
//}

//var orderWithCustomers = from o in dbc.Orders
//                         join c in dbc.Customers
//                            on o.CustomerId equals c.Id
//                         orderby c.Name
//                         select new {
//                             Id = o.Id, Desc = o.Description, Customer = c.Name
//                         };

//foreach(var oc in orderWithCustomers) {
//    Console.WriteLine($"{oc.Id,2} | {oc.Desc,-30} | {oc.Customer,-30}");
//}

//var orders = from o in dbc.Orders
//             select o;

//foreach(var order in orders) {
//    Console.WriteLine(order.Description);
//}

//var customers = dbc.Customers
//                        .Where(x => x.City == "Cincinnati")
//                        .OrderByDescending(x => x.Sales)
//                        .ToList();

//foreach(var customer in customers) {
//    Console.WriteLine(customer.Name);
//}

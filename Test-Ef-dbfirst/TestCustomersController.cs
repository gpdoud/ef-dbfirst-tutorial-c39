using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;

namespace Test_Ef_dbfirst;

[Collection("Sequential")]
public class TestCustomersController {

    private readonly CustomersController custCtrl;
    private Customer NewCustomer = new Customer() {
        Id = 0, Name = "TEST CUSTOMER", 
        City = "Mason", State = "OH",
        Sales = 12345.67m, Active = false
    };

    public TestCustomersController() {
        custCtrl  = new CustomersController();
    }

    [Fact]
    public async void Test1GetAllAsync() {
        var customers = await custCtrl.GetAllAsync();
        Assert.Equal(36, customers.Count);
        var kroger = customers.First();
        Assert.Equal("Kroger", kroger.Name);
        Assert.Equal(1, kroger.Id);
        var spectrum = customers[34];
        Assert.Equal("Spectrum", spectrum.Name);
        Assert.Equal(35, spectrum.Id);
    }
    [Theory]
    [InlineData(1, 97230)]
    [InlineData(17, 91395)]
    [InlineData(35, 79482)]
    public async void Test2GetByIdAsync(int id, decimal sales) {
        var customer = await custCtrl.GetByIdAsync(id);
        Assert.NotNull(customer);
        Assert.Equal(sales, customer.Sales);
    }
    [Fact]
    public async void Test3InsertAsync() {
        await custCtrl.InsertAsync(NewCustomer);
        var customer = await custCtrl.GetByIdAsync(37);
        Assert.Equal("TEST CUSTOMER", customer.Name);
    }
    [Fact]
    public async void Test4UpdateAsync() {
        var keycorp = await custCtrl.GetByIdAsync(18);
        keycorp.Sales = 44444.44m;
        await custCtrl.UpdateAsync(keycorp);
        keycorp = await custCtrl.GetByIdAsync(18);
        Assert.Equal(44444.44m, keycorp.Sales);
    }
    [Fact]
    public async void Test5DeleteAsync() {
        await custCtrl.DeleteAsync(36);
        var shouldBeNull = await custCtrl.GetByIdAsync(36);
        Assert.Null(shouldBeNull);
    }
    

}
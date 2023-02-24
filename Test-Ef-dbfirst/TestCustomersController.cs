using ef_dbfirst_tutorial;

namespace Test_Ef_dbfirst;

public class TestCustomersController {

    private readonly CustomersController custCtrl;

    public TestCustomersController() {
        custCtrl  = new CustomersController();
    }

    [Theory]
    [InlineData(1, 97230)]
    [InlineData(17, 91395)]
    [InlineData(35, 79482)]
    public async void TestGetByIdAsync(int id, decimal sales) {
        var customer = await custCtrl.GetByIdAsync(id);
        Assert.NotNull(customer);
        Assert.Equal(sales, customer.Sales);
    }

    [Fact]
    public async void TestGetAllAsync() {
        var customers = await custCtrl.GetAllAsync();
        Assert.Equal(35, customers.Count);
        var kroger = customers.First();
        Assert.Equal("Kroger", kroger.Name);
        Assert.Equal(1, kroger.Id);
        var spectrum = customers.Last();
        Assert.Equal("Spectrum", spectrum.Name);
        Assert.Equal(35, spectrum.Id);
    }
}
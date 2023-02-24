using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ef_dbfirst;

[Collection("Sequential")]
public class TestOrdersController {

    private readonly OrdersController ordCtrl;
    private Order newOrder = new Order() {
        Id = 0, CustomerId = 1, Date = new DateTime(2023, 2, 24),
        Description = "Added Test Order"
    };

    public TestOrdersController() {
        ordCtrl = new OrdersController();
    }
    [Fact]
    public void Test6() { Assert.True(true); }
    [Fact]
    public async void Test1GetAllAsync() {
        var orders = await ordCtrl.GetAllAsync();
        Assert.Equal(27, orders.Count);
    }
    [Theory]
    [InlineData(1, 1)]
    public async void Test2GetByIdAsync(int id, int customerId) {
        var order = await ordCtrl.GetByIdAsync(id);
        Assert.NotNull(order);
        Assert.Equal(customerId, order.CustomerId);

    }
    [Fact]
    public async void Test3InsertAsync() {
        await ordCtrl.InsertAsync(newOrder);
        var order = await ordCtrl.GetByIdAsync(28);
        Assert.NotNull(order);
        Assert.Equal("Added Test Order", order.Description);
    }
    [Fact]
    public async void Test4UpdateOrderAsync() {
        var order = await ordCtrl.GetByIdAsync(27);
        Assert.NotNull(order);
        order.Description = "Changed Order";
        await ordCtrl.UpdateAsync(order);
        order = await ordCtrl.GetByIdAsync(27);
        Assert.NotNull(order);
        Assert.Equal("Changed Order", order.Description);
    }
    [Fact]
    public async void Test5DeleteAsync() {
        await ordCtrl.DeleteAsync(27);
        var shouldBeNull = await ordCtrl.GetByIdAsync(27);
        Assert.Null(shouldBeNull);
    }
}

using System.Collections.Generic;
using Core.OrderAggregate;
using Core.ProductAggregate;
namespace UnitTests.Core.TestFactories.OrderAggregates;

public static class TestOrderItemFactory
{
    // Properties
    public static int TestOrderQuantity = 50;
    public static ProductVariant TestProductVariant = new ProductVariant(20,30);

    public static List<OrderItem> TestOrderItems = new List<OrderItem>()
    {
        new OrderItem(TestOrderQuantity, TestProductVariant),
        new OrderItem(TestOrderQuantity, TestProductVariant),
        new OrderItem(TestOrderQuantity, TestProductVariant),
        new OrderItem(TestOrderQuantity, TestProductVariant),
    };


    // Creating Methods
    public static OrderItem Create()
    {
        return new OrderItem(TestOrderQuantity, TestProductVariant);
    }
    
    public static List<OrderItem> CreateList()
    {
        return TestOrderItems;
    }
}

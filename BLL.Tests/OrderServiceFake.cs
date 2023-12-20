using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace BLL.Tests;

public class OrderServiceFake
{
    internal IOrderService Get()
    {
        var mockContext = new Mock<IUnitOfWork>();

        var expectedOrder = new Order
        {
            Id = 1,
            ClientId = 1,
            Title = "Apples | 5kg",
            Origin = "ATB",
            Destination = "Alex Kovalov"
        };

        var mockDbSet = new Mock<IOrderRepository>();
        mockDbSet
            .Setup(repo =>
                repo.Find(
                    It.IsAny<Func<Order,bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
            .Returns(
                new List<Order> { expectedOrder }
            );
        
        mockContext
            .Setup(context =>
                context.Orders)
            .Returns(mockDbSet.Object);
        
        IOrderService orderService = new OrderService(mockContext.Object);
        return orderService;
    }

}
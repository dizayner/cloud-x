using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System.Net.Http.Json;
using Microsoft.eShopWeb.ApplicationCore.Constants;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;

public interface IOrderItemsReserverService
{
    Task ReserveOrderAsync(Order order);
}

public class OrderItemsReserverService : IOrderItemsReserverService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderItemsReserverService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    

    public async Task ReserveOrderAsync(Order order)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientNameConstants.ReserveOrder);
        await httpClient.PostAsJsonAsync(string.Empty, order);
    }
}

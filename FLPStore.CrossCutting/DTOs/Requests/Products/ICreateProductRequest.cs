namespace FLPStore.CrossCutting.DTOs.Requests.Products;

public interface ICreateProductRequest
{
    string? Description { get; set; }
    string? Title { get; set; }
    decimal Price { get; set; }
    int Quantity { get; set; }
}
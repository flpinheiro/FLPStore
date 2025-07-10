namespace FLPStore.CrossCutting.DTOs.Requests.Products
{
    public interface IUpdateProductRequest
    {
        Guid Id { get; set; }
        string? Description { get; set; }
        decimal Price { get; set; }
        string? Title { get; set; }
    }
}
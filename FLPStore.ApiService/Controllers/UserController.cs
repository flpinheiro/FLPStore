using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLPStore.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser()
    {
        return Ok("user Created");
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        return Ok($"user with id {id} found");
    }
    [HttpPost("Login")]
    public IActionResult LoginUser()
    {
        return Ok("user logged in");
    }
    [HttpPost("Logout")]
    public IActionResult LogoutUser()
    {
        return Ok("user logged out");
    }
    [HttpPatch("cart/add")]
    public IActionResult AddToCart()
    {
        return Ok("item added to cart");
    }
    [HttpPatch("cart/remove")]
    public IActionResult RemoveFromCart()
    {
        return Ok("item removed from cart");
    }
    [HttpGet("cart")]
    public IActionResult GetCart()
    {
        return Ok("cart retrieved");
    }
    [HttpPatch("cart/update")]
    public IActionResult UpdateOnCart()
    {
        return Ok("cart updated");
    }
    [HttpDelete("cart/clear")]
    public IActionResult ClearCart()
    {
        return Ok("cart cleared");
    }
    [HttpPost("cart/checkout")]
    public IActionResult CheckoutCart()
    {
        return Ok("cart checked out");
    }
    [HttpGet("orders")]
    public IActionResult GetOrders()
    {
        return Ok("orders retrieved");
    }
    [HttpGet("orders/{orderId:guid}")]
    public IActionResult GetOrder(Guid orderId)
    {
        return Ok($"order {orderId} retrieved");
    }
    [HttpPost("wishlist")]
    public IActionResult CreateWishList()
    {
        return Ok("wishlist created");
    }
    [HttpPut("wishlist")]
    public IActionResult UpdateWishList()
    {
        return Ok("wishlist updated");
    }
    [HttpGet("wishlist")]
    public IActionResult GetWishLists()
    {
        return Ok("wishlists retrieved");
    }
    [HttpGet("wishlist/{id:guid}")]
    public IActionResult GetWishList(Guid id)
    {
        return Ok($"wishlist with id {id} retrieved");
    }
    [HttpDelete("wishlist/{id:guid}")]
    public IActionResult RemoveWishList(Guid id)
    {
        return Ok($"wishlist with id {id} removed");
    }
    [HttpPatch("wishlist/{id:guid}/add/{productId:guid}")]
    public IActionResult AddToWishList(Guid id, Guid productId)
    {
        return Ok($"product {productId} added to wishlist {id}");
    }
    [HttpPatch("wishlist/{id:guid}/remove/{productId:guid}")]
    public IActionResult RemoveFromWishList(Guid id, Guid productId)
    {
        return Ok($"product {productId} removed from wishlist {id}");
    }

}

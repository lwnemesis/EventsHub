using CartApi.Models;

namespace CartApi.Data
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(string cartId);
        Task<Cart> UpdateCartAsync(Cart Basket);
        Task<bool> DeleteCartAsync(string cartId);
    }
}

using Backend.Models.Associations;

namespace Backend.Models.DTOs.Transactions
{
    public class GamePurchaseDto
    {
        public Guid GameId { get; set; }
        public string? GameName { get; set; }
        public double Price { get; set; }

        public GamePurchaseDto() { }

        public GamePurchaseDto(GamePurchase game)
        {
            GameId = game.GameId;
            GameName = game.Game.Name;
            Price = game.Price;
        }
    }
    
}

using Entities;

namespace DTO
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public virtual ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}

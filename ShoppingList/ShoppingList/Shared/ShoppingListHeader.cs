namespace ShoppingList.Domain
{
    public class ShoppingListHeader : IGenericEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal ShoppingTotalValue { get; set; }

        public ICollection<ShoppingListDetail> ShoppingListDetails { get; set; } = new HashSet<ShoppingListDetail>();
    }
}
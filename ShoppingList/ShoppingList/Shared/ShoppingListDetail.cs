namespace ShoppingList.Domain
{
    public class ShoppingListDetail : IGenericEntity<int>
    {
		public int Id { get; set; }
		public int ShoppingListHeaderId { get; set; }
		public string ItemName { get; set; }
		public decimal Quantity { get; set; }
		public decimal UnitValue { get; set; }
		public decimal TotalValue { get; set; }

		public ShoppingListHeader ShoppingListHeader { get; set; }
	}
}
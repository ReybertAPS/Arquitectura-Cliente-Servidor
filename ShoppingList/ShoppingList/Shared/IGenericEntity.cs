namespace ShoppingList.Domain
{
    public interface IGenericEntity<T>
    {
        public T Id { get; set; }
    }
}

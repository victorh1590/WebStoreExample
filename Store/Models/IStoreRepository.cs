namespace Store.Models
{
  public interface IStoreRepository // Mediates DB/App connection.
  {
    IQueryable<Product> Products { get; } // IQueryable is cheaper than IEnumerable for querying DBs.
  }
}
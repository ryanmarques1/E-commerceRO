namespace RO.DevTest.Domain.Entities;

public class Sale{
    public Guid IdSale {get;set;} = Guid.NewGuid();

    public int IdUser {get;set;}

    public User User {get;set;} = null!;

    public DateTime DateSale {get;set;}
    public List<ItemSale> Items {get;set;} = new(); 

}   

public class ItemSale {
    public int IdItemSale { get; set; }
    public int SaleId { get; set; }
    public Sale Sale { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int quantity { get; set; }
}
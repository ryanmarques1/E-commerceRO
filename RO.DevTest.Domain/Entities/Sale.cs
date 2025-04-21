namespace RO.DevTest.Domain.Entities;

public class Sale{
    public Guid IdSale {get;set;} = Guid.NewGuid();

    public string IdUser {get;set;} = null!;

    public DateTime DateSale {get;set;}
    public List<ItemSale> Items {get;set;} = new(); 
    public Sale() : base(){ }
}   

public class ItemSale {
    public Guid SaleId { get; set; }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int quantitySale { get; set; }
    public Sale Sale {get;set;} = null!;
    public ItemSale() : base() { }
}
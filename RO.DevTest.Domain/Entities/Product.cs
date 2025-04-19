namespace RO.DevTest.Domain.Entities;


public class Product{
    public Guid IdProd {get;set;} = Guid.NewGuid();

    public string nameProd {get;set;} = string.Empty;

    public string descriptionProd {get;set;} = string.Empty;

    public decimal priceProd {get;set;}

    public int quantityStock {get;set;}

   public Product() : base(){ }
}
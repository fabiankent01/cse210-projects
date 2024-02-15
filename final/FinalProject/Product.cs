using System;
using System;

public abstract class Product
{
    private string _name;
    private string _description;
    private decimal _price;
    private string _type;
    private int _quantity;

    private int _quantityBought;

    public Product(string name, string description, decimal price, string type, int quantity)
    {
        _name = name;
        _description = description;
        _price = price;
        _type = type;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public decimal GetPrice()
    {
        return _price;
    }

    public void SetPrice(decimal price)
    {
        _price = price;
    }

    public string GetProductType()
    {
        return _type;
    }

    public void SetProductType(string type)
    {
        _type = type;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }

    public int GetQuantityBought()
    {
        return _quantityBought;
    }

    public void SetQuantityBought(int bought)
    {
        _quantityBought = bought;
    }

    // public abstract string GetPaymentHistory();

    public abstract string ShowAvailableProducts();
    public abstract string GetProductInfo();
}
using System;

public class ClothingProduct : Product
{
    private string _size;
    private string _color;
    private string _material;

    public ClothingProduct(string name, decimal price, string description, string type, int quantity, string size, string color, string material) :
    base(name, description, price, type, quantity)
    {
        _size = size;
        _color = color;
        _material = material;
    }

    public string GetSize()
    {
        return _size;
    }

    public void SetSize(string size)
    {
        _size = size;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public string GetMaterial()
    {
        return _material;
    }

    public void SetMaterial(string material)
    {
        _material = material;
    }

    public override string ShowAvailableProducts()
    {
        return $"PRODUCT: {GetName()} || PRICE: ${GetPrice()} || QUANTITY: {GetQuantity()} " +
        $"|| DESCRIPTION: {GetDescription()} || \n SIZE: {GetSize()} || COLOR: {GetColor()} || MATERIAL: {GetMaterial()}\n";
    }

    public override string GetProductInfo()
    {
        SetProductType("Clothing");
        return $"PRODUCT TYPE: {GetProductType()} || PRODUCT: {GetName()} || PRICE: ${GetPrice()} " +
        $"|| SIZE: {GetSize()} || COLOR: {GetColor()} || MATERIAL: {GetMaterial()} || DESCRIPTION: {GetDescription()}\n     QUANTITY: {GetQuantityBought()}";
    }
}
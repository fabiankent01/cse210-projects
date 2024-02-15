using System;

public class FurnitureProduct : Product
{
    private string _material;

    public FurnitureProduct(string name, decimal price, string description, string type, int quantity, string material) :
    base(name, description, price, type, quantity)
    {
        _material = material;
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
        return $"PRODUCT: {GetName()} || PRICE: ${GetPrice()} || QUANTITY: {GetQuantity()} || DESCRIPTION: {GetDescription()} || MATERIAL: {GetMaterial()}\n ";
    }

    public override string GetProductInfo()
    {
        SetProductType("Furniture");
        return $"PRODUCT TYPE: {GetProductType()} || PRODUCT: {GetName()} || PRICE: ${GetPrice()} " +
        $"|| DESCRIPTION: {GetDescription()} || MATERIAL: {GetMaterial()}\n     QUANTITY: {GetQuantityBought()}";
    }

    //     public override string SaveToFIle()
    //     {
    //         SetProductType("Furniture");
    //         return $"PRODUCT TYPE: {GetProductType()} || PRODUCT: {GetName()} || PRICE: ${GetPrice()} " +
    //         $"|| DESCRIPTION: {GetDescription()} || MATERIAL: {GetMaterial()}\n     QUANTITY: {GetQuantityBought()}";
    //     }
}
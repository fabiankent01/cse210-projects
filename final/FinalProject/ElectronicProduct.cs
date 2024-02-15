using System;

public class ElectronicProduct : Product
{

    private int _warrantyPeriod;
    private string _brand;

    public ElectronicProduct(string name, string description, decimal price, string type, int quantity, int warranty, string brand) :
    base(name, description, price, type, quantity)
    {
        _warrantyPeriod = warranty;
        _brand = brand;
    }

    public int GetWarranty()
    {
        return _warrantyPeriod;
    }

    public void SetWarranty(int warranty)
    {
        _warrantyPeriod = warranty;
    }

    public string GetBrand()
    {
        return _brand;
    }

    public void SetBrand(string brand)
    {
        _brand = brand;
    }

    public override string ShowAvailableProducts()
    {
        return $"PRODUCT: {GetName()} || PRICE: ${GetPrice()} || QUANTITY: {GetQuantity()} " +
        $"|| DESCRIPTION: {GetDescription()} || WARRANTY (in Years): {GetWarranty()} || BRAND: {GetBrand()}\n ";
    }

    public override string GetProductInfo()
    {
        SetProductType("Electronic");
        return $"PRODUCT TYPE: {GetProductType()} || PRODUCT: {GetName()} || PRICE: ${GetPrice()} " +
        $"|| DESCRIPTION: {GetDescription()} || WARRANTY (in Years): {GetWarranty()} || BRAND: {GetBrand()}\n     QUANTITY: {GetQuantityBought()}";
    }
}
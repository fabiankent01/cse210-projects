using System;

public class ToyProduct : Product
{
    private string _ageRange;

    public ToyProduct(string name, decimal price, string description, string type, int quantity, string age) :
    base(name, description, price, type, quantity)
    {
        _ageRange = age;
    }

    public string GetAgeRange()
    {
        return _ageRange;
    }

    public void SetAgeRange(string age)
    {
        _ageRange = age;
    }

    public override string ShowAvailableProducts()
    {
        return $"PRODUCT: {GetName()} || PRICE: ${GetPrice()} || QUANTITY: {GetQuantity()} " +
        $"|| DESCRIPTION: {GetDescription()} || AGE RANGE: {GetAgeRange()}\n ";
    }

    public override string GetProductInfo()
    {
        SetProductType("Toy");
        return $"PRODUCT TYPE: {GetProductType()} || PRODUCT: {GetName()} || PRICE: ${GetPrice()} " +
        $"|| AGE RANGE: {GetAgeRange()} || DESCRIPTION: {GetDescription()}\n     QUANTITY: {GetQuantityBought()}";
    }
}
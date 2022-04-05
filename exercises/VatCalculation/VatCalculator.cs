public static class VatCalculator
{
    public static decimal Vat(Address address, Order order) =>  RateByCountry(address.Country) * order.NetPrice;

    static decimal Rate(Address address, Order order)
    {
        return address switch 
        {
            UsAddress(var state)=> UsRateByCountry(state),
            _ => RateByCountry(address, order),
        };
    }

    static decimal RateByCountry(Address address, Order order)
    {
        return address.Country switch 
        {
            "it" => 0.22m,
            "jp" => 0.08m,
            "de" => GermanyVat(order),
            _ => throw new ArgumentException($"No defined rate for {address.Country}")
        };
    }

    static decimal UsRateByCountry(string state)
    {
        return state switch
        {
            "ca" => 0.1m,
            "ma" => 0.0625m,
            "ny" => 0.085m,
            _ => throw new ArgumentException($"No defined rate for us state {state}")
        };
    }

    static decimal GermanyVat(Order order) => order.Product.IsFood ? 0.08m : 0.2m;
    
}
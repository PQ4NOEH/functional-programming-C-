public static class VatCalculator
{
    public static decimal Vat(Address address, Order order) =>  RateByCountry(address.Country) * order.NetPrice;

    public static decimal RateByCountry(string country)
    {
        return country switch 
        {
            "it" => 0.22m,
            "jp" => 0.08m,
            _ => throw new ArgumentException($"No defined rate for {country}")
        };
    }
}
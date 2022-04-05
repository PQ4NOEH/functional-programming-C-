public record Order(Product Product, int Quantity)
{
    public decimal NetPrice => Product.Price * Quantity;
}
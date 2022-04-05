public record Address(string Country);
public record UsAddress(string State) : Address("us");
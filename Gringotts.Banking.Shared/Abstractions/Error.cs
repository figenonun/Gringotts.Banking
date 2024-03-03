namespace Gringotts.Banking.Shared.Abstractions;

public sealed record Error(int CodeNumber, string Code, string Description)
{    
    public static Error None = new(0, string.Empty, string.Empty);

    public static Error NullValue = new(-1, "Error.NullValue", "Null value was provided");

    public static Error DefaultError => new(999, "Error.DefaultMessage","An exception occured.");

    public static Error CustomMessage(string errorMessage)
    {
        return new Error(996, "Error.CustomMessage", errorMessage);
    }
}
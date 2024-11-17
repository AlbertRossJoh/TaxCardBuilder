namespace TaxCardFormat.DataTypes;

public struct ShortId
{
    public string Id;

    public ShortId(string id)
    {
        if (id.Length > 16)
            throw new ArgumentException("A ShortId can be at most 16 characters");
        Id = id;
    }

    public ShortId()
        : this(Convert.ToBase64String(Guid.NewGuid().ToByteArray())[..^8]) { }

    public override string ToString()
    {
        return Id;
    }
}


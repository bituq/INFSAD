namespace Colors;

public abstract class AColor
{
    public abstract string HexCode { get; protected set; }
}

public class Blue : AColor
{
    public override string HexCode { get; protected set; } = "0000ff";
}

public class Green : AColor
{
    public override string HexCode { get; protected set; } = "00ff00";
}

public class Red : AColor
{
    public override string HexCode { get; protected set; } = "ff000";
}
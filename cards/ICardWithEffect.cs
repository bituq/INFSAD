public interface ICardWithEffect
{
    public Effect Effect { get; set; }
    public bool IsInstantaneous { get; set; }
    public bool IsContinuous { get; set; }
}

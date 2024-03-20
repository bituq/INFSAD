using Phases;

public class Effect
{
	protected Action<EffectParameters> action;

	public Effect(Action<EffectParameters> action)
	{
		this.action = action;
	}

	public void Activate(EffectParameters turn)
	{
		action(turn);
	}

}
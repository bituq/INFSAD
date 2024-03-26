using Phases;

public class Effect
{
	protected Action<EffectParameters> action;
	protected Action<EffectParameters>? counterAction;

	public Effect(Action<EffectParameters> action, Action<EffectParameters> counterAction)
	{
		this.action = action;
		this.counterAction = counterAction;
	}

	public Effect(Action<EffectParameters> action)
	{
		this.action = action;
		counterAction = action;
	}

	public Action? Activate(EffectParameters parameters)
	{
		action(parameters);

		return () => counterAction(parameters);
	}

}
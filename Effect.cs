using Phases;

public class Effect
{
	protected Action<Turn> action;

	public Effect(Action<Turn> action)
	{
		this.action = action;
	}

	public void Activate(Turn turn)
	{
		action(turn);
	}

}
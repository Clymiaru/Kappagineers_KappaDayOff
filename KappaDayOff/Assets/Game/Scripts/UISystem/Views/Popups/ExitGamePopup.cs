using UnityEngine;

public class ExitGamePopup : OneChoicePopup
{
	protected override void OnInitialize()
	{
	}

	public override void OnProceed()
	{
		// GameManager.Instance.SavePlayerData();
		Debug.Log("Exit Game Proceed");
		OnExitEnd = Application.Quit;
		Hide();
	}

	public override void OnCancel()
	{
		Debug.Log("Exit Game Cancelled");
		Hide();
	}
}

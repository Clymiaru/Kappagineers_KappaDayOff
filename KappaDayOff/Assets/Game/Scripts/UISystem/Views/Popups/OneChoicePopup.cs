using UnityEngine;

public class OneChoicePopup : View
{
    public virtual void OnProceed()
    {
    }

    public virtual void OnCancel()
    {

    }

    protected override void OnBackPressed()
    {
        OnCancel();
    }
}

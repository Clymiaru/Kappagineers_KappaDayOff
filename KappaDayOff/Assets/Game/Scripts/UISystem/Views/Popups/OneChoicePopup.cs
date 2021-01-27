using UnityEngine;
using UnityEngine.UI;

public class OneChoicePopup : View
{
    [Header("One Choice Popup Elements")]
    [SerializeField] protected Image popupBackground;
    [SerializeField] protected Button      closeButton;
    [SerializeField] protected Button      proceedButton;

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

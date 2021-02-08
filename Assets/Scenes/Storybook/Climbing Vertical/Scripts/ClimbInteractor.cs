using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractor : XRBaseInteractable
{
    protected override  void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        if(interactor is XRDirectInteractor)
        {
            ActiveHand.current = interactor.name;
        }
            
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        if(interactor is XRDirectInteractor)
        {
            if(ActiveHand.current == interactor.name)
            {
                ActiveHand.current = null;
            }
        }
    }
}

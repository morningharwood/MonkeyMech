using UnityEngine;
using Obi;


public class Whipper : MonoBehaviour
{


    public struct WhippedInformation
    {
        public GameObject Whipper;
        public ObiSolver Solver;
        public Oni.Contact Contact;
        public ObiColliderBase Collider;
    }


    public ObiSolver Solver;


    private ObiActor _actor;
    private ObiParticleAttachment _dynamicAttachment;
	private ObiSolver.ObiCollisionEventArgs _collisionEvent;
    private GameObject _pendingAttachable = null;


	void Awake(){
        _actor = this.GetComponent<Obi.ObiActor>();
	}


	void OnEnable () {
		Solver.OnCollision += Solver_OnCollision;

        ObiParticleAttachment[] attachments = _actor.GetComponents<Obi.ObiParticleAttachment>();
        foreach (ObiParticleAttachment attachment in attachments)
        {
            if (attachment.attachmentType == ObiParticleAttachment.AttachmentType.Dynamic)
            {
                _dynamicAttachment = attachment;
                break;
            }
        }
	}


	void OnDisable(){
		Solver.OnCollision -= Solver_OnCollision;
	}


	void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
	{
		var world = ObiColliderWorld.GetInstance();
		foreach (Oni.Contact contact in e.contacts)
		{
			// this one is an actual collision:
			if (contact.distance < 0.01)
			{
				ObiColliderBase collider = world.colliderHandles[contact.other].owner;
				if (collider != null)
				{
                    if (_dynamicAttachment.target == collider.gameObject.transform)
                    {   //we're already attached
                        return;
                    }

                    Whippable whippable = collider.gameObject.GetComponent<Whippable>();
                    if (whippable != null)
                    {
                        if (whippable.Attachable)
                        {
                            _pendingAttachable = collider.gameObject;
                        }
                        else
                        {
                            whippable.InvokeWhipped(new WhippedInformation(){
                                Whipper = this.gameObject,
                                Solver = Solver,
                                Contact = contact,
                                Collider = collider
                            });
                        }
                    }
				}
			}
		}
	}


    void LateUpdate()
    {
        if (_pendingAttachable != null)
        {
            PerformAttachment(_pendingAttachable);
            _pendingAttachable = null;
        }
    }


    private void PerformAttachment(GameObject gameObject)
    {
        try
        {
            PerformDetachment();

            // get position of attachment particle
            int particleIndex = _dynamicAttachment.particleGroup.particleIndices[0];
            Vector3 pos = _actor.GetParticlePosition(particleIndex);

            //move the attachable item to the same world position as the attaching particle
            gameObject.transform.position = pos;
            gameObject.GetComponent<ObiRigidbody>().UpdateIfNeeded(0f);
            Physics2D.SyncTransforms();

            //set the attachment
            _dynamicAttachment.target = gameObject.transform;

            Whippable whippable = gameObject.GetComponent<Whippable>();
            whippable.InvokeAttachedToWhip();
            
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.Log("Err:" + ex.Message);
        }
    }


    private void PerformDetachment()
    {
        if (_dynamicAttachment.target == null || _dynamicAttachment.target.gameObject == _pendingAttachable) 
        {
            return;
        }

        Whippable whippable = _dynamicAttachment.target.GetComponent<Whippable>();

        _dynamicAttachment.target = null;

        if (whippable != null)
        {
            whippable.InvokeDetachedFromWhip();
        }
    }


}

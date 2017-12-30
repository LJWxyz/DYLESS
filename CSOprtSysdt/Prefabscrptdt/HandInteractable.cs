using UnityEngine;

public class HandInteractable : MonoBehaviour {
    [SerializeField]private float interactableradius= 0.5f;
    private Vector3 InteractableVec3;
    public bool IsableInteract = false;
    private bool isInteracting = false;
    private bool isaChest = false;
    private Transform Interactor;
    private Vector3 SmallChestSize;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(InteractableVec3, interactableradius);
        
    }
    void Start () {
        InteractableVec3 = gameObject.transform.position;
	}
	
    public virtual void GameObjectFunc()
    {

    }

	void Update () {
        if (IsableInteract){
            float DistanceBetObjandPlyr = Vector3.Distance(Interactor.position, transform.position);
            if (DistanceBetObjandPlyr <= interactableradius)
            {
                if (isaChest) { InteractableVec3 = new Vector3(InteractableVec3.x, InteractableVec3.y, InteractableVec3.z + 0.2f);
                    OnDrawGizmosSelected();}
            }
            else
            {

            }
        }
	}

   public void InRangeInteract(Transform PlyrTransform) {
        IsableInteract = true;
        Interactor = PlyrTransform;
    }

    public void OutofRangetoInteract() {
        isInteracting = false;
        Interactor = null;
    }

}

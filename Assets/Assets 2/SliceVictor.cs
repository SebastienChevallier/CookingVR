using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceVictor : MonoBehaviour
{
    public GameObject objectToSlice; 
    public Material insideMat;
    

    




    public SlicedHull SliceObject(GameObject obj, Material insideMat = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, insideMat);
    }





    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ohohoho");
       if (collision.gameObject.tag == "Cutable")
        {
            objectToSlice = collision.gameObject;

            SlicedHull hull = SliceObject(objectToSlice, insideMat);

            if (hull != null)
            {
                hull.CreateLowerHull(objectToSlice, insideMat);
                hull.CreateUpperHull(objectToSlice, insideMat);

                objectToSlice.SetActive(false);
            }
        }
    }
    /**
 * Example on how to slice a GameObject in world coordinates.
 */
    public SlicedHull Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection)
    {
        return objectToSlice.Slice(planeWorldPosition, planeWorldDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


#if UNITY_EDITOR
 
    public void OnDrawGizmos()
    {
        EzySlice.Plane cuttingPlane = new EzySlice.Plane();

        // the plane will be set to the same coordinates as the object that this
        // script is attached to
        // NOTE -> Debug Gizmo drawing only works if we pass the transform
        cuttingPlane.Compute(transform);

        // draw gizmos for the plane
        // NOTE -> Debug Gizmo drawing is ONLY available in editor mode. Do NOT try
        // to run this in the final build or you'll get crashes (most likey)
        cuttingPlane.OnDebugDraw();
    }

#endif


}


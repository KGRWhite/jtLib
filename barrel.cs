using UnityEngine;
using System.Collections;

public class barrel  {

    GameObject cylinder;


    public barrel()
    {
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.AddComponent<Rigidbody>();
    }

    public barrel(Vector3 pos, Vector3 angle)
    {
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.AddComponent<Rigidbody>();
        

        
        cylinder.rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        cylinder.rigidbody.mass = 50f;

        setMaterial();
        
        cylinder.transform.localScale = new Vector3(0.60f, 0.91f, 0.60f);
        cylinder.transform.position = pos;
        cylinder.transform.Rotate(angle);

        
        
    }



    void setMaterial()
    {
        cylinder.renderer.material.mainTexture = Resources.Load<Texture2D>("Oxide");
        //cylinder.renderer.material.mainTextureScale = new Vector2(25, 2);
        //cylinder.renderer.material.SetTextureScale("_BumpMap", new Vector2(25, 2));
    }
    

}

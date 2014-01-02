using UnityEngine;
using System.Collections;

public class wall  {


    GameObject cube;

    public wall(Vector3 pos,Vector3 angle)
    {

        GameObject walls = new GameObject("walls");
        
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        setMaterial();
        
        cube.transform.localScale = new Vector3(10,3,1);
        cube.transform.position = pos;
        cube.transform.Rotate(angle);
        
    }


    void setMaterial() //Load material from Resources, set texture & bumpmap size.
    {
        cube.renderer.material = Resources.Load<Material>("Bricks");
        cube.renderer.material.mainTextureScale = new Vector2(25, 2);
        cube.renderer.material.SetTextureScale("_BumpMap",new Vector2(25,2));
        
    }


}

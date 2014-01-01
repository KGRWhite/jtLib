using UnityEngine;
using System.Collections;

public class wall  {


    GameObject cube;

    public wall(Vector3 pos,Vector3 angle)
    {
        
        
        
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        createTexture();
        
        cube.transform.localScale = new Vector3(10,3,1);
        cube.transform.position = pos;
        cube.transform.Rotate(angle);
        
    }


    void createTexture()
    {
        cube.renderer.material.mainTexture = Resources.Load<Texture2D>("Bricks");
    }


}

using UnityEngine;
using System.Collections;

public class init : MonoBehaviour {


    GameObject walls;
    
    void OnAwake()
    {
        
    }
    
    

	void Start () {
        createLighting();
        createScene();
        createPlayer();
        createEntities();
	}
		
    void createLighting()
    {
        GameObject light = new GameObject("main light");
        light.AddComponent<Light>();
        light.light.color = Color.white;
        light.light.intensity = 2;
        light.transform.position = new Vector3(0, 5, 0);
        
    }


    void createScene()
    {
                
        
        //create plane as surface
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, 0, 0);
        plane.renderer.material.mainTexture = Resources.Load<Texture2D>("MetalPattern");
        

        //create walls
        new wall(new Vector3(0, 1.5f, 5), new Vector3(0,0,0));
        new wall(new Vector3(5, 1.5f, 0), new Vector3(0,90,0));
        new wall(new Vector3(-5, 1.5f, 0), new Vector3(0, 90, 0));
            
        
    }

    
    
    void createEntities()
    {
        new barrel(new Vector3(1,3,1),new Vector3(0,0,20));
        new barrel(new Vector3(-1, 3, 2), new Vector3(0, 0, -20));
        new barrel(new Vector3(-3, 3, 2), new Vector3(0, 0, 20));
        new barrel(new Vector3(4, 3, 1), new Vector3(0, 0, -20));
    }

    void createPlayer()
    {
        //Player logic goes here
    }
}

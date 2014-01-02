using UnityEngine;
using System.Collections;

public class init : MonoBehaviour {


    GameObject cubeObj;
    GameObject sphereObj;
    bool barrelMode, cubeMode, sphereMode;
    
    
    
    void OnAwake()
    {
        
    }
    
    

	void Start () {
        barrelMode = true;
        cubeMode = false;
        sphereMode = false;
        
        createLighting();
        createScene();
        createPlayer();
        createEntities();

       cubeObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeObj.AddComponent<Rigidbody>();
        cubeObj.transform.position =new Vector3(-10, -10, -10);
        sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereObj.AddComponent<Rigidbody>();
        sphereObj.transform.position = new Vector3(-9, -9, -9);
	}



    void Update()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                new Vector3(hit.point.x, 2, hit.point.y);

                if (barrelMode == true)
                {
                    new barrel(new Vector3(hit.point.x, 2, hit.point.y), new Vector3(0, 0, 20));
                    SendMessage("incrementObjCount");
                }

                else if (cubeMode == true)
                {
                    
                    Instantiate(cubeObj, new Vector3(hit.point.x, 2, hit.point.z),Quaternion.Euler(new Vector3(0,0,20)));
                    SendMessage("incrementObjCount");
                }

                else if (sphereMode == true)
                {
                    Instantiate(sphereObj, new Vector3(hit.point.x, 2, hit.point.z), Quaternion.Euler(new Vector3(0, 0, 20)));
                    SendMessage("incrementObjCount");
                }
            }
        }
              
           
                        

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
        plane.renderer.material.mainTextureScale = new Vector2(15, 15);
        plane.renderer.material.SetTextureScale("_BumpMap", new Vector2(15,15));
        

        //create walls
        new wall(new Vector3(0, 1.5f, 5), new Vector3(0,0,0));
        new wall(new Vector3(5, 1.5f, 0), new Vector3(0,90,0));
        new wall(new Vector3(-5, 1.5f, 0), new Vector3(0, 90, 0));
            
        
    }

    
    
    void createEntities()
    {
        //new barrel(new Vector3(1,3,1),new Vector3(0,0,20));
       // new barrel(new Vector3(-1, 3, 2), new Vector3(0, 0, -20));
       // new barrel(new Vector3(-3, 3, 2), new Vector3(0, 0, 20));
       // new barrel(new Vector3(4, 3, 1), new Vector3(0, 0, -20));
    }

    void createPlayer()
    {
        //Player logic goes here
    }


    void switchToBarrels()
    {
        if (!barrelMode)
        {
            barrelMode = true;
            cubeMode = false;
            sphereMode = false;
        }
    }


    void switchToCubes()
    {
        if (!cubeMode)
        {
            barrelMode = false;
            cubeMode = true;
            sphereMode = false;
        }
    }

    void switchToSpheres()
    {
        if (!sphereMode)
        {
            barrelMode = false;
            cubeMode = false;
            sphereMode = true;
        }
    }
}

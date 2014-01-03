using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class init : MonoBehaviour {

    //Variables
    GameObject barrelObj, cubeObj, sphereObj;
    bool barrelMode, cubeMode, sphereMode;

    //Data Structures
    List<GameObject> goObjs = new List<GameObject>();
       

	void Start () {
        
        //On initialization set to default toolbar values.
        barrelMode = true;
        cubeMode = false;
        sphereMode = false;
        
        // Run Lighting and Scene Methods to build Scene.
        createLighting();
        createScene();

        // Generates a ready made barrel which will act as a parent for all Instantiated barrels.
        barrelObj = jtEntities.createBarrel();
        barrelObj.transform.position = new Vector3(-10, -10, -10);

        // Generates a ready made cube which will act as a parent for all Instantiated cube.
        cubeObj = jtEntities.createCube();
        cubeObj.transform.position = new Vector3(-10, -10, -10);

        // Generates a ready made sphere which will act as a parent for all Instantiated spheres.
        sphereObj = jtEntities.createSphere();
        sphereObj.transform.position = new Vector3(-10, -10, -10);
               
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
                    GameObject obj = (GameObject)Instantiate(barrelObj, new Vector3(hit.point.x, 2, hit.point.z), Quaternion.Euler(new Vector3(0, 0, 20)));
                    goObjs.Add(obj);
                    SendMessage("incrementObjCount");
                }

                else if (cubeMode == true)
                {

                    GameObject obj = (GameObject)Instantiate(cubeObj, new Vector3(hit.point.x, 2, hit.point.z), Quaternion.Euler(new Vector3(0, 0, 20)));
                    goObjs.Add(obj);
                    SendMessage("incrementObjCount");
                }

                else if (sphereMode == true)
                {
                   GameObject obj = (GameObject)Instantiate(sphereObj, new Vector3(hit.point.x, 2, hit.point.z), Quaternion.Euler(new Vector3(0, 0, 20)));
                   goObjs.Add(obj);
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

    

    void removeAllObjects()
    {
        foreach (GameObject g in goObjs)
        {
            Destroy(g);
        }
        
     SendMessage("resetObjCounter");
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

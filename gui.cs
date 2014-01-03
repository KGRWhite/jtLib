using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

    
    int localObjCounter = 0;
   
     private int toolbarInt = 0;
	 private string[] toolbarStrings = {"Barrel", "Cube", "Sphere"};

     
     void Update()
     {
         if (toolbarInt == 0)
             SendMessage("switchToBarrels");

         if (toolbarInt == 1)
             SendMessage("switchToCubes");

         if (toolbarInt == 2)
             SendMessage("switchToSpheres");
     }


     void incrementObjCount()
     {
         localObjCounter++;
     }

     void resetObjCounter()
     {
         localObjCounter = 0;
     }

	void OnGUI () 
    {
        string op = "Number of objects: " + localObjCounter;
        
        GUI.TextArea(new Rect(20, 10, 250, 30), "                 Stuff to play with");
        toolbarInt = GUI.Toolbar (new Rect (20, 40, 250, 30), toolbarInt, toolbarStrings);
        
        GUI.TextArea(new Rect(20, 80, 150, 50), op);

        if (GUI.Button(new Rect(20, 140, 80, 30), "Quit Demo"))
            Application.Quit();

        if (GUI.Button(new Rect(120, 140, 80, 30), "Clear Obj's"))
            SendMessage("removeAllObjects");
	}
}


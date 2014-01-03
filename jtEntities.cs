using UnityEngine;
using System.Collections;

public static class jtEntities  {

    public static GameObject createBarrel()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.AddComponent<Rigidbody>();

        cylinder.rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        cylinder.rigidbody.mass = 50f;

        cylinder.renderer.material.mainTexture = Resources.Load<Texture2D>("Oxide");

        return cylinder;

    }


    public static GameObject createCube()
    {
        GameObject cubeObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeObj.AddComponent<Rigidbody>();

        return cubeObj;

    }

    public static GameObject createSphere()
    {
        GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereObj.AddComponent<Rigidbody>();

        return sphereObj;
    }
}

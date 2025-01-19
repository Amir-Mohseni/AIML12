using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    static List<Rigidbody> objects = new List<Rigidbody>();
    private static float minimalSpeed = 0;
    private static int r = 15;

    public static void AddObject(Rigidbody t)
    {
        objects.Add(t);
    }

    public static List<Vector3> getObjects(Rigidbody curr)
    {
        List<Vector3> res = new List<Vector3>();
        foreach (Rigidbody t in objects)
        {
            if (IsObjectMakingSound(t, curr))
            {
                res.Add(t.transform.position);
            }
            else
            {
                res.Add(Vector3.zero);
            }
        }
        return res;
    }

    private static bool IsObjectMakingSound(Rigidbody t, Rigidbody curr)
    {
        Vector3 relativePosition = (curr.transform.position - t.transform.position);
        if (curr != t && relativePosition.magnitude < r && t.velocity.magnitude != minimalSpeed)
            return true;
        return false;
    }
}

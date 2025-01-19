using System.Collections.Generic;
using UnityEngine;

public static class Sound
{
    static List<Rigidbody> objects = new List<Rigidbody>();

    static void AddObject(Rigidbody t)
    {
        objects.Add(t);
    }

    static List<Rigidbody> getObjects(Rigidbody curr)
    {
        List<Rigidbody> res = new List<Rigidbody>();
        foreach (Rigidbody t in objects)
        {
            if (curr != t && t.velocity.magnitude > 0) res.Add(t);
        }
        return res;
    }
}

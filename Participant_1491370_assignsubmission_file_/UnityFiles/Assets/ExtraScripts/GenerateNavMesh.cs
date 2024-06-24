using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateNavMesh : MonoBehaviour {

    public static GenerateNavMesh genNavMesh;
    NavMeshSurface navMesh;

    void Start()
    {
        genNavMesh = this;
        navMesh = GetComponent<NavMeshSurface>();
    }

    public void GenMesh()
    {
        navMesh.BuildNavMesh();
        GenerateEnemies.genEnemies.GenEnemies();
    }
}

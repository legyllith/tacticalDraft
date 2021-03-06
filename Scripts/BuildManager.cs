﻿
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance; //il faut faire en sorte qu il y a toujorus q'un seul build manager

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déjà un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }
    #endregion


    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild; //de base vide

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}

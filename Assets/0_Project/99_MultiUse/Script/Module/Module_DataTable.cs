using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Module_DataTable 
{
    [SerializeField]
    string key;
    public string Key { get { return key; } set { this.key = value; } }

    [SerializeField]
    string devcomment;
    public string Devcomment { get { return devcomment; } set { this.devcomment = value; } }

    [SerializeField]
    string devcomment2;
    public string Devcomment2 { get { return devcomment2; } set { this.devcomment2 = value; } }

    [SerializeField]
    string devcomment3;
    public string Devcomment3 { get { return devcomment3; } set { this.devcomment3 = value; } }

    [SerializeField]
    int rarity;
    public int Rarity { get { return rarity; } set { this.rarity = value; } }

    [SerializeField]
    bool randomreward;
    public bool Randomreward { get { return randomreward; } set { this.randomreward = value; } }

    [SerializeField]
    int buyprice;
    public int Buyprice { get { return buyprice; } set { this.buyprice = value; } }

    [SerializeField]
    int[] artifactvalues = new int[0];
    public int[] Artifactvalues { get { return artifactvalues; } set { this.artifactvalues = value; } }

    [SerializeField]
    bool isonoff;
    public bool Isonoff { get { return isonoff; } set { this.isonoff = value; } }

    public Module_DataTable()
    {



    }


}

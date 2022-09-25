using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class XmlPlayerScript : MonoBehaviour
{

}

public class XmlClass
{
    Player player = new Player();

    public List<Player> SavingList { get; set; } = new List<Player>();

    public XmlClass() { }
}
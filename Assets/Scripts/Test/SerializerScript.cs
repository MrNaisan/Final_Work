using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;

public class SerializerScript : MonoBehaviour
{
    
}

public class Saving
{
    XmlClass xmlclass = new XmlClass();

    XmlSerializer xml = new XmlSerializer(typeof(XmlClass));

    public void Serialize(XmlClass xmlclass)
    {
        using (FileStream fs = new FileStream("player.xml", FileMode.OpenOrCreate))
        {
            xml.Serialize(fs, xmlclass);
        }
    }

    public void Derialize(XmlClass xmlclass)
    {
        using (FileStream fs = new FileStream("player.xml", FileMode.OpenOrCreate))
        {
            XmlClass? xmlclass2 = xml.Deserialize(fs) as XmlClass;
        }
    }

}
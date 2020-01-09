using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class si-toData
    {
        [SerializeField]
        int id;
        public int ID { get {return id; } set { id = value;} }
        
        [SerializeField]
        int weaponlabel;
        public int Weaponlabel { get {return weaponlabel; } set { weaponlabel = value;} }
        
        [SerializeField]
        string name;
        public string Name { get {return name; } set { name = value;} }
        
        [SerializeField]
        string modelresname;
        public string Modelresname { get {return modelresname; } set { modelresname = value;} }
        
    }
}
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

namespace MasterData
{
    [CustomEditor(typeof(si-to))]
    public class si-toEditor : BaseGoogleEditor<si-to>
    {	    
        public override bool Load()
        {        
            si-to targetData = target as si-to;
        
            var client = new DatabaseClient("", "");
            string error = string.Empty;
            var db = client.GetDatabase(targetData.SheetName, ref error);	
            var table = db.GetTable<si-toData>(targetData.WorksheetName) ?? db.CreateTable<si-toData>(targetData.WorksheetName);
        
            List<si-toData> myDataList = new List<si-toData>();
        
            var all = table.FindAll();
            foreach(var elem in all)
            {
                si-toData data = new si-toData();
            
                data = Cloner.DeepCopy<si-toData>(elem.Element);
                myDataList.Add(data);
            }
                
            targetData.dataArray = myDataList.ToArray();
        
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
        
            return true;
        }
    }
}
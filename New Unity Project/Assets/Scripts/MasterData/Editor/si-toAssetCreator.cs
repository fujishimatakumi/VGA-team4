using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

namespace MasterData
{
    public partial class GoogleDataAssetUtility
    {
        [MenuItem("Assets/Create/Google/si-to")]
        public static void Createsi-toAssetFile()
        {
            si-to asset = CustomAssetUtility.CreateAsset<si-to>();
            asset.SheetName = "game-unity";
            asset.WorksheetName = "si-to";
            EditorUtility.SetDirty(asset);        
        }
    
    }
}
 #if UNITY_EDITOR
 using UnityEditor;
 using System.IO;
 using UnityEngine;
using System.Collections.Generic;

namespace BrainlessPet.Tools
{
    public class EnumsGenerator : MonoBehaviour
    {
        [SerializeField] private string enumNameSpace = "BrainlessPet";
        [SerializeField] private string enumName = "PetCommandsEnum";
        [SerializeField] private string projectName = "BrainlessPet";
        [SerializeField] private string filePathAndName = "Assets/Scripts/Enums/";
        [SerializeField] private List<Object> listToEnum = new List<Object>();
        private string fullFilePathAndName;

        private void OnValidate() 
        {
            fullFilePathAndName = filePathAndName + enumName + ".cs";
        }
        public void Generate()
        {
            using ( StreamWriter streamWriter = new StreamWriter( fullFilePathAndName ) )
            {
                streamWriter.WriteLine( "namespace " + projectName + enumNameSpace);
                streamWriter.WriteLine( "{" );
                streamWriter.WriteLine( "\tpublic enum " + enumName );
                streamWriter.WriteLine( "\t{" );

                for( int i = 0; i < listToEnum.Count; i++ )
                {
                    streamWriter.WriteLine( "\t\t" + listToEnum[i].name + "," );
                    Debug.Log(listToEnum[i].name);
                }
                
                streamWriter.WriteLine( "\t}" );
                streamWriter.WriteLine( "}" );
            }
            AssetDatabase.Refresh();
        }
    }
}
#endif
 #if UNITY_EDITOR
 using UnityEditor;
 using System.IO;
 using UnityEngine.SceneManagement;
 using UnityEngine;
 
 namespace BrainlessPet.ScenesChangeSystem
 {
    public class GenerateEnum
    {
        [MenuItem( "Tools/ScenesChangeSystem/GenerateEnum" )]
        public static void Generate()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;     
            string[] scenes = new string[sceneCount];

            for( int i = 0; i < sceneCount; i++ )
            {
                scenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                Debug.Log(scenes[i]);
            }
    
            string enumName = "SceneNamesEnum";
            string projectName = "BrainlessPet";
            string filePathAndName = "Assets/Scripts/SceneChangeSystem/" + enumName + ".cs"; //The folder Scripts/Enums/ is expected to exist
    
            using ( StreamWriter streamWriter = new StreamWriter( filePathAndName ) )
            {
                streamWriter.WriteLine( "namespace " + projectName + ".ScenesChangeSystem");
                streamWriter.WriteLine( "{" );
                streamWriter.WriteLine( "\tpublic enum " + enumName );
                streamWriter.WriteLine( "\t{" );

                for( int i = 0; i < scenes.Length; i++ )
                {
                    streamWriter.WriteLine( "\t\t" + scenes[i] + "," );
                }
                
                streamWriter.WriteLine( "\t}" );
                streamWriter.WriteLine( "}" );
            }
            AssetDatabase.Refresh();
        }
    }
 }
 
 #endif

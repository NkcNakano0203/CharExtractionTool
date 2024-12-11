using UnityEditor;
using UnityEngine;

namespace CharExtractionTool
{
    [CreateAssetMenu(fileName = "UseStringList", menuName = "Scriptable Objects/UseStringList")]
    public class UseStringList : ScriptableSingleton<UseStringList>
    {
        public string FileName = "UseCharList";
        public string[] StringList;
    }
}
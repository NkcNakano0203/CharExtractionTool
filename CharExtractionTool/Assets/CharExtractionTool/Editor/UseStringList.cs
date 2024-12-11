using UnityEditor;

namespace CharExtractionTool
{
    [FilePath("CharExtractionTool/UseStringList.json", FilePathAttribute.Location.ProjectFolder)]
    public class UseStringList : ScriptableSingleton<UseStringList>
    {
        public string FileName = "UseCharList";
        public string[] StringList;
    }
}
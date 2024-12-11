using UnityEditor;
using UnityEngine;

namespace CharExtractionTool
{
    public static class SerializedPropertyExtension
    {
        public static string[] ToStringArray(this SerializedProperty serializedProperty)
        {
            if (!serializedProperty.isArray)
            {
                Debug.LogError("指定されたSerializedPropertyは配列ではありません。");
                return null;
            }

            string[] array = new string[serializedProperty.arraySize];
            for (int i = 0; i < serializedProperty.arraySize; i++)
            {
                SerializedProperty element = serializedProperty.GetArrayElementAtIndex(i);
                if (element.propertyType == SerializedPropertyType.String)
                {
                    array[i] = element.stringValue;
                }
                else
                {
                    Debug.LogWarning($"配列の要素{i}は文字列型ではありません。");
                }
            }

            return array;
        }
    }
}
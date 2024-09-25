using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CharExtractionTool
{
    public class CharExtractionTool : EditorWindow
    {
        public string[] stringList;

        private static UseStringList useStringList;
        private static SerializedProperty stringArrayProperty;

        [MenuItem("Tool/CharExtractionTool")]
        private static void Init()
        {
            //�����̃E�B���h�E�̃C���X�^���X��\���B�Ȃ��ꍇ�͍쐬���܂��B
            CharExtractionTool windowInstance = GetWindow<CharExtractionTool>();
        }

        private void OnEnable()
        {
            GetSerializedObjectInstance();
        }

        private void OnDestroy()
        {
            stringList = stringArrayProperty.ToStringArray();
            useStringList.StringList = stringList;
        }

        void OnGUI()
        {
            EditorGUILayout.PropertyField(stringArrayProperty);

            if (EditorGUI.EndChangeCheck())
            {
                stringList = stringArrayProperty.ToStringArray();
                useStringList.StringList = stringList;
            }

            if (GUILayout.Button("�e�L�X�g�t�@�C�����쐬"))
            {
                stringList = stringArrayProperty.ToStringArray();

                CreateCharacter();
            }
        }

        private static void GetSerializedObjectInstance()
        {
            useStringList = ScriptableSingleton<UseStringList>.instance;
            SerializedObject serializedObject = new SerializedObject(useStringList);
            stringArrayProperty = serializedObject.FindProperty(nameof(UseStringList.StringList));
        }

        private void CreateCharacter()
        {
            // SortedSet���g���A�g�p���镶���̏d�����Ȃ�
            SortedSet<char> sortedSet = new();
            foreach (var text in stringList)
            {
                foreach (char c in text)
                {
                    sortedSet.Add(c);
                }
            }

            // �������Ȃ���
            string fontCharacters = new string(sortedSet.ToArray());

            // �����̃t�@�C���p�X
            string currentPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this));
            // �����̃f�B���N�g��
            string currentDirectory = Path.GetDirectoryName(currentPath);
            // �e�f�B���N�g��
            DirectoryInfo parentPath = Directory.GetParent(currentDirectory);
            // �ۑ���̃f�B���N�g��
            string savePath = Path.Combine(parentPath.FullName, "TextFile");

            string path = Path.Combine(savePath, "UseCharecterList.txt");
            FileInfo fileInfo = new(path);
            // �e�L�X�g�t�@�C���֏����o��
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine(fontCharacters);
            }

            Debug.Log($".txt�t�@�C�����쐬���܂����F�p�X:{path}");
            AssetDatabase.Refresh();
        }
    }
}
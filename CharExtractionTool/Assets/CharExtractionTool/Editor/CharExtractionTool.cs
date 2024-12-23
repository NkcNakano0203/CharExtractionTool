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
        private static SerializedProperty fileNameProperty;

        [MenuItem("Tool/CharExtractionTool")]
        private static void Init()
        {
            //既存のウィンドウのインスタンスを表示。ない場合は作成します。
            CharExtractionTool windowInstance = GetWindow<CharExtractionTool>();
        }

        private void OnEnable()
        {
            GetSerializedObjectInstance();
        }

        // ウィンドウが閉じられたときにデータを保存する
        private void OnDestroy()
        {
            stringList = stringArrayProperty.ToStringArray();
            useStringList.StringList = stringList;
            useStringList.FileName = fileNameProperty.stringValue;
        }

        void OnGUI()
        {
            EditorGUILayout.PropertyField(fileNameProperty);
            EditorGUILayout.PropertyField(stringArrayProperty);

            if (EditorGUI.EndChangeCheck())
            {
                stringList = stringArrayProperty.ToStringArray();
                useStringList.StringList = stringList;
                useStringList.FileName = fileNameProperty.stringValue;
            }

            if (GUILayout.Button("テキストファイルを作成"))
            {
                stringList = stringArrayProperty.ToStringArray();

                CreateCharacter(fileNameProperty.stringValue);
            }
        }

        /// <summary>
        /// スクリプタブルオブジェクトからデータを取得
        /// </summary>
        private static void GetSerializedObjectInstance()
        {
            useStringList = ScriptableSingleton<UseStringList>.instance;
            SerializedObject serializedObject = new SerializedObject(useStringList);
            stringArrayProperty = serializedObject.FindProperty(nameof(UseStringList.StringList));
            fileNameProperty = serializedObject.FindProperty(nameof(UseStringList.FileName));
        }

        /// <summary>
        /// ファイル生成
        /// </summary>
        private void CreateCharacter(string fileName)
        {
            // SortedSetを使い、使用する文字の重複を省く
            SortedSet<char> sortedSet = new();
            foreach (var text in stringList)
            {
                foreach (char c in text)
                {
                    sortedSet.Add(c);
                }
            }

            // 文字をつなげる
            string fontCharacters = new string(sortedSet.ToArray());

            // 自分のファイルパス
            string currentPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this));
            // 自分のディレクトリ
            string currentDirectory = Path.GetDirectoryName(currentPath);
            // 親ディレクトリ
            DirectoryInfo parentPath = Directory.GetParent(currentDirectory);
            // 保存先のディレクトリ
            string savePath = Path.Combine(parentPath.FullName, "TextFile");

            string path = Path.Combine(savePath, fileName + ".txt");
            FileInfo fileInfo = new(path);
            // テキストファイルへ書き出し
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine(fontCharacters);
            }

            Debug.Log($".txtファイルを作成しました：パス:{path}");
            AssetDatabase.Refresh();
        }
    }
}
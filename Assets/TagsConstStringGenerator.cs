using System;
using System.IO;
using UnityEngine;
using UnityEditorInternal;
using UnityEditor;
using UnityEngine.Events;
using Directory = System.IO.Directory;

public class TagsConstStringGenerator : MonoBehaviour
{
    private static readonly string[] Tags = InternalEditorUtility.tags;
    private static readonly string AssetsPath = Directory.GetCurrentDirectory() + @"/Assets/";

    private static readonly char[] BannedSymbols =
    {
        ' ', '!', '@', '"', '#', '№', '$', ';', '%', '^',
        ':', '&', '?', '*', '(', ')', '-', '=', '+', '-',
        '/', '~'
    };

    private const string ClassName = "Tag";
    private static string Path => AssetsPath + ClassName + ".cs";

    [MenuItem("Tools/GenerateTagsClass")]
    private static void GenerateClass()
    {
        var classConstruction = $"public class {ClassName}" + "\n{ \n";
        var fields = "";
        
        var nameFields = Tags;
        for (var i = 0; i < Tags.Length; i++)
        {
            foreach (var symbol in BannedSymbols)
            {
                nameFields[i] = nameFields[i].Replace(symbol.ToString(), "");
            }
            fields += $"    public const string {nameFields[i]} = \"{Tags[i]}\"; {Environment.NewLine}";
        }

        var fullString = classConstruction + fields + "}";
        
        using(var file = new StreamWriter(Path, false))
        {
            if (File.Exists(Path))
            {
                file.Write(fullString);
            }
            else
            {
                file.Write(fullString);
                AssetDatabase.Refresh();
            }
        }

    }
}

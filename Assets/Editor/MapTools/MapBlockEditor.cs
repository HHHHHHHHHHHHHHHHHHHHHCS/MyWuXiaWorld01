using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapBlock))]
public class MapBlockEditor : Editor
{
    public enum OperateButton
    {
        Row,
        Column,
        All,
        AllClear,
    }

    private Sprite sprite = null;
    private int line = -1;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Sprite: ", GUILayout.Width(EditorGUIUtility.currentViewWidth / 3f));
        sprite = EditorGUILayout.ObjectField(sprite, typeof(Sprite), false) as Sprite;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Line: ", GUILayout.Width(EditorGUIUtility.currentViewWidth / 3f));
        var str = EditorGUILayout.TextField(line.ToString());
        int.TryParse(str, out line);
        EditorGUILayout.EndHorizontal();

        Rect rect;

        rect = EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Row", GUILayout.Width(EditorGUIUtility.currentViewWidth / 2.1f)))
            {
                TryChangeSprite(OperateButton.Row);
            }

            if (GUILayout.Button("Column", GUILayout.Width(EditorGUIUtility.currentViewWidth / 2.1f)))
            {
                TryChangeSprite(OperateButton.Column);
            }
        }
        EditorGUILayout.EndHorizontal();


        rect = EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("All", GUILayout.Width(EditorGUIUtility.currentViewWidth / 2.1f)))
            {
                TryChangeSprite(OperateButton.All);
            }

            if (GUILayout.Button("AllClear", GUILayout.Width(EditorGUIUtility.currentViewWidth / 2.1f)))
            {
                TryChangeSprite(OperateButton.AllClear);
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    public void TryChangeSprite(OperateButton btn)
    {
        var block = target as MapBlock;
        if (block.MapData == null)
        {
            Debug.LogError("MapData is null!");
            return;
        }

        if (btn == OperateButton.Row)
        {
            if (line < 0 || line >= block.MapData.RowCount)
            {
                Debug.LogError("input number less than zero or more/equals than row");
                return;
            }
        }
        else if (btn == OperateButton.Column)
        {
            if (line < 0 || line >= block.MapData.ColumnCount)
            {
                Debug.LogError("input number less than zero or more/equals than column");
                return;
            }
        }

        SpriteRenderer[] sprites = null;

        if (btn == OperateButton.Row)
        {
            var parent = block.transform.Find(MapPrefabEditor.mapParentName + line);
            if (parent)
            {
                sprites = parent.GetComponentsInChildren<SpriteRenderer>(true);
            }
        }
        else if (btn == OperateButton.Column)
        {
            var tempSprites = block.GetComponentsInChildren<SpriteRenderer>(true);
            string equalStr = "_" + line;
            sprites = tempSprites.Where(x =>
            {
                var name = x.transform.name;
                return name.LastIndexOf(equalStr, StringComparison.Ordinal) + equalStr.Length ==
                       name.Length;
            }).ToArray();
        }

        if (btn == OperateButton.All || btn == OperateButton.AllClear)
        {
            var tempSprites = block.GetComponentsInChildren<SpriteRenderer>(true);
            sprites = tempSprites
                .Where(x => x.transform.name.IndexOf(MapPrefabEditor.mapTileName, StringComparison.Ordinal) == 0)
                .ToArray();
        }

        Undo.RecordObjects(sprites, "ChangeSprites");

        Sprite replaceSpr = null;
        if (btn != OperateButton.AllClear)
        {
            replaceSpr = sprite;
        }

        if (sprites != null && sprites.Length > 0)
        {
            foreach (var spr in sprites)
            {
                spr.sprite = replaceSpr;
            }
        }
    }
}
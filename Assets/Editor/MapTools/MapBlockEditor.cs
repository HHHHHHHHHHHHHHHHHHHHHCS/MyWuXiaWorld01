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
        SetLine,
        ClearLine,
    }

    //不想在切换物体的时候被切换 所以标记成static
    private static int x0 = -1, y0 = -1, x1 = -1, y1 = -1;

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

        rect = EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("Start: ", GUILayout.Width(EditorGUIUtility.currentViewWidth / 3f));
            var x0str = EditorGUILayout.TextField(x0.ToString());
            int.TryParse(x0str, out x0);

            var y0str = EditorGUILayout.TextField(y0.ToString());
            int.TryParse(y0str, out y0);
        }
        EditorGUILayout.EndHorizontal();


        rect = EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("End: ", GUILayout.Width(EditorGUIUtility.currentViewWidth / 3f));
            var x1str = EditorGUILayout.TextField(x1.ToString());
            int.TryParse(x1str, out x1);

            var y1str = EditorGUILayout.TextField(y1.ToString());
            int.TryParse(y1str, out y1);
        }
        EditorGUILayout.EndHorizontal();


        rect = EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("SetLine", GUILayout.Width(EditorGUIUtility.currentViewWidth / 2.1f)))
            {
                TryChangeSprite(OperateButton.SetLine);
            }

            if (GUILayout.Button("ClearLine", GUILayout.Width(EditorGUIUtility.currentViewWidth / 2.1f)))
            {
                TryChangeSprite(OperateButton.ClearLine);
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
        else if (btn == OperateButton.SetLine || btn == OperateButton.SetLine)
        {
            if (x0 < 0 || y0 < 0 || x0 >= block.MapData.ColumnCount || y0 >= block.MapData.ColumnCount
                || x1 < 0 || y1 < 0 || x1 >= block.MapData.ColumnCount || y1 >= block.MapData.ColumnCount)
            {
                Debug.LogError("input number less than zero or more/equals than column");
                return;
            }

            if (!(x0 == x1 || y0 == y1))
            {
                Debug.LogError("input number must be a line");
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
        else if (btn == OperateButton.All || btn == OperateButton.AllClear)
        {
            var tempSprites = block.GetComponentsInChildren<SpriteRenderer>(true);
            sprites = tempSprites
                .Where(x => x.transform.name.IndexOf(MapPrefabEditor.mapTileName, StringComparison.Ordinal) == 0)
                .ToArray();
        }
        else if (btn == OperateButton.SetLine || btn == OperateButton.ClearLine)
        {
            var tempSprites = block.GetComponentsInChildren<SpriteRenderer>(true);
            List<SpriteRenderer> spriteList = new List<SpriteRenderer>();

            int maxX, minX;
            if (x0 >= x1)
            {
                maxX = x0;
                minX = x1;
            }
            else
            {
                maxX = x1;
                minX = x0;
            }

            int maxY, minY;
            if (y0 >= y1)
            {
                maxY = y0;
                minY = y1;
            }
            else
            {
                maxY = y1;
                minY = y0;
            }

            foreach (var item in tempSprites)
            {
                var names = item.name.Split('_');


                if (names.Length == 3)
                {
                    int y = int.Parse(names[1]);
                    int x = int.Parse(names[2]);

                    if (minX <= x && x <= maxX && minY <= y && y <= maxY)
                    {
                        spriteList.Add(item);
                    }
                }
            }

            sprites = spriteList.ToArray();
        }

        Undo.RecordObjects(sprites, "ChangeSprites");

        Sprite replaceSpr = null;
        if (btn != OperateButton.AllClear || btn!= OperateButton.ClearLine)
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToolsBelt : MonoBehaviour
{

    [SerializeField] List<ToolData> _tools;
    protected List<ToolData> Tools => _tools;
    private ToolData _activeTool;

    public ToolData ActiveTool => _activeTool;
    

    [SerializeField] private StringEventChannel _activeToolSelectedEvent;


    /// <summary>
    /// Adds tool to toolsbelt
    /// </summary>
    /// <param name="item"></param>
    public void AddToolToBelt(ToolData item)
    {
        _tools.Add(item);
        _activeTool = _tools[Tools.IndexOf(item)];
        _activeToolSelectedEvent.Invoke(_activeTool.Name);
    }

    /// <summary>
    /// Sets the next tool in the belt as the active tool
    /// </summary>
    public void NextTool()
    {
        // can't cycle if tools belt is empty
        if (Tools.Count == 0)
            return;
        
        int nextToolIndex = Tools.IndexOf(_activeTool) + 1;

        // check if next index is out of range, if so loop back to start
        if (nextToolIndex >= Tools.Count)
        {
            nextToolIndex = 0;
        }
        
        _activeTool = Tools[nextToolIndex];
        _activeToolSelectedEvent.Invoke(_activeTool.Name);
    }

    public bool ContainsToolType<T>() where T : ToolData
    {
        return _tools.OfType<T>().Any();
    }
}

public enum ToolType
{
    Empty,
    Axe,
    FishingRod,
    Torch
}
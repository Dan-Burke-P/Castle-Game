using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class GridLayout : LayoutGroup{

    public Button btn;

    public override void CalculateLayoutInputHorizontal(){
        base.CalculateLayoutInputHorizontal();
    }

    public override void CalculateLayoutInputVertical(){
        throw new System.NotImplementedException();
    }

    public override void SetLayoutHorizontal(){
        throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical(){
        throw new System.NotImplementedException();
    }
}

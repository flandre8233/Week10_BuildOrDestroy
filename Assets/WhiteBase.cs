using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBase : BelongBase<WhiteBase>
{
    protected override Belong BelongBy()
    {
        return Belong.White;
    }
}

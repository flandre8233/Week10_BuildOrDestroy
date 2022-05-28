using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBase : BelongBase<BlackBase>
{
    protected override Belong BelongBy()
    {
        return Belong.Black;
    }
}

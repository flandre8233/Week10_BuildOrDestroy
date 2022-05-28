using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectText : CommonUIText
{
    public override void UpdateText()
    {
        text.text = "Subject : " + SubjectName.instance.Subject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectName : SingletonMonoBehavior<SubjectName>
{
    [SerializeField] CommonUIText View;
    [SerializeField] string _Subject;
    public string Subject
    {
        get
        {
            return _Subject;
        }
        set
        {
            _Subject = value;
            View.UpdateText();
        }
    }

    private void Start()
    {
        GenName();
    }

    public void GenName()
    {
        print(RandomString.GenerateRandomName());
        Subject = RandomString.GenerateRandomName();
    }
}

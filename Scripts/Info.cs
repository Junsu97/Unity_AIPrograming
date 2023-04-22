using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

/*
 * �߻�Ŭ���� (abstract)
 * �߻�Ŭ������ ��ü�� ���� �� ����.
 */
abstract public class Info
{
    int data;
    public abstract void SomeMethod(JSONNode node);
}

public class DerivedClass1 : Info
{
    int data = 0;

    public override void SomeMethod(JSONNode node)
    {
        data = int.Parse(node.Value);
    }
}

public class DerivedClass2 : Info
{
    string data = string.Empty;

    public override void SomeMethod(JSONNode node)
    {
        data = node.Value;
    }
}

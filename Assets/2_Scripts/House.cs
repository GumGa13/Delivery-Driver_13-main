using JetBrains.Annotations;
using UnityEngine;

public class House
{
    public string tv = "�Ž� Ƽ��"; //��ΰ� �� �� �ִ�.
    private string diary = "��� ����ȿ��";
    protected string secretKey = "�� ��й���";

    public string GetDiary()
    {
        Driver driver = new Driver(); //driver.movespeed = 1;

        return diary;
    }
}

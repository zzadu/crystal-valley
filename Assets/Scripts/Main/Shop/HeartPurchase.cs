using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPurchase : MonoBehaviour
{
    int[] heart; // ģ�е�
    int canBuy; // ���� ������ ������
  

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false); // ������ ���۵Ǿ��� �� ������ �ʵ���
        
    }

    public bool heart_check() // ����ڰ� ������ �����̵��� ȣ������ ���� �� �̻����� üũ
    {
        int count = 0;
        int userHave = canBuy - 1; // ���� ����ڰ� ������ ������ = ���Ű����� ������ -1 ��ȣ

        while(count == userHave)
        {
            if (heart[count] < 90) // ģ�е� 90 �̸��̸� false ��ȯ
            {
                return false;
            }
        }
        return true;
    }

    public void heart_purchase(int item)
    {
        if (heart_check()) // heart_check ����� true��
            canBuy += 1; // ���� ������ ������ ���� ����
    }
  
}

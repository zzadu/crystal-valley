using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPurchase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false); // ������ ���۵Ǿ��� �� ������ �ʵ���
        
    }

    public bool HeartCheck() // ����ڰ� ������ �����̵��� ȣ������ ���� �� �̻����� üũ
    {
        DataController.Instance.LoadGameData();
        int count = 0;
        

        while(count == DataController.Instance.gameData.canBuy - 1) // ���� ����ڰ� ������ ������ = ���Ű����� ������ -1 ��ȣ
        {
            if (DataController.Instance.gameData.heart[count] < 70) // ģ�е� 70 �̸��̸� false ��ȯ
            {
                return false;
            }
            count++;
        }
        return true;
    }

    public void PurchaseByHeart(int item)
    {
        if (HeartCheck()) // HeartCheck ����� true��
            DataController.Instance.gameData.canBuy += 1; // ���� ������ ������ ���� ����
    }
  
}

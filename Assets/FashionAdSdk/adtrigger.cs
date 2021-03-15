using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class adtrigger : MonoBehaviour
{
    public RawImage adPanel;
    public Button goToBuyButton;
    string userId = "james";
    private bool isUserInTrigArea;
    private Queue<string> queue = new Queue<string>(); // 5�� ������ �� �޽��� ���� ť
    private int trigNum; // ���° Ʈ���� �ȿ� ���Դ���
    private bool isAdPanelSet = false; //�����ǿ� ���� ���õǾ��ִ��� �ƴ���
    
    private void Update()
    {
        if (queue.Count > 0 && !isUserInTrigArea)
        {
            adPanel.texture = null;
            goToBuyButton.gameObject.SetActive(false);
            queue.Dequeue();
            isAdPanelSet = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "sphere")
        {
            trigNum++;
            Debug.Log("Trigger!");
            
            if (!isAdPanelSet)
            {
                FashionAd fd = adPanel.GetComponent<FashionAd>();
                fd.ShowAd();
                goToBuyButton.gameObject.SetActive(true);
            }

            isUserInTrigArea = true;
            isAdPanelSet = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "sphere")
        {
            Debug.Log("Trigger!");

            //5�� �ڿ� ������� �ϴ� ������
            Thread td = new Thread(new ParameterizedThreadStart(Run));
            td.Start(trigNum);
            isUserInTrigArea = false;
        }
    }


    /*
     * 5�� �� ������ �����϶�� �޼����� ���� �޼ҵ�
     * �ٽ� Ʈ���� �ȿ� ������ ��� ������ ���ư��� �����带
     * ����ȭ ��Ű�� ���� �� �����尡 ���۵� ���� trignumber�� ���簡
     * �������� ����.
     * �̷��� ���� ������ ������ Ʈ���� ���� �����ٰ� �ٽ� 5�� �ȿ� �ٽ� ���� �Ŀ�
     * �ٷ� �ٽ� ������ ���� 5�� �ڿ� ���� ������� �ʰ� �ٷ� ������ų� 5�ʰ� �Ǳ� ���� �����.
     * ������ ���ư��� �����尡 ������ �����鼭 �޼����� ������ ���� 
     */
    private void Run(object trigNumber)
    {
        Thread.Sleep(5000);
        if ((int)trigNumber == trigNum)
        {
            string message = "resetAdPanel";
            queue.Enqueue(message);
        }
    }
}
    

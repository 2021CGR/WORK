using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ�

public class ObjectInteraction : MonoBehaviour
{
    public PlayableDirector timeline1;  // ù ��° ������Ʈ Ÿ�Ӷ���
    public PlayableDirector timeline2;  // �� ��° ������Ʈ Ÿ�Ӷ��� (�ڵ� �Ҵ��)
    public GameObject object1; // ù ��° ������Ʈ
    public GameObject object2; // �� ��° ������Ʈ
    public Transform player; // �÷��̾� ��ġ
    public float interactionDistance = 3f; // E Ű�� ���� �� �ִ� �Ÿ�
    public string nextSceneName; // ��ȯ�� �� �̸�

    void Start()
    {
        // timeline2�� �Ҵ���� �ʾҴٸ� �ڵ����� ã��
        if (timeline2 == null)
        {
            timeline2 = GameObject.Find("Timeline_Object2")?.GetComponent<PlayableDirector>();

            if (timeline2 == null)
            {
                Debug.LogError("timeline2�� �Ҵ���� �ʾҰ�, �ڵ����� ã�� ���� ����! Inspector���� ���� �����ϼ���.");
                return;
            }
        }

        // Ÿ�Ӷ����� ������ �� ��ȯ �̺�Ʈ ����
        timeline2.stopped += OnTimeline2End;
        Debug.Log("Ÿ�Ӷ��� �̺�Ʈ ���� �Ϸ�");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceToObj1 = Vector3.Distance(player.position, object1.transform.position);
            float distanceToObj2 = Vector3.Distance(player.position, object2.transform.position);

            if (object1.activeSelf && distanceToObj1 <= interactionDistance)
            {
                Debug.Log("ù ��° ������Ʈ Ÿ�Ӷ��� ����");
                timeline1.Play();
                Invoke(nameof(DisableObject1), (float)timeline1.duration);
            }
            else if (object2.activeSelf && distanceToObj2 <= interactionDistance)
            {
                Debug.Log("�� ��° ������Ʈ Ÿ�Ӷ��� ����");
                timeline2.Play(); // Ÿ�Ӷ��� ����
                Invoke(nameof(DisableObject2), (float)timeline2.duration);
            }
            else
            {
                Debug.Log("�Ÿ��� �ʹ� �־ EŰ �Է� ���õ�.");
            }
        }
    }

    void DisableObject1()
    {
        object1.SetActive(false);
        Debug.Log("ù ��° ������Ʈ ��Ȱ��ȭ��");
    }

    void DisableObject2()
    {
        object2.SetActive(false);
        Debug.Log("�� ��° ������Ʈ ��Ȱ��ȭ��");
    }

    void OnTimeline2End(PlayableDirector director)
    {
        if (director == timeline2)
        {
            Debug.Log("Ÿ�Ӷ��� ����, �� ��ȯ ����!");
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("�ٸ� Ÿ�Ӷ����� �����");
        }
    }
}

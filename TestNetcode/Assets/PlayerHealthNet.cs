using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class PlayerHealthNet : NetworkBehaviour
{
    int maxHealth = 100;
    // Owner: Ŭ���̾�Ʈ ���� -> ���� ������Ʈ�� ������ Ŭ���̾�Ʈ
    // �б� ����: Everyone, Owner
    // ���� ����: Server, Owner
    public NetworkVariable<int> health = new NetworkVariable<int>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public NetworkVariable<FixedString128Bytes> userId = new NetworkVariable<FixedString128Bytes>("player", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    TMP_Text textHealth;
    Slider sliderHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textHealth = GameObject.Find("TextHealth").GetComponent<TMP_Text>();
        textHealth.text = $"health = {maxHealth}";
        sliderHealth = GameObject.Find("SliderHealth").GetComponent<Slider>();
        sliderHealth.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            health.Value = maxHealth;
            // NetworkVariable�� �������� �̺�Ʈ �ڵ鷯 �߰�
            health.OnValueChanged += OnHealthChanged;
            userId.Value = GameManager.Instance.UserId;
            Debug.Log($"health = {health.Value}");
        }
        base.OnNetworkSpawn();
    }

    public override void OnNetworkDespawn()
    {
        if (IsOwner)
        {
            health.OnValueChanged -= OnHealthChanged; // �̺�Ʈ �ڵ鷯 ����
        }
        base.OnNetworkDespawn();
    }

    void OnHealthChanged(int prevValue, int newValue) // �޼ҵ���� �� �������������, �Է� ������ ����
    {
        // newValue: health.Value�� ����
        textHealth.text = $"health = {newValue}";
        sliderHealth.value = newValue;
    }

    public void decHealth()
    {
        int curPoint = health.Value - 1;
        if (curPoint < 0) curPoint = 0;
        health.Value = curPoint;
        Debug.Log($"health = {health.Value}");
    }

    [Rpc(SendTo.Owner)]
    public void decHealthRpc()
    {
        decHealth();
    }

    private void OnGUI()
    {
        Vector3 offset = new Vector3(-1.5f, 3.0f, 0.0f);
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position + offset); // �� ��ġ�� ����Ƽ ��ũ���� ��ġ
        Rect rect = new Rect(0, 0, 100, 50); // ��ǻ���� 2���� ��ǥ��
        rect.x = pos.x;
        rect.y = Screen.height - pos.y;
        GUIStyle style = new GUIStyle();
        style.richText = true; // HTML �±׸� ����
        GUI.Label(rect, $"<color=yellow>{userId.Value}: {health.Value}</color>", style); // Ư�� ��ġ�� ���ڿ� ���
    }
}

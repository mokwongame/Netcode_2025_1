using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class PlayerHealthNet : NetworkBehaviour
{
    int maxHealth = 100;
    // Owner: 클라이언트 종류 -> 게임 오브젝트를 생성한 클라이언트
    // 읽기 권한: Everyone, Owner
    // 쓰기 권한: Server, Owner
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
            // NetworkVariable의 변수마다 이벤트 핸들러 추가
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
            health.OnValueChanged -= OnHealthChanged; // 이벤트 핸들러 제거
        }
        base.OnNetworkDespawn();
    }

    void OnHealthChanged(int prevValue, int newValue) // 메소드명은 내 마음대로이지만, 입력 변수는 고정
    {
        // newValue: health.Value와 같음
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
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position + offset); // 이 위치는 유니티 스크린의 위치
        Rect rect = new Rect(0, 0, 100, 50); // 컴퓨터의 2차원 좌표계
        rect.x = pos.x;
        rect.y = Screen.height - pos.y;
        GUIStyle style = new GUIStyle();
        style.richText = true; // HTML 태그를 지원
        GUI.Label(rect, $"<color=yellow>{userId.Value}: {health.Value}</color>", style); // 특정 위치에 문자열 출력
    }
}

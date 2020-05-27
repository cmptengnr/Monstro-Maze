using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject characterPanelGameObject;
    [SerializeField] GameObject equipmentPanelGameObject;
    [SerializeField] KeyCode[] toggleCharacterPanelKeys;

    private void Update()
    {
        for (int i = 0; i < toggleCharacterPanelKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleCharacterPanelKeys[i]))
             {
                characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);

                if(characterPanelGameObject.activeSelf)
                {
                    equipmentPanelGameObject.SetActive(true);
                    ShowMouseCursor();
                }
                else
                {
                    HideMouseCursor();
                }
                break;
              }   
        }
             
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void ToggleEquipmentPanel()
    {
        equipmentPanelGameObject.SetActive(!equipmentPanelGameObject.activeSelf);
    }
}

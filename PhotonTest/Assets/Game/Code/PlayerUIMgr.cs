using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUIMgr : MonoBehaviour
{

    public static PlayerUIMgr instance;
    public GameObject hunter_button_prefab;
    public GameObject desertion_button_prefab;
    public GameObject text_prefab;
    private GameObject text_field;
    private GameObject button_field;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        text_field = new GameObject("TextField");
        text_field.transform.parent = this.transform;

        button_field = new GameObject("ButtonField");
        button_field.transform.parent = this.transform;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Button AddHunterIcon()
    {
        
        GameObject return_obj = AddGameObject(hunter_button_prefab);
        return_obj.transform.SetParent(this.transform);
        return return_obj.GetComponent<Button>();
    }
    public Button AddDesrtionIcon()
    {
        GameObject return_obj = AddGameObject(desertion_button_prefab);
        return_obj.transform.SetParent(this.transform);
        return return_obj.GetComponent<Button>();
    }

    public Text AddText()
    {
        GameObject return_obj = AddGameObject(text_prefab);
        return_obj.transform.SetParent(text_field.transform);
        return return_obj.GetComponent<Text>();
    }
    private GameObject AddGameObject(GameObject create_obj)
    {
        GameObject new_obj = (GameObject)Instantiate(create_obj);
        new_obj.transform.SetParent(this.transform, false);
        return new_obj;
    }

}

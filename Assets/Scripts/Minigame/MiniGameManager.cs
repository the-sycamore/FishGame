using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameManager : MonoBehaviour
{
    public float outerCircleDeviance;
    public float innerCircleDiameter;
    public float outerCircleDiameter;

    public GameObject outerCircle;
    public GameObject innerCircle;

    bool isGameStart = false;

    GameObject outerCircleObject;
    GameObject innerCircleObject;

    InputAction interactAction;

    public Vector3 circleShrinkSpeed = new Vector3(1,1,0);

    Dictionary<float, string> sexyDict = new Dictionary<float, string>
    {
        {0.1f, "perfect"},
        {0.4f, "good"},
        {0.6f, "close!"},
        {1000.0f, "try again next time!"}
    };

    void StartGame()
    {
        
        outerCircleObject = Instantiate(outerCircle, Vector3.zero, Quaternion.identity);
        innerCircleObject = Instantiate(innerCircle, Vector3.zero, Quaternion.identity);
        outerCircleObject.transform.localScale *= outerCircleDiameter * Random.Range(1,outerCircleDeviance); 
        innerCircleObject.transform.localScale *= innerCircleDiameter;
        isGameStart = true;


    }
    void EndGame(bool loop)
    {

        isGameStart = false;

        Destroy(outerCircleObject);
        Destroy(innerCircleObject);

        if (loop) StartGame();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        bool ifInteract = interactAction.WasPressedThisFrame();

        if (isGameStart)
        {
            outerCircleObject.transform.localScale -= circleShrinkSpeed * Time.deltaTime;
            if (outerCircleObject.transform.localScale.x < 0.05f)
            {
                print("try again next time!");
                EndGame(true);
            } else if (ifInteract){
                float distance = Mathf.Abs(outerCircleObject.transform.localScale.x - innerCircleObject.transform.localScale.x);
                foreach(float key in sexyDict.Keys)
                {
                    if (distance < key){
                        print(sexyDict[key]);
                        EndGame(true);
                        break; 
                    }
                }
            }
        }
    }
}

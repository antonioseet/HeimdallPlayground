using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WorkInstructionManager;

public class InstructionManager : MonoBehaviour
{
    public TextMeshPro textMesh;

    private WorkInstruction wi;
    public int index;


    // Start is called before the first frame update
    void Start()
    {
        // Gets a pre-made JSON on how to bake brownies (around 15 instructions)
        string json = WorkInstruction.sampleWorkInstruction1();
        string json2 = WorkInstruction.sampleWorkInstruction2();

        //Debug.Log("Testing Json 2: ");
        //Debug.Log(json2);

        // Create a work Instruction from the JSON we get.
        // (this premade json immitates the exact structure of what we get from the server)
        wi = new WorkInstruction(json2);

        //areEqual(json2, json2);

        // Get the first string`
        textMesh.text = wi.start();
    }

    // This method checks character by character and looks for differences
    //
    // Place the json string from the web api into the first parameter
    // Place the sampleWorkInstruction2() json into the second parameter
    public bool areEqual(string apiJson, string sampleJson)
    {

        Debug.Log(apiJson);
        Debug.Log(sampleJson);

        char[] apiList = apiJson.ToCharArray();
        char[] sampleList = sampleJson.ToCharArray();

        if (apiList.Length != sampleList.Length)
        {
            Debug.Log("The json strings are of different size");
            Debug.Log("Sample JSON size:" + sampleJson.Length);
            Debug.Log("Web API JSON size:" + apiJson.Length);
            return false;
        }

        bool mismatchFound = false;

        for (int i = 0; i < sampleList.Length; i++)
        {
            if (sampleList[i] == apiList[i])
            {
                //Debug.Log("Match at i = " + i);
            }
            else
            {
                //Debug.Log("No match at i = " + i);
                //Debug.Log("Sample char = " + sampleList[i]);
                //Debug.Log("api char = " + apiList[i]);
                mismatchFound = true;
            }
        }

        return !mismatchFound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            textMesh.text = wi.getNextInstruction();
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            textMesh.text = wi.getPrevInstruction();
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            textMesh.text = wi.reset();
        }

    }

    // TODO: delete, Deprecated
    private WorkInstruction GetWorkInstruction(int i)
    {

        WorkInstruction instruction = null;
        string title;
        string desc;
        List<string> s = new List<string>();

        switch (i)
        {
            case 0:
                title = "Circuit Divider";
                desc = "Build a circuit divider to power an LED";

                s.Add("Materials:\n9 volt battery (1)\n10k Ohm resistor (2)\nJumper Wire (1)\nBreadboard\nLED (1)");
                s.Add("Attach positive (red) lead of power supply to the red (+) power rail of the breadboard");
                s.Add("Attach negative (black) lead of power supply to the black (-) power rail of the breadboard");
                s.Add("Attach one end of a 10k ohm resistor to the positive power rail of the bread board and attach the other end to row '8' column 'h' of the breadboard");
                s.Add("Attach one end of a jumper wire to column f row 8 of the breadboard and attach the other end to 	row '10' column 'f' of the bread board");
                s.Add("Attach anode end of a LED to column f row 10 of breadboard and attach cathode end of LED to row '14' column 'h' of breadboard");
                s.Add("Attach one end of a 10k ohm resistor to row '14' column 'i' of breadboard and attach other end of resistor to the negative power rail to complete the circuit.");
                s.Add("Turn on the power supply and watch LED illuminate");

                //instruction = new WorkInstruction(i, title, desc, s);

                break;
            case 1:

                title = "Circuit Divider";
                desc = "Build a circuit divider to power an LED";

                s.Add("Materials:\n9 something probably");
                s.Add("test1");
                s.Add("test2");
                s.Add("test3");
                s.Add("test4");
                s.Add("test5");
                s.Add("test6");
                s.Add("test7");

                //instruction = new WorkInstruction(i, title, desc, s);


                break;
            default:
                break;
        }

        return instruction;

    }
}

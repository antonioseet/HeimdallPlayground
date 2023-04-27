using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
//using System.Text;

namespace WorkInstructionManager
{

    [System.Serializable]
    public class WorkInstructionWrapper
    {
        public WorkInstruction workInstruction { get; set; }
    }

    [System.Serializable]
    public class WorkInstruction
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<Instruction> instructionList { get; set; }

        private int index = 0;
        private readonly int max;

        public WorkInstruction(int inst_ID, string ins_Title, string ins_Description, List<Instruction> instructionsList)
        {
            this.id = inst_ID;
            this.title = ins_Title;
            this.description = ins_Description;
            this.instructionList = instructionsList;

            this.max = instructionsList.Count - 1;
        }
        public WorkInstruction(string json)
        {
            WorkInstructionWrapper wrapper = JsonUtility.FromJson<WorkInstructionWrapper>(json);
            WorkInstruction value = wrapper.workInstruction;

            this.id = value.id;
            this.title = value.title;
            this.description = value.description;
            this.instructionList = value.instructionList;
            this.max = value.instructionList.Count - 1;

        }

        public WorkInstruction()
        {
        }
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
        public static string sampleWorkInstruction1()
        {
            List<string> sampleSteps = new List<string>();
            sampleSteps.Add("Get out a large bowl to mix ingridients");
            sampleSteps.Add("Place brownie mix in the bowl");
            sampleSteps.Add("Place 1/2 cup of water in the bowl");
            sampleSteps.Add("Place 1/3 cup of vegetable oil in the bowl");
            sampleSteps.Add("Crack two eggs and add them to the bowl");
            sampleSteps.Add("Mix thoroughly!");
            sampleSteps.Add("Preheat oven to 350 degrees Farenheit (or 175 degrees Celcius)");
            sampleSteps.Add("Take out a baking pan, and coat it with cooking spray, oil, or butter");
            sampleSteps.Add("Place mixed contents in the pan");
            sampleSteps.Add("Once the oven is preheated, place the pan with brownie mix in the oven for 30 Minutes.");
            sampleSteps.Add("Once 30 minutes have passed, put on baking mit");
            sampleSteps.Add("Carefully remove the brownies from oven using the mit and place in a heat resistent surface");
            sampleSteps.Add("Wait a few minutes for them to cool, cut into the shape of your choosing");
            sampleSteps.Add("Serve");
            sampleSteps.Add("ENJOY!");

            List<Instruction> sampleInstructions = new List<Instruction>();

            for (int i = 0; i < sampleSteps.Count; i++)
            {
                string imageName = "img" + i + ".png";
                string dummyCoordinates = "10,10";
                sampleInstructions.Add(new Instruction(i, sampleSteps[i], imageName, dummyCoordinates, i));
            }

            // This bypasses the 'complete' instruction addition.
            WorkInstruction sample = new WorkInstruction
            {
                id = 12345,
                title = "Make Brownies",
                description = "When making brownies, make sure you have the right ingridients!\n- Brownie Mix\n- 2x Eggs\n- 1/3 cup of Veg Oil\n- 1/2 cup of Water",
                instructionList = sampleInstructions
            };

            WorkInstructionWrapper sampleWrapper = new WorkInstructionWrapper { workInstruction = sample };
            return JsonUtility.ToJson(sampleWrapper);
        }

    }

    [System.Serializable]
    public class Instruction
    {

        public int instructionId { get; set; }
        public string instructionText { get; set; }
        public string instructionImage { get; set; }
        public string instructionCoordinates { get; set; }
        public int instructionForeignKey { get; set; }

        public Instruction(int instructionId, string instructionText, string instructionImage, string instructionCoordinates, int foreignKey)
        {
            this.instructionId = instructionId;
            this.instructionText = instructionText;
            this.instructionImage = instructionImage;
            this.instructionCoordinates = instructionCoordinates;
            this.instructionForeignKey = foreignKey;
        }

        // Empty constructor for the deserializer.
        public Instruction() { }

    }

}

// TODO:
// - Instead of inserting a "COMPLETE" instruction at the end, find a more elegant solution.
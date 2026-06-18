using Godot;
using System;

//class governing using medicine to treat the patient in the patient room
public partial class TreatmentManager : Node
{
    //Storing a reference to all the buttons, labels, etc., for easy reference in the methods
    Sprite2D PatientDisplay;
    Label PatientInfo;
    ColorRect MedicineBackground;
    Button GiveMedicine1Button;
    Button GiveMedicine2Button;
    Button GiveMedicine3Button;
    Label WrongMedicinePopup;
    Label NoPatientPopup;
    Label PatientCuredPopup;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //grabs references to all the necessary nodes
        GetNodes();

        //assigning methods to all the buttons, yes this looks kinda wacky, but apparently that's how I gotta write it if I want to have methods that take arguments
        GiveMedicine1Button.Pressed += () => MedicineOperations(GiveMedicine1Button);
        GiveMedicine2Button.Pressed += () => MedicineOperations(GiveMedicine2Button);
        GiveMedicine3Button.Pressed += () => MedicineOperations(GiveMedicine3Button);
    }
    private void GetNodes()
    {
        //Basically just grabbing all the nodes
        PatientDisplay = GetParent().GetNode<Sprite2D>("Patient_Display");
        PatientInfo = GetParent().GetNode<Label>("Patient_Info");

        MedicineBackground = GetParent().GetNode<ColorRect>("Stylish_Medicine_Background");
        GiveMedicine1Button = MedicineBackground.GetNode<Button>("Give_Medicine_1");
        GiveMedicine2Button = MedicineBackground.GetNode<Button>("Give_Medicine_2");
        GiveMedicine3Button = MedicineBackground.GetNode<Button>("Give_Medicine_3");
        WrongMedicinePopup = MedicineBackground.GetNode<Label>("Wrong_Medicine_Popup");
        NoPatientPopup = MedicineBackground.GetNode<Label>("No_Patient_Popup");
        PatientCuredPopup = MedicineBackground.GetNode<Label>("Patient_Cured_Popup");
    }

    private void MedicineOperations(Button medicineChoice)
	{
        //setting up crucial parameters of a medicine, and changing them depending on which medicine is being usesd
        Medicine medicine = null;
        string matchingMalady = "none";
        if (medicineChoice == GiveMedicine1Button)
        {
            medicine = MedicineManager.Database["Morphine"];
            matchingMalady = "A";
        }
        else if (medicineChoice == GiveMedicine2Button)
        {
            medicine = MedicineManager.Database["Aspirin"];
            matchingMalady = "B";
        }
        else if (medicineChoice == GiveMedicine3Button)
        {
            medicine = MedicineManager.Database["Ozempic"];
            matchingMalady = "C";
        }

        if (PatientDisplay.Visible == false)
        {
            NoPatientPopup.Show();

        }
        //else if (GlobalData.Medicine1Count > 0)
        else if (medicine.amount > 0)
        {
            //if you try to use the medicine on the wrong malady, you get the appropriate popup, and the medicine buttons get disabled until you close it
            if (GlobalData.CurrentPatientMalady != matchingMalady)
            {
                WrongMedicinePopup.Show();
                GiveMedicine1Button.Disabled = true;
                GiveMedicine2Button.Disabled = true;
                GiveMedicine3Button.Disabled = true;
            }
            else
            {
                //the correct use of the medicine, severity goes down, you consume 1 medicine, the text gets updated
                GlobalData.CurrentPatientSeverity -= 1;
                medicine.amount--;
                PatientInfo.Text = "Patient info: \n Malady: Malady " + GlobalData.CurrentPatientMalady + "\n Severity: " + GlobalData.CurrentPatientSeverity; 
                medicineChoice.Text = $"{medicine.name} \n Owned: {medicine.amount}";
                //if you get the severity down to 0, the patient is cured, you get a popup, and you get paid
                if (GlobalData.CurrentPatientSeverity == 0)
                {
                    PatientCuredPopup.Show();
                    GiveMedicine1Button.Disabled = true;
                    GiveMedicine2Button.Disabled = true;
                    GiveMedicine3Button.Disabled = true;
                    GlobalData.DailyEarnings += 40;
                }
            }
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

using Godot;
using System;
using System.Threading.Tasks; // i added this for delays, but it may not be necessary 

public partial class MapUI : BoxContainer
{
    [Export] public Label RoomCount;
    [Export] public Label Funds;
    [Export] public Label PatientCount;
    [Export] public Button BuyRoomButton;
	[Export] public Label WarningLabel;
   
    private int roomCount = 1;
    private int currentFunds = 100;
    private int admittedPatients = 0;

    public override void _Ready()
    {
        UpdateUI();
        WarningLabel.Visible = false;
    }

    private void UpdateUI()
    {
        RoomCount.Text = $"Rooms: {roomCount}";
        Funds.Text = $"Funds: {currentFunds} credits";
        PatientCount.Text = $"Patients: {admittedPatients}";
    }

    public async void OnBuyRoomButtonPressed()
    {
        const int cost = 10;
        if (currentFunds >= cost)
        {
            currentFunds -= cost;
            roomCount += 1;
            UpdateUI();
        }
        else
        {
			WarningLabel.Visible = true;
			await Task.Delay(2000); // wait 2 sseconds before hiding the warning again
			WarningLabel.Visible = false;
        }
    }
}
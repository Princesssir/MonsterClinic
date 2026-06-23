using Godot;
using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

public partial class Mirror : Button
{

    //All the necessary mirror references
    Button MirrorButton;
    Button Close;
    Label MirrorLabel;

    TextureRect MirrorImage;

    Texture2D[] mirrorImages =
    {
        // These are the place holder images stored in the godot files for the office
        GD.Load<Texture2D>("res://Assets/2D Art/Office/MirrorImage/stickman1.png"),
        GD.Load<Texture2D>("res://Assets/2D Art/Office/MirrorImage/stickman2.png"),
        GD.Load<Texture2D>("res://Assets/2D Art/Office/MirrorImage/stickman3.png"),
        GD.Load<Texture2D>("res://Assets/2D Art/Office/MirrorImage/stickman4.png")
    };
    public override void _Ready()
    {
        // Grabbing all the mirror references
        // MirrorButton reference is unecessary and should just be replaced with "this"
        MirrorButton = this;
        MirrorLabel = GetNode<Label>("MirrorLabel");
        Close = MirrorLabel.GetNode<Button>("Close");

        MirrorImage = MirrorLabel.GetNode<TextureRect>("MirrorImage");


        //Hiding the mirror since we only want to see it once clicked.
        HideMirrorCloseUp();

        //Subscribing to the relevant events
        MirrorButton.Pressed += ShowMirrorCloseUp;
        Close.Pressed += HideMirrorCloseUp;

        MirrorButton.Pressed += ChangeMirrorImage;
    }


    //Showing and hiding the mirror, pretty simple.
    private void ShowMirrorCloseUp()
    {
        MirrorLabel.Show();
    }

    private void HideMirrorCloseUp()
    {
        MirrorLabel.Hide();
    }

    // Sorting out the images so that they change color according to the days left
    private void ChangeMirrorImage()
    {
        if (GlobalData.Countdown >= 4)
        {
            // Green (4 days)
            MirrorImage.Texture = mirrorImages[3];
        }

        else if (GlobalData.Countdown == 3)
        {
            // Yellow (3 days)
            MirrorImage.Texture = mirrorImages[2];
        }

        else if (GlobalData.Countdown == 2)
        {
            // orange (2 days)
            MirrorImage.Texture = mirrorImages[1];
        }

        else if (GlobalData.Countdown <= 1)
        {
            // Red (1 day)
            MirrorImage.Texture = mirrorImages[0];
        }

    }

}
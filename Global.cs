using Godot;
using System;

namespace global
{
	public static class Variables
	{
		public static int Countdown { get; set; } = 4;

		public static int Money { get; set; } = 100;

		//this is the memory that carries the sprite across scene
    public static Texture2D AdmittedPatientTexture { get; set; }
	}

}

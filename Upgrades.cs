using Godot;
using System;

static class Upgrades
{
	public static int roomCount { get; private set; }

	public static void AddNewRoom()
	{
		roomCount++;
		Economy.roomCost = (int)((float)Economy.roomCost * Economy.roomCostInflation);
    }
}

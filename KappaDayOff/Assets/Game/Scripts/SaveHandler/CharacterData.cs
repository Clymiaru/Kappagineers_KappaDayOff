using System;

[Serializable]
public class CharacterData
{
	public int MaxHP;
	public int HPLevel;

	public float BarrierCooldownTime;
	public int   BarrierCooldownLevel;

	public CharacterData(int maxHP = 50, float barrierCooldownTime = 60)
	{
		MaxHP                = maxHP;
		HPLevel              = 1;
		BarrierCooldownTime  = barrierCooldownTime;
		BarrierCooldownLevel = 1;
	}
}
using UnityEngine.Rendering;

namespace Player
{
    public class Stat
    {
        public float Value { get; private set; }

        public Stat(float value)
        {
            Value = value;
        }
        public void IncStat(float additional)
        {
            Value += additional;
        }

    }

    public class PlayerStats
    {
        private Stat Strength { get; set; }
        private Stat Agility { get; set; }
        private Stat Intelligence { get; set; }
        private Stat Stamina { get; set; }

        public PlayerStats(float strength, float stamina, float agility, float intelligence)
        {
            Strength = new Stat(strength);
            Agility = new Stat(agility);
            Intelligence = new Stat(intelligence);
            Stamina = new Stat(stamina);
        }

        
        
    }
}
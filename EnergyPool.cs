namespace CardGame;
    public class EnergyPool
    {
        private Dictionary<string, int> energy = new Dictionary<string, int>();
        public Dictionary<string, int> Energy { get => energy; }
        public void AddEnergy(string color, int amount)
        {
            if (energy.ContainsKey(color))
                energy[color] += amount;
            else
                energy.Add(color, amount);
        }

        public void RemoveEnergy(string color, int amount)
        {
            if (energy.ContainsKey(color))
                energy[color] -= amount;
            else
                throw new Exception("No energy of that color");
        }

        public void UseEnergy(string color, int amount)
        {
            if (energy.ContainsKey(color))
            {
                if (energy[color] >= amount)
                    energy[color] -= amount;
                else
                    throw new Exception("Not enough energy of that color");
            }
            else
                throw new Exception("No energy of that color");
        }
    }
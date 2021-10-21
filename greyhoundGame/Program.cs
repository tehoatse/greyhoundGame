namespace greyhoundGame
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class GreyHoundStrings
    {
        //a list of strings to apply to names and descriptions
        public static string TopSpeed = "Top Speed";
        public static string TopSpeedDesc = "Measures the fastest a greyhound can travel";
        public static string Stamina = "Stamina";
        public static string StaminaDesc = "How long can a greyhound run?";
        public static string Accelertion = "Acceleration";
        public static string AccelerationDesc = "How quickly the animal will reach top speed";
        public static string Health = "Health";
        public static string HealthDesc = "A measure of how much a greyhound can be hurt";
        public static string Armor = "Armor";
        public static string ArmorDesc = "The natural protection of the animal";
        public static string Confidence = "Confidence";
        public static string ConfidenceDesc = "How confident is the animal, how likely is it to take risks?";
        public static string Tenacity = "Tenacity";
        public static string TenacityDesc = "How long can the greyhound keep this up?";
        public static string Balance = "Balance";
        public static string BalanceDesc = "Whether or not the animal can keep its feet";
        public static string Agility = "Agility";
        public static string AgilityDesc = "The greyhound's ability to move effectively... when it needs to";
        public static string Strength = "Strength";
        public static string StrengthDesc = "Will the animal come out on top?";
        public static string Aggression = "Aggression";
        public static string AggressionDesc = "Will this greyhound start a fight?";
        public static string Fitness = "Fitness";
        public static string FitnessDesc = "How appropriate is this animal for its environment?";
    }

    class Greyhound
    {
        // a greyhound has statistics
        public StatList Stats { get; set; }

    }

    class Stat
    {
        // the value of the statistic can't be less than 1, can't be more than 120
        private int _statistic;
        public int StatValue
        {
            get => _statistic;
            set
            {
                //can't be more than 120
                if (value > 120)
                    _statistic = 120;
                //can't be less than 1
                else if (value < 1)
                    _statistic = 1;
                else
                    _statistic = value;
            }
        }

        // extra stuff to add flavour
        public string Name { get; set; }
        public string Description { get; set; }

        public Stat()
        {
            StatValue = 1;
        }

        public Stat(int stat)
        {
            StatValue = stat;
        }

        public Stat(string name, string desc)
        {
            Name = name;
            Description = desc;
            StatValue = 1;
        }

        public Stat(string name, string desc, int newStat)
        {
            StatValue = newStat;
            Name = name;
            Description = desc;
        }
    }

    class StatList
    {
        public Stat TopSpeed { get; set; }
        public Stat Stamina { get; set; }
        public Stat Acceleration { get; set; }
        public Stat Health { get; set; }
        public Stat Armor { get; set; }
        public Stat Confidence { get; set; }
        public Stat Tenacity { get; set; }
        public Stat Balance { get; set; }
        public Stat Agilty { get; set; }
        public Stat Strength { get; set; }
        public Stat Aggression { get; set; }
        public Stat Fitness { get; set; }


        // creates a set of stats defaulting to 1
        public StatList()
        {
            CreateStats();
        }

        public StatList(int[] stats)
        {
            CreateStats(stats);
        }

        public Stat[] ListStats()
        {
            Stat[] returnList = {
                TopSpeed,
                Stamina,
                Acceleration,
                Health,
                Armor,
                Confidence,
                Tenacity,
                Balance,
                Agilty,
                Strength,
                Aggression,
                Fitness
            };

            return returnList;
        }

        // the contructors use this to CreateStats()
        private void CreateStats()
        {
            TopSpeed = new Stat(GreyHoundStrings.TopSpeed, GreyHoundStrings.TopSpeedDesc);
            Stamina = new Stat(GreyHoundStrings.Stamina, GreyHoundStrings.StaminaDesc);
            Acceleration = new Stat(GreyHoundStrings.Accelertion, GreyHoundStrings.AccelerationDesc);
            Health = new Stat(GreyHoundStrings.Health, GreyHoundStrings.HealthDesc);
            Armor = new Stat(GreyHoundStrings.Armor, GreyHoundStrings.ArmorDesc);
            Confidence = new Stat(GreyHoundStrings.Confidence, GreyHoundStrings.ConfidenceDesc);
            Tenacity = new Stat(GreyHoundStrings.Tenacity, GreyHoundStrings.TenacityDesc);
            Balance = new Stat(GreyHoundStrings.Balance, GreyHoundStrings.BalanceDesc);
            Strength = new Stat(GreyHoundStrings.Strength, GreyHoundStrings.StrengthDesc);
            Aggression = new Stat(GreyHoundStrings.Aggression, GreyHoundStrings.AggressionDesc);
            Fitness = new Stat(GreyHoundStrings.Fitness, GreyHoundStrings.FitnessDesc);

        }

        private void CreateStats(int[] stats)
        {
            CreateStats();
            var list = ListStats();

            // assigning stats
            for (int i = 0; i < list.Length; i++)
                list[i].StatValue = stats[i];
        }
    }
}

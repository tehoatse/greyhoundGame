namespace greyhoundGame
{
    public class Stat
    {
        // the value of the statistic can't be less than 1, can't be more than 120, statistics over 80 are exceptional, over 100 unique
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

        // constructors. there's no point of having a greyhound without a stat, also gamefalldown so have a stat please!
        public Stat()
        {
            StatValue = 1;
        }

        public Stat(int stat)
        {
            StatValue = stat;
        }

        // we want to give a greyhound basic stats starting with 1 
        public Stat(string name, string desc)
        {
            Name = name;
            Description = desc;
            StatValue = 1;
        }

        // giving a statistic a name, a description and a number
        public Stat(string name, string desc, int newStat)
        {
            StatValue = newStat;
            Name = name;
            Description = desc;
        }

        public override string ToString()
        {
            return $"{Name}: {StatValue} - {Description}\n";
        }
    }
}

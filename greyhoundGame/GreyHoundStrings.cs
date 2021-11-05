namespace greyhoundGame
{    public static class GreyhoundStrings
    {
        //a list of strings to apply to names and descriptions of statistics
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
        public static string Size = "Size";
        public static string SizeDesc = "How large is the greyhound. Large can be good, small can be better.";

        // ordinal numbers
        private static string First = "first";
        private static string Second = "second";
        private static string Third = "third";
        private static string Fourth = "fourth";
        private static string Fifth = "fifth";
        private static string Sixth = "sixth";
        private static string Seventh = "seventh";
        private static string Eighth = "eighth";
        private static string Ninth = "ninth";
        private static string Tenth = "tenth";
        private static string Eleventh = "eleventh";
        private static string Twelfth = "twelfth";
        private static string Thirteenth = "thirteenth";
        private static string Fourteenth = "fourteenth";
        private static string Fifteenth = "fifteenth";
        private static string Sixteenth = "sixteenth";
        private static string Seventeenth = "seventeenth";
        private static string Eighteenth = "eighteenth";
        private static string Nineteenth = "nineteenth";
        private static string Twentieth = "twentieth";

        private static string FirstNum = "1st";
        private static string SecondNum = "2nd";
        private static string ThirdNum = "3rd";
        private static string FourthNum = "4th";
        private static string FifthNum = "5th";
        private static string SixthNum = "6th";
        private static string SeventhNum = "7th";
        private static string EighthNum = "8th";
        private static string NinthNum = "9th";
        private static string TenthNum = "10th";
        private static string EleventhNum = "11th";
        private static string TwelfthNum = "12th";
        private static string ThirteenthNum = "13th";
        private static string FourteenthNum = "14th";
        private static string FifteenthNum = "15th";
        private static string SixteenthNum = "16th";
        private static string SeventeenthNum = "17th";
        private static string EighteenthNum = "18th";
        private static string NineteenthNum = "19th";
        private static string TwentiethNum = "20th";

        private static string[] OrdinalNames =
        {
            First,
            Second,
            Third,
            Fourth,
            Fifth,
            Sixth,
            Seventh,
            Eighth,
            Ninth,
            Tenth,
            Eleventh,
            Twelfth,
            Thirteenth,
            Fourteenth,
            Fifteenth,
            Sixteenth,
            Seventeenth,
            Eighteenth,
            Nineteenth,
            Twentieth
        };

        private static string[] OrdinalNum =
        {
            FirstNum,
            SecondNum,
            ThirdNum,
            FourthNum,
            FifthNum,
            SixthNum,
            SeventhNum,
            EighthNum,
            NinthNum,
            TenthNum,
            EleventhNum,
            TwelfthNum,
            ThirteenthNum,
            FourteenthNum,
            FifteenthNum,
            SixteenthNum,
            SeventeenthNum,
            EighteenthNum,
            NineteenthNum,
            TwentiethNum
        };

        // this one only goes up to 20
        public static string GetOrdinalName(int i)
        {
            // if it's too big just give then Twentieth
            if (i > 20)
                return OrdinalNames[OrdinalNames.Length-1];
            // send an int, get back the ordinal name 'first' etc
            return OrdinalNames[i-1];
        }
        
        public static string GetOrdinalNumber(int ordinalNumber)
        {
            // special cases
            if (ordinalNumber < 1)
                return OrdinalNum[0];

            if (ordinalNumber <= 20)
                return OrdinalNum[ordinalNumber - 1];

            string textVersion = InsertSeparator(ordinalNumber.ToString());

            // converting the last two characters to numbers so we can operate on them
            int lastTwoNumerals = int.Parse(textVersion.Substring(textVersion.Length - 2, 2));
            int lastNumeral = int.Parse(textVersion.Substring(textVersion.Length - 1, 1));

            // I think that fixes the problem
            if (lastNumeral == 0)
                return textVersion + "th";
            
            // if the last two digits are between 10 and 20 they're special 
            if(lastTwoNumerals >= 10 && lastTwoNumerals <= 20)
                return textVersion.Remove(textVersion.Length - 2) + textVersion + OrdinalNum[lastTwoNumerals - 2];

            return textVersion.Remove(textVersion.Length - 1) + OrdinalNum[lastNumeral- 1];
        }

        public static string InsertSeparator(string subject)
        {
            subject = InsertSeparator(subject, ',', 3);
            return subject;
        }

        public static string InsertSeparator(string subject, char separator)
        {
            subject = InsertSeparator(subject, separator, 3);
            return subject;
        }

        public static string InsertSeparator(string subject, string separator)
        {
            subject = InsertSeparator(subject, separator, 3);
            return subject;
        }

        public static string InsertSeparator(string subject, char separator, int spaces)
        {
            subject = InsertSeparator(subject, separator.ToString(), spaces);
            return subject;
        }

        public static string InsertSeparator(string subject, string separator, int spaces)
        {
            int separatorCounter = 1;

            for (int counter = subject.Length - 1; counter > 0; counter--)
            {
                if (separatorCounter % spaces == 0)
                    subject = subject.Insert(counter, separator);
                separatorCounter++;
            }
            return subject;
        }


    }
}

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

        // ordinal numbers
        public static string First = "first";
        public static string Second = "second";
        public static string Third = "third";
        public static string Fourth = "fourth";
        public static string Fifth = "fifth";
        public static string Sixth = "sixth";
        public static string Seventh = "seventh";
        public static string Eighth = "eighth";
        public static string Ninth = "ninth";
        public static string Tenth = "tenth";
        public static string Eleventh = "eleventh";
        public static string Twelfth = "twelfth";
        public static string Thirteenth = "thirteenth";
        public static string Forteenth = "forteenth";
        public static string Fifteenth = "fifteenth";
        public static string Sixteenth = "sixteenth";
        public static string Seventeenth = "seventeenth";
        public static string Eighteenth = "eighteenth";
        public static string Nineteenth = "nineteenth";
        public static string Twentieth = "twentieth";

        public static string FirstNum = "1st";
        public static string SecondNum = "2nd";
        public static string ThirdNum = "3rd";
        public static string FourthNum = "4th";
        public static string FifthNum = "5th";
        public static string SixthNum = "6th";
        public static string SeventhNum = "7th";
        public static string EighthNum = "8th";
        public static string NinthNum = "9th";
        public static string TenthNum = "10th";
        public static string EleventhNum = "11th";
        public static string TwelfthNum = "12th";
        public static string ThirteenthNum = "13th";
        public static string ForteenthNum = "14th";
        public static string FifteenthNum = "15th";
        public static string SixteenthNum = "16th";
        public static string SeventeenthNum = "17th";
        public static string EighteenthNum = "18th";
        public static string NineteenthNum = "19th";
        public static string TwentiethNum = "20th";

        public static string[] OrdinalNames =
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
            Forteenth,
            Fifteenth,
            Sixteenth,
            Seventeenth,
            Eighteenth,
            Nineteenth,
            Twentieth
        };

        public static string[] OrdinalNum =
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
            ForteenthNum,
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
        
        //
        public static string GetOrdinalNum(int i)
        {

            // special cases
            if (i < 1)
                return OrdinalNum[0];

            if (i <= 20)
                return OrdinalNum[i - 1];

            // send an int, get back the ordinal abbreviation '1st' etc
            string textVersion = i.ToString();
            string endText = textVersion.Substring(textVersion.Length - 2, 2); // I think this gets the final two characters? I'll TEST
            

            // converting the last two characters to numbers so we can operate on them
            int lastTwoNum = int.Parse(endText);
            int lastNum = int.Parse(endText.Substring(endText.Length - 1, 1));

            // I think that fixes the problem
            if (lastNum == 0)
                return textVersion + "th";
            
            // if the last two digits are between 10 and 20 they're special 
            if(lastTwoNum >= 10 && lastTwoNum <= 20)
                return textVersion.Remove(textVersion.Length - 2) + textVersion + OrdinalNum[lastTwoNum - 2];

            return textVersion.Remove(textVersion.Length - 1) + OrdinalNum[lastNum - 1];
        }

    }
}

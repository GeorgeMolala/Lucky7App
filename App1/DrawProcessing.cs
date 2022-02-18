namespace Lucky_7_Analysi
{
    class DrawProcessing
    {
        //Sums
        public int yellowSum = 0;
        public int blackSum = 0;
        public int colourSum = 0;

        //Dominancy Variable
        public string DominantColour = "";
        //Default Numbers
        protected int[] yellow = { 1, 3, 5, 8, 10, 12, 13, 15, 17, 20, 22, 24, 26, 27, 29, 32, 34, 36, 37, 39, 41 };
        private int[] black = { 2, 4, 6, 7, 9, 11, 14, 16, 18, 19, 21, 23, 25, 28, 30, 31, 33, 35, 38, 40, 42 };
        //protected int[] yellowdraws;


        public string Draw { get; set; }





        //Data Fetching Properties Draw

        public int[] blackparse
        {
            get
            {
                return black;
            }
        }
        public int[] yellowparse //{ get; set; }
        {
            get
            {
                return yellow;
            }

        }

        // Total Matches per Draw
        public int blackTotal { get; set; }
        public int yellowTotal { get; set; }

        //Filtered by Colour
        protected int[] Blackmatches = new int[7];
        protected int[] Yellowmatches = new int[7];

        //Dropped draw Array
        public int[] yellowMatches { get; set; }
        public int[] blackMatches { get; set; }


        // Accessing Filtered Coloured
        public int[] Blackparse
        {
            get
            {
                return Blackmatches;
            }
        }
        public int[] Yellowparse
        {
            get { return Yellowmatches; }
        }


        public int MatchNums { get; set; }



    }
}

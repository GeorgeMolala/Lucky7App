namespace Lucky_7_Analysi
{
    class Black : DrawProcessing
    {


        //// Total Matches per Draw
        public int BlackTesting
        {
            get
            {


                for (int i = 0; i <= Blackparse.Length - 1; i++)
                {
                    blackSum = blackSum + Blackparse[i];
                    if (Blackparse[i] > 0)
                    {
                        blackTotal++;

                    }

                }


                return blackTotal;
            }
        }


        // Assigning Filtered Coloured
        public int[] blackTesting
        {
            get
            {
                int t = 0;
                for (int i = 0; i <= blackMatches.Length - 1; i++)
                {
                    int Search = blackMatches[i];

                    if (Search == blackparse[i])
                    {
                        Blackmatches[t] = Search;

                        t++;

                        this.MatchNums++;
                    }
                    else
                    {
                        for (int f = 0; f <= blackparse.Length - 1; f++)
                        {
                            if (Search == blackparse[f])
                            {
                                Blackmatches[t] = Search;
                                t++;
                            }
                        }

                    }

                }
                return Blackmatches;
            }
        }
    }
}

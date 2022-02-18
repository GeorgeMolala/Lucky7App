namespace Lucky_7_Analysi
{
    class Yellow : DrawProcessing
    {
        //private int[] yellowDraws;


        DrawProcessing drops = new DrawProcessing();

        public int YellowTesting
        {
            get
            {
                for (int i = 0; i <= Yellowparse.Length - 1; i++)
                {
                    yellowSum = yellowSum + Yellowparse[i];

                    if (Yellowparse[i] > 0)
                    {
                        yellowTotal++;

                    }

                }



                return yellowTotal;
            }
        }


        public int[] yellowTesting
        {

            get
            {

                int t = 0;
                for (int i = 0; i <= this.yellowMatches.Length - 1; i++)
                {
                    int Search = this.yellowMatches[i];

                    if (Search == yellowparse[i])
                    {
                        Yellowmatches[t] = Search;

                        t++;

                        this.MatchNums++;
                        //return Yellowmatches;
                    }
                    else
                    {
                        for (int f = 0; f <= yellow.Length - 1; f++)
                        {
                            if (Search == yellowparse[f])
                            {


                                Yellowmatches[t] = Search;

                                t++;
                                this.MatchNums++;

                            }

                        }


                    }


                }


                return Yellowmatches;

            }


        }


    }
}


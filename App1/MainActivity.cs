using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Lucky_7_Analysi;
using System;
using System.Linq;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, Icon = "@drawable/Haha")]
    public class MainActivity : AppCompatActivity
    {
        public int d1;
        public int d2;
        public int dkey;
        public int signal;
        public int direc1;
        public int direc2;
        public int D1;
        public int D2;
        public int D3;
        public int bingosPlus;
        public double yellowDiv;
        public double blackDiv;
        public double totalDiv;

        EditText dropssed;
        EditText sig11;
        EditText sig22;
        EditText sig33;
        Button Submi;
        TextView display;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            dropssed = FindViewById<EditText>(Resource.Id.drawsEditText);
            sig11 = FindViewById<EditText>(Resource.Id.d11);
            sig22 = FindViewById<EditText>(Resource.Id.d22);
            sig33 = FindViewById<EditText>(Resource.Id.d33);
            Submi = FindViewById<Button>(Resource.Id.submitter);
            display = FindViewById<TextView>(Resource.Id.displayR);

            Submi.Click += SubmiClicked;

        }

        private void SubmiClicked(object sender, EventArgs e)
        {
            //yellow drop = new Yellow();
            DrawProcessing drops = new DrawProcessing();
            Black blackDrops = new Black();
            Yellow drop = new Yellow();

            D1 = int.Parse(sig11.Text);
            D2 = int.Parse(sig22.Text);
            D3 = int.Parse(sig33.Text);




            string splitters = dropssed.Text[1].ToString();
            string[] test;
            {                        
                if (splitters == ".")
                {
                    test = dropssed.Text.Split(".");
                }

                else
                {
                    test = dropssed.Text.Split("\n");
                }
            }



            int[] dropped = test.Select(int.Parse).ToArray();

            blackDrops.blackMatches = test.Select(int.Parse).ToArray();
            drop.yellowMatches = test.Select(int.Parse).ToArray();

            //Needs Special Attention
            //drop.Draw = txtDrawResult.Text;

            NextRound();
            signLocator1();
            signLocator2();
            //nextDropBoom();

            int[] entry = new int[3];
            entry[0] = D1;
            entry[1] = D2;
            entry[2] = D3;

            int bingo = nextDropBoom();
            for (int s = 0; s <= 2; s++)
            {
                if (bingo == entry[s])
                {
                    signal = entry[s];
                    break;
                }
                else
                {
                    signal = -1;
                }
            }
            // for (int i = 0; i <= 2; i++)
            //  {
            //MessageBox.Show("Yelow: " + drop.yellowTesting[i].ToString() + "\n" + "Black: " + blackDrops.blackTesting[i].ToString());
            //MessageBox.Show(bingo.ToString());
            //}
            Toast.MakeText(this, drop.yellowTesting[1].ToString() + "  " + blackDrops.blackTesting[1] + "\n" + "Black Matches: " + blackDrops.BlackTesting + "  Yellow Matches: " + drop.YellowTesting, ToastLength.Long).Show();

            //Colour Dominancy
            {
                if (drop.yellowTotal > blackDrops.blackTotal)
                {
                    drops.DominantColour = "Yellow Dominant";
                }
                else
                {
                    drops.DominantColour = "Black Dominant";
                }
            }

            // Second Layer
            int Sum = drop.yellowSum + blackDrops.blackSum;
            yellowDiv = 451 / drop.yellowSum;
            blackDiv = 452 / blackDrops.blackSum;
            totalDiv = 903 / Sum;
            double yellowDiv2 = 451 / Sum;
            double blackDiv2 = 452 / Sum;

            //Entry Colour decider
            EntryColour();

            // display.Text 
            string D = "Dominancy: " + drops.DominantColour + "\n" + "Yellow Sum: " + drop.yellowSum + "\n" + "Black Sum: " + blackDrops.blackSum + "\n" + "Sum: " + Sum +
                 "\n" + "Black Match: " + blackDrops.blackTotal + "\n" + "Yellow Match: " + drop.yellowTotal + "\n" + "Signal Confirmations" + "\n" + "Number Pattern: " + bingo + " ; " + bingosPlus + "\n" +
                "Division Type: " + yellowDiv + " ; " + blackDiv + " ; " + totalDiv + " ; " + yellowDiv2 + " ; " + blackDiv2 + "\n" + "Entry Colour(X): " + EntryColour()+ "\n" +"Origanl Drops: " + D1 + " ; " + D2 + " ; " + D3;


            display.Text = D;
            Toast.MakeText(this, "Dominancy: " + drops.DominantColour + "\n" + "Yellow Sum: " + drop.yellowSum + "\n" + "Black Sum: " + blackDrops.blackSum + "\n" + "Sum: " + Sum +
                "\n" + "Black Match: " + blackDrops.blackTotal + "\n" + "Yellow Match: " + drop.yellowTotal + "\n" + "Signal Confirmations" + "\n" + "Number Pattern: " + bingo + " ; " + bingosPlus + "\n" +
               "Division Type: " + yellowDiv + " ; " + blackDiv + " ; " + totalDiv + " ; " + yellowDiv2 + " ; " + blackDiv2 + "\n" + "Origanl Drops: " + D1 + " ; " + D2 + " ; " + D3, ToastLength.Long).Show();

            Snackbar.Make(display, "O tlokwa Monate... Not 100% accurate, Use at own Risk", Snackbar.LengthLong)
                   .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        //COLOUR DECIDER FOR ENTRIES
        public string EntryColour()
        {
            DrawProcessing draw = new DrawProcessing();
            string FinalColour = "";

            double colour = yellowDiv - blackDiv;
            double color = blackDiv - totalDiv;
            double DColour = colour - color;


            for (int i = 0; i <= 20; i++)
            {
                if (Math.Abs(DColour) == draw.blackparse[i])
                {
                    FinalColour = "Black";
                    //MessageBox.Show(FinalColour + "Testing Colour");
                    return FinalColour;

                }
                else if (Math.Abs(DColour) == draw.yellowparse[i])
                {
                    FinalColour = "Yellow";
                    // MessageBox.Show(FinalColour+ " Testing colour");
                    return FinalColour;
                }

                else
                {
                    FinalColour = "No Direcction";
                }
            }
            //  MessageBox.Show(FinalColour);
            return FinalColour;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        /// <summary>
        /// //
        /// </summary>
        /// <returns></returns>
        public int nextDropBoom()
        {
            int bingos;
            if (direc1 == -1 && direc2 == 1)
            {
                if (dkey > d2)
                {

                    bingos = gameon();

                    return bingos;

                }
                else
                {

                    // bingos = (d2 - dkey) - D3;
                    bingos = gameon2();

                }
                return bingos;
            }

            else if (direc1 == -1 && direc2 == -1)
            {

                if (dkey > d2)
                {
                    // bingos = (dkey - d2) - D3;
                    bingos = gameon();

                }
                else
                {
                    //bingos = (d2 - dkey) - D3;
                    bingos = gameon2();
                }
            }

            else if (direc1 == 1 && direc2 == -1)
            {

                if (dkey > d2)
                {
                    // bingos = (dkey - d2) + D3;
                    bingos = gameon3Pos();
                }
                else
                {
                    //bingos = (d2 - dkey) + D3;
                    bingos = gameon3Pos2();

                }
            }
            else
            {
                if (dkey > d2)
                {
                    //bingos = (dkey - d2) + D3;
                    bingos = gameon3Pos();

                }
                else
                {
                    //bingos = (d2 - dkey) + D3;
                    bingos = gameon3Pos2();

                }
            }

            return bingos;

        }
        //Incase We encounter 0 on D1
        public int gameon3Pos2()
        {
            int yeah, king;
            int bingos;


            if (d1 == 0)
            {

                yeah = (dkey + d2);
                king = (D2 * D3) - (yeah * D1);
                bingos = king + D3;
                return bingos;
            }
            else if (d2 == 0)
            {
                bingos = (dkey - d2) + D3;
                bingosPlus = (dkey + d2) - D3;
                return bingos;
            }
            else
            {
                bingos = (d2 - dkey) + D3;
                bingosPlus = (d2 + dkey) + D3;
            }
            return bingos;
        }

        public int gameon3Pos()
        {
            int yeah, king;
            int bingos;


            if (d1 == 0)
            {

                yeah = (dkey + d2);
                king = (D2 * D3) - (yeah * D1);
                bingos = king + D3;


                return bingos;

            }
            else if (d2 == 0)
            {
                bingos = (dkey - d2) + D3;
                bingosPlus = (dkey + d2) - D3;
                return bingos;
            }
            else
            {
                bingos = (dkey - d2) + D3;
                bingosPlus = (dkey + d2) + D3;
            }

            return bingos;
        }

        public int gameon()
        {

            int yeah, king;
            int bingos;
            if (d1 == 0)
            {
                yeah = (dkey + d2);
                king = (D2 * D3) - (yeah * D1);
                bingos = king - D3;
                return bingos;
            }
            else if (d2 == 0)
            {
                bingos = (dkey - d2) + D3;
                bingosPlus = (dkey + d2) - D3;
                return bingos;
            }
            else
            {
                bingos = (dkey - d2) - D3;
                bingosPlus = (dkey + d2) - D3;
            }
            return bingos;
        }

        public int gameon2()
        {
            int yeah, king;
            int bingos;
            if (d1 == 0)
            {
                yeah = (dkey + d2);
                king = (D2 * D3) - (yeah * D1);
                bingos = king - D3;

                return bingos;
            }
            else if (d2 == 0)
            {
                bingos = (dkey - d2) + D3;
                bingosPlus = (dkey + d2) - D3;
                return bingos;
            }
            else
            {
                bingos = (d2 - dkey) - D3;

                bingosPlus = (d2 + dkey) - D3;
            }
            return bingos;
        }
        public int signLocator1()
        {

            if (D1 > D2)
            {
                direc1 = -1;
                return direc1;

            }
            else if (D1 < D2)
            {
                direc1 = 1;
                return direc1;
            }

            else
            {
                direc1 = 1;
            }

            return direc1;
        }

        public int signLocator2()
        {
            if (D2 > D3)
            {
                direc2 = -1;
                return direc2;
            }
            else if (D2 < D3)
            {
                direc2 = 1;
                return direc2;
            }

            else
            {
                direc2 = 1;

            }

            return direc2;
        }
        public int NextRound()
        {
            //int d1, d2;

            if (D1 >= D2 && D3 >= D2)
            {
                d1 = D1 - D2;
                d2 = D3 - D2;
                areyeng();
                return d2;
            }
            else if (D1 >= D2 && D3 <= D2)
            {
                d1 = D1 - D2;
                d2 = D2 - D3;
                areyeng();
                return d2;
            }
            else if (D1 <= D2 && D3 >= D2)
            {
                d1 = D2 - D1;
                d2 = D3 - D2;
                areyeng();
                return d2;
            }
            else if (D1 <= D2 && D3 <= D2)
            {
                d1 = D2 - D1;
                d2 = D2 - D3;

            }


            areyeng();
            return d1;
        }
        public int areyeng()
        {
            if (d1 > d2)
            {
                dkey = d1 - d2;

            }
            else
            {
                dkey = d2 - d1;

            }


            return dkey;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

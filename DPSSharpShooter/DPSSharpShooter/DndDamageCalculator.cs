using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;

public enum AdvantageType //If I choose to add more forms in the future, I'd like to keep it public. 
{
    normal,
    advantage,
    disadvantage
}

namespace DPSSharpShooter
{
    public partial class DndDamageCalculator : Form
    {
        //I attempted local variables, however, I was running into an unknown error.
        //I plan to convert some of them to be more local at a future date. 
        private AdvantageType advantageType = AdvantageType.normal; 
        private int ac = 15; 
        private int attack = 7; 
        private int attackDamage = 3;
        private int dieSides = 6;                                                           
        private float avgDPA; 
        private float attackDieAverage = 0;
        private int maxHit;
        private float chanceToHit = 0;
        
        public DndDamageCalculator() 
        { 
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()// sets default values for the variables.
        {
            attackText.Text = attack.ToString();
            acText.Text = ac.ToString();
            attackModifierText.Text = attackDamage.ToString();
            attackDieText.Text = dieSides.ToString();
            DieSideCalculation();
        }
        private void DieSideCalculation() 
        {
            attackDieAverage = ((float)dieSides/2) + 0.5f; //Used to be far more complicated than it was before, but I'm keeping the funciton here just to keep it organized.  
            //Console.WriteLine(attackDieAverage.ToString());
        }

        private bool ChanceToHitCalculator(int roll)
        {
            if(roll == 20)//Crit always hits
            {
                return true;
            }
            if (roll == 1)//Crit Fail always misses
            {
                return false;
            }


            if (sharpshooter.Checked)
            {
                return roll + attack - 5 >= ac;
            }
            else
            {
                return roll + attack >= ac;
            }
        }
        private int MaxHitCalculator(bool crit)
        {
            if (crit)
            {
                maxHit = attackDamage + dieSides + dieSides; //Two dice rolls on a crit. 
            }
            else
            {
                maxHit = attackDamage + dieSides;
            }
            
            if (sharpshooter.Checked)
            {
                maxHit += 10;
            }
            return maxHit;
        }
        //These are the events when the text changes. 
        private void textBox1_TextChanged(object sender, EventArgs e) 
        {
            checkText(ref attackText, ref attack);
        }
        private void textBox2_TextChanged(object sender, EventArgs e) 
        {
            checkText(ref acText, ref ac);
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e) 
        {
            checkText(ref attackModifierText, ref attackDamage);
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e) 
        {
            checkText(ref attackDieText, ref dieSides);
            DieSideCalculation();
        }

        private void calculateButton_Click(object sender, EventArgs e) 
        {
            CheckAll();
            CalculateResults();
        }
        private void CheckAll() 
        {
            checkText(ref attackDieText, ref dieSides);
            checkText(ref attackText, ref attack);
            checkText(ref acText, ref ac);
            checkText(ref attackModifierText, ref attackDamage);
        }//Fail safe in case some Parse failed. 
        private void CalculateResults() 
        {
            DieSideCalculation();
            DisplayResults();
        }

        private void DisplayResults() //shows the results of the calculation
        {
            maxHitNormalText.Text = "Max Hit Normal: " + MaxHitCalculator(false);
            maxHitCritText.Text = "Max hit with Crit: " + MaxHitCalculator(true);
            avgDamageText.Text = "Average Damage Per Attack: " + CalculateAverageDPA();
            chanceToHitText.Text = "Chance to Hit: " + chanceToHit.ToString() + "%";
        }
        private float CalculateAverageDPA() //Calculates average DPA (Damage Per Attack)
        {
            chanceToHit = 0;
            avgDPA = 0;
            //Console.WriteLine("AC: " + ac);
            switch (advantageType) // Determines which calculation is needed. 
            {
                case AdvantageType.normal:
                    return NormalAvgCalc();
                case AdvantageType.advantage:
                    return AdvantageAvgCalc(true);
                case AdvantageType.disadvantage:
                    return AdvantageAvgCalc(false);
                default:
                    Console.WriteLine("Error, no advantage type selected"); //This code in theory should be unreachable. 
                    return 0;
            }
        }

        private float NormalAvgCalc() //With neither advantage, nor disadvantage, the calculation is rather simple. 
        {
            for (int i = 2; i < 20; i++)//Skips a crit fail which always misses and crit is calculated outside of the loop. 
            {
                if (ChanceToHitCalculator(i))
                {
                    chanceToHit++;
                    //Console.WriteLine(chanceToHit.ToString());
                    avgDPA += NormalDamage(sharpshooter.Checked);
                }
            }
            chanceToHit++;
            Console.WriteLine("Before: " + avgDPA.ToString());
            avgDPA += CritDamage(sharpshooter.Checked); //Factoring for the one crit in the event of a 20
            Console.WriteLine("After: " + avgDPA.ToString());
            avgDPA = avgDPA / 20;

            chanceToHit = ((chanceToHit )* 5);

            return avgDPA;
        }
        private float AdvantageAvgCalc(bool advantage) //True is with advantage, false is with disadvantage. 
        {
            if (advantage) //I have the if statement outside the loop to minimize the number of bool operations. 
            {
                AdvantageRoll(ref avgDPA, ref chanceToHit, true);
            }
            else
            {
                AdvantageRoll(ref avgDPA, ref chanceToHit, false);
            }
            chanceToHit = chanceToHit * 0.25f; //calculates the percent chance to hit

            avgDPA /= 400; //400 possible outcomes, therefore, 

            return avgDPA;
        }

        private void AdvantageRoll(ref float dpa, ref float chanceInt, bool advantage)
        {
            for (int roll1 = 1; roll1 <= 20; roll1++) // runs 1 die
            {
                for (int roll2 = 1; roll2 <= 20; roll2++) //runs the second die with advantage
                {
                    CalculationType(roll1, roll2, advantage, ref dpa, ref chanceInt);
                }
                
            }
        }

        private void CalculationType(int roll1, int roll2, bool advantage, ref float dpa, ref float chanceInt)
        {
            if (advantage)
            {
                if (!(roll1 == 1) || !(roll2 == 1)) //ensures neither die crit fail on disadvantage
                {
                    if (roll1 == 20 && roll2 == 20)
                    {
                        dpa += CritDamage(sharpshooter.Checked);
                        chanceInt++;
                    }
                    else if (ChanceToHitCalculator(roll1) && ChanceToHitCalculator(roll2))
                    {
                        dpa += NormalDamage(sharpshooter.Checked);
                        chanceInt++;
                    }
                }

            }
            else
            {
                if (roll1 == 20 || roll2 == 20)
                {
                    dpa += CritDamage(sharpshooter.Checked);
                    chanceInt++;
                }
                else if (ChanceToHitCalculator(roll1) || ChanceToHitCalculator(roll2))
                {
                    dpa += NormalDamage(sharpshooter.Checked);
                    chanceInt++;

                }
            }
        }

        public float CritDamage(bool sharpshooting)//Returns an average attack with a typical non-crit roll.
        {
            float result = attackDamage + (attackDieAverage * 2);
            if (sharpshooting)
            {
                result += 10;
            }
            
            return result;
        }
        public float NormalDamage(bool sharpshooting)//Returns an average attack with a typical non-crit roll.
        {
            float result = attackDamage + attackDieAverage;
            if (sharpshooting)
            {
                result += 10;
            }

            return result;
        }

        private void checkText(ref TextBox textBox, ref int number) //Recieves a number from the text box.
        {

            try //Attempts to parse an int into the variable.
            {
                //Console.WriteLine("Before, the value of " + textBox.Name + " is set to " + number);
                number = Int32.Parse(textBox.Text);
                //.WriteLine("After, the value of " + textBox.Name + " is set to " + number);
            }
            catch //in the event it fails, makes sure the text box isn't empty, then turns it to the last variable that was valid
            {
                //Console.WriteLine("Parse Failed!");
                if (textBox.Text != "")
                {
                    textBox.Text = number.ToString();
                    //Console.WriteLine(textBox.ToString() + " is set to " + number);
                }
                else
                {
                    number = 0; // if the box is left empty, defaults to 0.
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)  // a link to my website if you click my name. 
        {
            System.Diagnostics.Process.Start("https://www.matteogenoese-zerbi.com/"); //Thank you for viewing my project!
        }

        private void disadvantage_CheckedChanged(object sender, EventArgs e)
        {
            if (disadvantage.Checked)
            {
                advantage.Checked = false;
                advantage.CheckState = CheckState.Unchecked;
                advantageType = AdvantageType.disadvantage;
            }
            else
            {
                advantageType = AdvantageType.normal;
            }
        }//Checks if you've clicked on the disadvantage
        private void advantage_CheckedChanged(object sender, EventArgs e)
        {
            if (advantage.Checked)
            {
                disadvantage.Checked = false;
                disadvantage.CheckState = CheckState.Unchecked;
                advantageType = AdvantageType.advantage;
            }
            else
            {
                advantageType = AdvantageType.normal;
            }
        }//Checks if you've clicked on the advantage
    }
}
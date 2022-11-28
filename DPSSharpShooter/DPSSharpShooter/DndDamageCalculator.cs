using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;

public enum AdvantageType
{
    normal,
    advantage,
    disadvantage
}

namespace DPSSharpShooter
{
    public partial class DndDamageCalculator : Form
    {
        private AdvantageType advantageType = AdvantageType.normal;
        private int ac = 15; 
        private int attack = 7; 
        private int attackDamage = 5;
        private int dieSides = 6;                                                           
        private float avgDPS; 
        private float attackDieAverage = 0;
        private int maxHit;
        private float chanceToHit = 0;
        
        public DndDamageCalculator() 
        { 
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            attackText.Text = attack.ToString();
            acText.Text = ac.ToString();
            attackModifierText.Text = attackDamage.ToString();
            attackDieText.Text = dieSides.ToString();
            DieSideCalculation();
        }
        private void DieSideCalculation() 
        {
            try
            {
                dieSides = Int32.Parse(attackDieText.Text);
            }
            catch
            {
                Console.WriteLine("Parse Failed");
                dieSides = 0;
            }
            
            attackDieAverage = 0;
            for (int i = dieSides; i > 0; i--) 
            { 
                attackDieAverage += i;
            } 
            attackDieAverage = attackDieAverage/(float)dieSides;
            //Console.WriteLine(dieSides.ToString());
            //Console.WriteLine(attackDieAverage.ToString());
        }

        private bool ChanceToHitCalculator(int roll)
        {
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
                maxHit = attackDamage + (dieSides * 2);
            }
            else
            {
                maxHit = attackDamage + dieSides;
            }
            
            if (sharpshooter.Checked)
            {
                maxHit += 10;
            }
            CalculateEffectiveness(ref maxHit);

            return maxHit;
        }

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
        }
        private void CalculateResults() 
        {
            DieSideCalculation();
            DisplayResults();
        }

        private void DisplayResults()
        {
            maxHitNormalText.Text = "Max Hit Normal: " + MaxHitCalculator(false);
            maxHitCritText.Text = "Max hit with Crit: " + MaxHitCalculator(true);
            avgDamageText.Text = "Average Damage Per Attack: " + CalculateAverageDPS();
            chanceToHitText.Text = "Chance to Hit: " + chanceToHit.ToString() + "%";
        }
        private float CalculateAverageDPS()
        {
            chanceToHit = 0;
            avgDPS = 0;
            //Console.WriteLine("AC: " + ac);
            switch (advantageType)
            {
                case AdvantageType.normal:
                    return NormalAvgCalc();
                case AdvantageType.advantage:
                    return AdvantageAvgCalc(true);
                case AdvantageType.disadvantage:
                    return AdvantageAvgCalc(false);
                default:
                    Console.WriteLine("Error, no advantage type selected");
                    return 0;
            }
        }

        private float NormalAvgCalc()
        {
            for (int i = 2; i < 20; i++)
            {
                if (ChanceToHitCalculator(i))
                {
                    chanceToHit++;
                    if (!sharpshooter.Checked)
                    {
                        avgDPS += attackDamage + attackDieAverage;
                    }
                    else
                    {
                        avgDPS += attackDamage + attackDieAverage + 10;
                    }
                }
            }
            avgDPS += attackDamage + (attackDieAverage * 2);
            avgDPS = avgDPS / 20;

            chanceToHit = ((chanceToHit )* 5);

            Console.WriteLine("Before Value: " + avgDPS);
            CalculateEffectiveness(ref avgDPS);
            Console.WriteLine("Before Value: " + avgDPS);

            return avgDPS;
        }
        private float AdvantageAvgCalc(bool advantage)
        {
            if (advantage)
            {
                for(int roll1 = 1; roll1 <= 20; roll1++)
                {
                    for (int roll2 = 1; roll2 <= 20; roll2++)
                    {
                        
                        if (roll1 == 1 && roll2 == 1)
                        {
                            
                        }
                        else if(roll1 == 20 || roll2 == 20)
                        {
                            avgDPS += CritDamage(sharpshooter.Checked);
                            chanceToHit++;
                        }
                        else if (ChanceToHitCalculator(roll1) || ChanceToHitCalculator(roll2))
                        {
                            avgDPS += NormalDamage(sharpshooter.Checked);
                            chanceToHit++;

                        }
                        
                    }
                }
            }
            else
            {
                for (int roll1 = 1; roll1 <= 20; roll1++)
                {
                    for (int roll2 = 1; roll2 <= 20; roll2++)
                    {
                        if (!(roll1 == 1 )|| !(roll2 == 1))
                        {
                            if (roll1 == 20 && roll2 == 20)
                            {
                                avgDPS += CritDamage(sharpshooter.Checked);
                                chanceToHit++;
                            }
                            else if (ChanceToHitCalculator(roll1) && ChanceToHitCalculator(roll2))
                            {
                                avgDPS += NormalDamage(sharpshooter.Checked);
                                chanceToHit++;
                            }
                        }

                    }
                }
            }
            chanceToHit = chanceToHit * 0.25f;

            avgDPS /= 400;

            return avgDPS;
        }

        public float CritDamage(bool sharpshooting)
        {
            float result = attackDamage + (attackDieAverage * 2);
            if (sharpshooting)
            {
                result += 10;
            }

            Console.WriteLine("Before Value: " + result);
            CalculateEffectiveness(ref result);
            Console.WriteLine("After Value: " + result);

            return result;
        }
        public float NormalDamage(bool sharpshooting)
        {
            float result = attackDamage + attackDieAverage;
            if (sharpshooting)
            {
                result += 10;
            }

            Console.WriteLine("Before Value: " + result);
            CalculateEffectiveness(ref result);
            Console.WriteLine("After Value: " + result);


            return result;
        }

        private void CalculateEffectiveness(ref float damage)
        {
            if (effective.Checked)
            {
                damage += damage; //In theory, += is more performant than *=2, so I'm using that. 
            }
            if (resistance.Checked)
            {
                damage = damage / 2;
            }
        }
        private void CalculateEffectiveness(ref int damage)
        {
            if (effective.Checked)
            {
                damage += damage; //In theory, += is more performant than *=2, so I'm using that. 
            }
            if (resistance.Checked)
            {
                damage = damage / 2;
            }
        }
        private void checkText(ref TextBox textBox, ref int number)
        {

            try
            {
                //Console.WriteLine("Before, the value of " + textBox.Name + " is set to " + number);
                number = Int32.Parse(textBox.Text);
                //Console.WriteLine("After, the value of " + textBox.Name + " is set to " + number);
            }
            catch
            {
                //Console.WriteLine("Parse Failed!");
                if (textBox.Text != "")
                {
                    textBox.Text = number.ToString();
                    //Console.WriteLine(textBox.ToString() + " is set to " + number);
                }
                else
                {
                    number = 0;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.matteogenoese-zerbi.com/");
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
        }
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
        }

        private void effective_CheckedChanged(object sender, EventArgs e)
        {
            if (effective.Checked)
            {
                resistance.Checked = false;
                resistance.CheckState = CheckState.Unchecked;
            }
        }

        private void resistance_CheckedChanged(object sender, EventArgs e)
        {
            if (resistance.Checked)
            {
                effective.Checked = false;
                effective.CheckState = CheckState.Unchecked;
            }
        }
    }
}
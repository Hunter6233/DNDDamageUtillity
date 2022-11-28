namespace DPSSharpShooter
{
    partial class DndDamageCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.attackText = new System.Windows.Forms.TextBox();
            this.attackLabel = new System.Windows.Forms.Label();
            this.acLabel = new System.Windows.Forms.Label();
            this.acText = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.attackModifierText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.attackDieText = new System.Windows.Forms.TextBox();
            this.sharpshooter = new System.Windows.Forms.CheckBox();
            this.avgDamageText = new System.Windows.Forms.Label();
            this.chanceToHitText = new System.Windows.Forms.Label();
            this.maxHitNormalText = new System.Windows.Forms.Label();
            this.maxHitCritText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.advantage = new System.Windows.Forms.CheckBox();
            this.disadvantage = new System.Windows.Forms.CheckBox();
            this.resistance = new System.Windows.Forms.CheckBox();
            this.effective = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // attackText
            // 
            this.attackText.Location = new System.Drawing.Point(48, 48);
            this.attackText.Name = "attackText";
            this.attackText.Size = new System.Drawing.Size(100, 20);
            this.attackText.TabIndex = 0;
            this.attackText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.Location = new System.Drawing.Point(64, 32);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(71, 13);
            this.attackLabel.TabIndex = 1;
            this.attackLabel.Text = "Attack Bonus";
            // 
            // acLabel
            // 
            this.acLabel.AutoSize = true;
            this.acLabel.Location = new System.Drawing.Point(64, 93);
            this.acLabel.Name = "acLabel";
            this.acLabel.Size = new System.Drawing.Size(62, 13);
            this.acLabel.TabIndex = 3;
            this.acLabel.Text = "Armor Class";
            // 
            // acText
            // 
            this.acText.Location = new System.Drawing.Point(48, 109);
            this.acText.Name = "acText";
            this.acText.Size = new System.Drawing.Size(100, 20);
            this.acText.TabIndex = 2;
            this.acText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // calculateButton
            // 
            this.calculateButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.calculateButton.Location = new System.Drawing.Point(107, 297);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(115, 40);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // results
            // 
            this.results.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.results.AutoSize = true;
            this.results.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results.Location = new System.Drawing.Point(383, 60);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(121, 31);
            this.results.TabIndex = 5;
            this.results.Text = "Results: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Attack Damage";
            // 
            // attackModifierText
            // 
            this.attackModifierText.Location = new System.Drawing.Point(228, 48);
            this.attackModifierText.Name = "attackModifierText";
            this.attackModifierText.Size = new System.Drawing.Size(100, 20);
            this.attackModifierText.TabIndex = 6;
            this.attackModifierText.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Attack Die (Sides)";
            // 
            // attackDieText
            // 
            this.attackDieText.Location = new System.Drawing.Point(228, 109);
            this.attackDieText.Name = "attackDieText";
            this.attackDieText.Size = new System.Drawing.Size(100, 20);
            this.attackDieText.TabIndex = 8;
            this.attackDieText.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // sharpshooter
            // 
            this.sharpshooter.AutoSize = true;
            this.sharpshooter.Location = new System.Drawing.Point(40, 156);
            this.sharpshooter.Name = "sharpshooter";
            this.sharpshooter.Size = new System.Drawing.Size(203, 17);
            this.sharpshooter.TabIndex = 10;
            this.sharpshooter.Text = "Sharpshooter/Great Weapon Bonus?";
            this.sharpshooter.UseVisualStyleBackColor = true;
            // 
            // avgDamageText
            // 
            this.avgDamageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.avgDamageText.AutoSize = true;
            this.avgDamageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgDamageText.Location = new System.Drawing.Point(510, 66);
            this.avgDamageText.Name = "avgDamageText";
            this.avgDamageText.Size = new System.Drawing.Size(289, 25);
            this.avgDamageText.TabIndex = 11;
            this.avgDamageText.Text = "Average Damage Per Attack:";
            // 
            // chanceToHitText
            // 
            this.chanceToHitText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chanceToHitText.AutoSize = true;
            this.chanceToHitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chanceToHitText.Location = new System.Drawing.Point(510, 216);
            this.chanceToHitText.Name = "chanceToHitText";
            this.chanceToHitText.Size = new System.Drawing.Size(155, 25);
            this.chanceToHitText.TabIndex = 12;
            this.chanceToHitText.Text = "Chance To Hit:";
            this.chanceToHitText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // maxHitNormalText
            // 
            this.maxHitNormalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxHitNormalText.AutoSize = true;
            this.maxHitNormalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHitNormalText.Location = new System.Drawing.Point(510, 168);
            this.maxHitNormalText.Name = "maxHitNormalText";
            this.maxHitNormalText.Size = new System.Drawing.Size(165, 25);
            this.maxHitNormalText.TabIndex = 13;
            this.maxHitNormalText.Text = "Max Hit Normal:";
            // 
            // maxHitCritText
            // 
            this.maxHitCritText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxHitCritText.AutoSize = true;
            this.maxHitCritText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHitCritText.Location = new System.Drawing.Point(510, 115);
            this.maxHitCritText.Name = "maxHitCritText";
            this.maxHitCritText.Size = new System.Drawing.Size(179, 25);
            this.maxHitCritText.TabIndex = 14;
            this.maxHitCritText.Text = "Max Hit With Crit:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(760, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Program by Matteo Genoese-Zerbi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // advantage
            // 
            this.advantage.AutoSize = true;
            this.advantage.Location = new System.Drawing.Point(40, 204);
            this.advantage.Name = "advantage";
            this.advantage.Size = new System.Drawing.Size(84, 17);
            this.advantage.TabIndex = 16;
            this.advantage.Text = "Advantage?";
            this.advantage.UseVisualStyleBackColor = true;
            this.advantage.CheckedChanged += new System.EventHandler(this.advantage_CheckedChanged);
            // 
            // disadvantage
            // 
            this.disadvantage.AutoSize = true;
            this.disadvantage.Location = new System.Drawing.Point(266, 204);
            this.disadvantage.Name = "disadvantage";
            this.disadvantage.Size = new System.Drawing.Size(98, 17);
            this.disadvantage.TabIndex = 17;
            this.disadvantage.Text = "Disadvantage?";
            this.disadvantage.UseVisualStyleBackColor = true;
            this.disadvantage.CheckedChanged += new System.EventHandler(this.disadvantage_CheckedChanged);
            // 
            // resistance
            // 
            this.resistance.AutoSize = true;
            this.resistance.Location = new System.Drawing.Point(210, 256);
            this.resistance.Name = "resistance";
            this.resistance.Size = new System.Drawing.Size(85, 17);
            this.resistance.TabIndex = 19;
            this.resistance.Text = "Resistance?";
            this.resistance.UseVisualStyleBackColor = true;
            this.resistance.CheckedChanged += new System.EventHandler(this.resistance_CheckedChanged);
            // 
            // effective
            // 
            this.effective.AutoSize = true;
            this.effective.Location = new System.Drawing.Point(48, 256);
            this.effective.Name = "effective";
            this.effective.Size = new System.Drawing.Size(74, 17);
            this.effective.TabIndex = 18;
            this.effective.Text = "Effective?";
            this.effective.UseVisualStyleBackColor = true;
            this.effective.CheckedChanged += new System.EventHandler(this.effective_CheckedChanged);
            // 
            // DndDamageCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 349);
            this.Controls.Add(this.resistance);
            this.Controls.Add(this.effective);
            this.Controls.Add(this.disadvantage);
            this.Controls.Add(this.advantage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxHitCritText);
            this.Controls.Add(this.maxHitNormalText);
            this.Controls.Add(this.chanceToHitText);
            this.Controls.Add(this.avgDamageText);
            this.Controls.Add(this.sharpshooter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.attackDieText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attackModifierText);
            this.Controls.Add(this.results);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.acLabel);
            this.Controls.Add(this.acText);
            this.Controls.Add(this.attackLabel);
            this.Controls.Add(this.attackText);
            this.Name = "DndDamageCalculator";
            this.Text = "D&D Damage Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox attackText;
        private System.Windows.Forms.Label attackLabel;
        private System.Windows.Forms.Label acLabel;
        private System.Windows.Forms.TextBox acText;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label results;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox attackModifierText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox attackDieText;
        private System.Windows.Forms.CheckBox sharpshooter;
        private System.Windows.Forms.Label avgDamageText;
        private System.Windows.Forms.Label chanceToHitText;
        private System.Windows.Forms.Label maxHitNormalText;
        private System.Windows.Forms.Label maxHitCritText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox advantage;
        private System.Windows.Forms.CheckBox disadvantage;
        private System.Windows.Forms.CheckBox resistance;
        private System.Windows.Forms.CheckBox effective;
    }
}


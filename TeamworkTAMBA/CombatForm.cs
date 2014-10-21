﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamworkTAMBA
{
    using TeamworkTAMBA.Enums;

    public partial class CombatForm : Form
    {
        private Enemy enemy;
        private Player player;
        private bool isEnemyAlive = true;
        private bool isPlayerAlive = true;
        private int knowlageUsage = 0;
        private DrawEngine drowEngine;
        private DeadForm deadForm;

        public CombatForm(Player player, Enemy enemy, DrawEngine drowEngine)
        {
            InitializeComponent();
            this.enemy = enemy;
            this.enemy.AttackPower = 50;
            this.player = player;
            this.player.AttackPower = 10;
            this.drowEngine = drowEngine;
            this.pictureBox2.Image = drowEngine.GetImage(enemy as GameObject);

            //This removex the "x" button to avoid close the battle. It is in comment to easy the tests
            //this.ControlBox = false;

            enemyHealthProgressBar.Maximum = 100;
            playerHealthProgressBar.Maximum = 100;
            playerHealthProgressBar.Value = player.Health;
            playerKnowledgeProgressbar.Value = player.Knowledge;

            labelPlayersTime.Text = "Time: " + player.Health;
            labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            labelPlayerKnowlage.Text = "Knowlage: " + player.Knowledge;
            labelEnemyHealth.Text = "Health: " + enemy.Health;
            labelEnemyDmg.Text = "Damage: " + "1-" + enemy.AttackPower;

            //Disables the weapon checkboxes if still not taken from the teacher
            foreach (var weapon in this.player.Weapons)
            {
                if (weapon.Power == 0)
                {
                    switch (weapon.WeaponType)
                    {
                        case WeaponTypes.Java:
                            javaCheckBox.Enabled = false;
                            break;
                        case WeaponTypes.HTML:
                            htmlCheckBox.Enabled = false;
                            break;
                        case WeaponTypes.CSS:
                            cssCheckBox.Enabled = false;
                            break;
                        case WeaponTypes.JavaScript:
                            javascriptCheckBox.Enabled = false;
                            break;
                        case WeaponTypes.PHP:
                            phpCheckBox.Enabled = false;
                            break;
                    }
                }
            }
        }

        //The weapones check boxes
        private void CSharpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CSharpCheckBox.Checked)
            {
            }
            else
            {
                playerTextBox.Text = "You can not fight the Homeworks without programing skills!";
                CSharpCheckBox.Checked = true;
            }
        }

        private void javaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (javaCheckBox.Checked)
            {
                player.AttackPower += 10;
                knowlageUsage += 10;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
            else
            {
                player.AttackPower -= 10;
                knowlageUsage -= 10;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
        }

        private void htmlCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (htmlCheckBox.Checked)
            {
                player.AttackPower += 10;
                knowlageUsage += 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
            else
            {
                player.AttackPower -= 10;
                knowlageUsage -= 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
        }

        private void cssCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cssCheckBox.Checked)
            {
                player.AttackPower += 10;
                knowlageUsage += 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
            else
            {
                player.AttackPower -= 10;
                knowlageUsage -= 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
        }

        private void javascriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (javascriptCheckBox.Checked)
            {
                player.AttackPower += 10;
                knowlageUsage += 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
            else
            {
                player.AttackPower -= 10;
                knowlageUsage -= 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
        }

        private void phpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (phpCheckBox.Checked)
            {
                player.AttackPower += 10;
                knowlageUsage += 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
            else
            {
                player.AttackPower -= 10;
                knowlageUsage -= 1;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
        }

        private void checkAllBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllBox.Checked)
            {
                if (javaCheckBox.Enabled)
                {
                    javaCheckBox.Checked = true;
                }
                if (htmlCheckBox.Enabled)
                {
                    htmlCheckBox.Checked = true;
                }
                if (cssCheckBox.Enabled)
                {
                    cssCheckBox.Checked = true;
                }
                if (javascriptCheckBox.Enabled)
                {
                    javascriptCheckBox.Checked = true;
                }
                if (phpCheckBox.Enabled)
                {
                    phpCheckBox.Checked = true;
                }

                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
            else
            {
                javaCheckBox.Checked = false;
                htmlCheckBox.Checked = false;
                cssCheckBox.Checked = false;
                javascriptCheckBox.Checked = false;
                phpCheckBox.Checked = false;
                labelPlayerDmg.Text = "Damage: " + "1-" + player.AttackPower;
            }
        }

        //The text box. This is useless
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //The "Do it button"
        private void buttonDoIt_Click(object sender, EventArgs e)
        {
            if (isPlayerAlive && isEnemyAlive)
            {
                Combat();
                labelPlayersTime.Text = "Time: " + player.Health;
                labelEnemyHealth.Text = "Health: " + enemy.Health;
                labelPlayerKnowlage.Text = "Knowlage: " + player.Knowledge;
            }
        }

        private void Combat()
        {
            player.Knowledge -= knowlageUsage;
            playerKnowledgeProgressbar.Value = player.Knowledge;
            int playerRandomDamage = RandomDamageGenerator(player.AttackPower);
            int newEnemyHealth = enemy.Health -= playerRandomDamage;
            int enemyRandomDamage = RandomDamageGenerator(enemy.AttackPower);
            int newPlayerHealth = player.Health -= enemyRandomDamage;

            if (player.Knowledge < 1)
            {
                player.Knowledge = 0;
                playerKnowledgeProgressbar.Value = playerKnowledgeProgressbar.Minimum;

                javaCheckBox.Checked = false;
                htmlCheckBox.Checked = false;
                cssCheckBox.Checked = false;
                javascriptCheckBox.Checked = false;
                phpCheckBox.Checked = false;

                javaCheckBox.Enabled = false;
                htmlCheckBox.Enabled = false;
                cssCheckBox.Enabled = false;
                javascriptCheckBox.Enabled = false;
                phpCheckBox.Enabled = false;
            }

            if (enemy.Health > 0)
            {
                enemyHealthProgressBar.Value = newEnemyHealth;
                playerTextBox.Text = "You have hit the Homework for " + playerRandomDamage + "\nThe Homework now have " + enemy.Health + " health.";
            }
            else
            {
                enemyHealthProgressBar.Value = enemyHealthProgressBar.Minimum;
                isEnemyAlive = false;
                playerTextBox.Text = "You have hit the Homework for " + playerRandomDamage + "\nThe Homework is dead!";
                player.Health = newPlayerHealth;

                exit.Visible = true;
            }

            if (player.Health > 0)
            {
                playerHealthProgressBar.Value = newPlayerHealth;
                EnemyTextBox.Text = "But the Homework hit you back for " + enemyRandomDamage +
                    "\nYou have now " + player.Health + " health";
            }
            else
            {
                playerHealthProgressBar.Value = playerHealthProgressBar.Minimum;
                isPlayerAlive = false;
                EnemyTextBox.Text = "The Homework hit you back for " + enemyRandomDamage +
                                    "\nYou were killed form a Homework.. You sux!";
                exit.Visible = true;
            }
        }

        private int RandomDamageGenerator(int damage)
        {
            Random randomDanage = new Random();
            int currentDamage = randomDanage.Next(1, damage);

            return currentDamage;
        }

        public int GetPlayerHelth()
        {
            return this.player.Health;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            die();
            this.Close();
        }

        private void die()
        {
            if (!isPlayerAlive)
            {
                deadForm = new DeadForm();
                deadForm.Visible = Enabled;
            }
        }
    }
}

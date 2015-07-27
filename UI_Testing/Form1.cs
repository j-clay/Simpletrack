using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Testing
{
    public partial class Form1 : Form
    {
        public struct Meal
        {

            public double proteinCount, carbCount, fatCount, calCount;
        };

        Meal tempMeal;
        List<Meal> mealContainer = new List<Meal>();
        
        public double totalCalories = 0;
        public double totalProtein  = 0;
        public double totalCarbs    = 0;
        public double totalFat      = 0;
        public double proteinCount  = 0;
        public double carbCount     = 0;
        public double fatCount      = 0;
        public double calCount      = 0;
        public double oz            = 0;

        public int indexTracker = -1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 0) //steak
            {
                label5.Hide();
                textBox1.Clear();
                textBox1.Show();
                label4.Show();
            }

           
            else if (comboBox1.SelectedIndex == 1) //chicken
            {
                label5.Hide();
                textBox1.Clear();
                textBox1.Show();
                label4.Show();
            }
            else if (comboBox1.SelectedIndex == 2) //protein shake
            {
                label4.Hide();
                textBox1.Clear();
                textBox1.Show();
                label5.Show();
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }


        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

           

            if (!tabControl1.Visible)
            {
                tabControl1.Show();
                richTextBox1.Show();
                button3.Show();
                tabControl1.TabPages[0].Text = "Meal 1";
            }
            else
            {
                if (indexTracker != -1)
                {
                    Console.WriteLine("here1");
                    string title = "Meal" + indexTracker.ToString();
                    TabPage myTab = new TabPage(title);
                    myTab.BackColor = SystemColors.Control; 
                    tabControl1.TabPages.Add(myTab);
                    tabControl1.SelectedIndex = indexTracker - 1;
                    indexTracker = -1;
                }
                else
                {
                    Console.WriteLine("here2");
                    string title = "Meal" + (tabControl1.TabCount + 1).ToString();
                    TabPage myTab = new TabPage(title);
                    myTab.BackColor = SystemColors.Control; 
                    tabControl1.TabPages.Add(myTab);
                    tabControl1.SelectedIndex = tabControl1.TabCount - 1;
                }
                
            }


            // calculate calories/macros

            // steak
            if (comboBox1.SelectedIndex == 0)
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    oz = Double.Parse(textBox1.Text);

                    tempMeal.proteinCount = 7 * oz; // 7 grams of protein per oz
                    tempMeal.calCount = 55 * oz;
                }

            }

            
            // chicken
            else if (comboBox1.SelectedIndex == 1)
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    oz = Double.Parse(textBox1.Text);

                    tempMeal.proteinCount = 5.32 * oz; // 5.32 grams of protein per oz
                    tempMeal.calCount = 35 * oz;
                }


            }
            // protein shake
            else if (comboBox1.SelectedIndex == 2)
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    oz = Double.Parse(textBox1.Text);

                    tempMeal.proteinCount = 25 * oz; // 25 grams of protein per serving
                    tempMeal.calCount = 110 * oz;
                }


            }


            // yams
            if (comboBox2.SelectedIndex == 0)
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {

                    oz = Double.Parse(textBox2.Text);
                    tempMeal.carbCount = 8 * oz; // 8 grams of carbs per oz

                    tempMeal.calCount = tempMeal.calCount + (33 * oz);

                }
            }
            // oatmeal
            else if (comboBox2.SelectedIndex == 1)
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {

                    oz = Double.Parse(textBox2.Text);
                    tempMeal.carbCount = 27 * oz; // 27 grams of carbs per serving

                    tempMeal.calCount = tempMeal.calCount + (150 * oz);

                }
            }
            // yogurt
            else if (comboBox2.SelectedIndex == 2)
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {

                    oz = Double.Parse(textBox2.Text);
                    tempMeal.carbCount = 9 * oz; // 27 grams of carbs per serving
                    tempMeal.proteinCount = tempMeal.proteinCount + (22 * oz);
                    tempMeal.calCount = tempMeal.calCount + (120 * oz);

                }
            }

            // peanut butter
            if (comboBox3.SelectedIndex == 0)
            {
                if (!String.IsNullOrEmpty(textBox3.Text))
                {

                    oz = Double.Parse(textBox2.Text);
                    tempMeal.carbCount = 4 * oz; // 4 grams of carbs per half serving
                    tempMeal.proteinCount = tempMeal.proteinCount + (3.5 * oz);
                    tempMeal.fatCount = tempMeal.fatCount + (8 * oz);
                    tempMeal.calCount = tempMeal.calCount + (97.5 * oz);

                }
            }

           

            // Add text to each meal analysis tab
            RichTextBox tmpLog = new RichTextBox();
            tmpLog.Text = "  Calories: " + tempMeal.calCount
                        + "\n  Protein: " + tempMeal.proteinCount
                        + "\n  Carbohydrates: " + tempMeal.carbCount
                        + "\n  Fats: " + tempMeal.fatCount;
            tmpLog.BackColor = SystemColors.Control;
            tmpLog.BorderStyle = BorderStyle.None;
            tabControl1.SelectedTab.Controls.Add(tmpLog);


            // Add meal to list of meals
            Console.WriteLine("Adding meal to index:" + tabControl1.SelectedIndex);
            mealContainer.Insert(tabControl1.SelectedIndex, tempMeal);

            totalCalories += tempMeal.calCount;
            totalProtein += tempMeal.proteinCount;
            totalCarbs += tempMeal.carbCount;
            totalFat += tempMeal.fatCount;

            update_analysis();
            clearInput();

            

                


        }

        private void update_analysis()
        {
            richTextBox1.Text = "Total Calories: " + totalCalories
                            + "\nTotal Protein: " + totalProtein
                            + "\nTotal Carbs:   " + totalCarbs
                            + "\nTotal Fats:    " + totalFat;
            groupBox1.Controls.Add(richTextBox1);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedIndex == 0) //yams
            {
                label12.Hide();

                textBox2.Clear();
                textBox2.Show();
                label6.Show();
            }


            else if (comboBox2.SelectedIndex == 1) //oatmeal
            {
                label6.Hide();

                textBox2.Clear();
                textBox2.Show();
                label12.Show();
            }
            else if (comboBox2.SelectedIndex == 2) //yogurt
            {

                label6.Hide();

                textBox2.Clear();
                textBox2.Show();
                label12.Show();
            }
            else if (comboBox2.SelectedIndex == 3) //rice
            {
                label6.Hide();

                textBox2.Clear();
                textBox2.Show();
                label12.Show();
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                textBox3.Show();
                label8.Show();
            }
        }

        private void button2_MouseClick(object sender, EventArgs e)
        {
            clearInput();
        }

        private void clearInput()
        {
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            label4.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label12.Hide();

            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            tempMeal.proteinCount  = 0;
            tempMeal.carbCount = 0;
            tempMeal.fatCount = 0;
            tempMeal.calCount = 0;
            oz = 0;
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void subtractNutrition()
        {

            Meal temp = mealContainer[tabControl1.SelectedIndex];
            Console.WriteLine("index: " + tabControl1.SelectedIndex + "cal count: " + temp.calCount);
            totalCalories -= temp.calCount;
            totalProtein -= temp.proteinCount;
            totalCarbs -= temp.carbCount;
            totalFat -= temp.fatCount;
        }

        private void button3_MouseClick(object sender, EventArgs e)
        {

         

            if (tabControl1.TabCount == 1)
            {
                
                
                tabPage1.Controls.Clear();
                tabControl1.Hide();
                richTextBox1.Hide();
                button3.Hide();
                

                subtractNutrition();
                mealContainer.Clear();
                update_analysis();
                clearInput();
                

                tabControl1.SelectedTab.Controls.Clear();
                

                
            }
            else
            {
                subtractNutrition();
                
                mealContainer.RemoveAt(tabControl1.SelectedIndex);

                if (tabControl1.SelectedIndex != tabControl1.TabCount - 1)
                {
                    indexTracker = tabControl1.SelectedIndex + 1;
                    Console.WriteLine("here");
                }
                    

                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                tabControl1.SelectedIndex = tabControl1.TabCount - 1;
                
                
                update_analysis();
                clearInput();

                
            }
                
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
           
            
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.Visible)
            {
                comboBox1.Hide();
                textBox1.Hide();
                

                textBox1.Clear();
                

                label4.Hide();
                label5.Hide();
              

                comboBox1.ResetText();
                
            }
            else
                comboBox1.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox2.Visible)
            {
                comboBox2.Hide();

                
                textBox2.Hide();
                

               
                textBox2.Clear();
               

                label6.Hide();
                label12.Hide();

               
                comboBox2.ResetText();
               
            }
            else
                comboBox2.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox3.Visible)
            {
                comboBox3.Hide();
                textBox3.Hide();

                textBox3.Clear();

                label8.Hide();

                comboBox3.ResetText();
                
            }
            else
                comboBox3.Show();
        }

       
    }
}

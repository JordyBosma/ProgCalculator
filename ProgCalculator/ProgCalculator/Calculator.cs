using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProgCalculator
{
    class Calculator
    {
        // De stack instances
        private Stacks.MyListSt<double> myListSt;
        private Stacks.ListSt listSt;
        private Stacks.ArraySt arraySt;
        public TextBox textBox { get; set; }
        public ListBox listBox { get; set; }
        public List<RadioButton> radio { get; set; }
        public List<double?> listBoxVal { get; set; }

        /// <summary>
        /// De constructor van de calc class
        /// </summary>
        public Calculator()
        {
            myListSt = new Stacks.MyListSt<double>();
            listSt = new Stacks.ListSt();
            arraySt = new Stacks.ArraySt();
        }

        /// <summary>
        /// Cleared de listBox en update hem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void resetButton_Clicked(object sender, EventArgs e)
        {
            if (radio[0].Checked)      // MyListSt
                myListSt.Clear();
            else if (radio[1].Checked) // ArraySt
                arraySt.Clear();
            else                        // ListSt
                listSt.Clear();

            listBoxVal = null;
            textBox.Focus();
            UpdateListBox();
        }

        /// <summary>
        /// Voeg item toe aan de list box en update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void confirmButton_Clicked(object sender, EventArgs e)
        {
            UpdateListBox();
            textBox.Focus();
        }

        /// <summary>
        /// Reageert op input op het scherm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void numpad_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text != "(-)")
                InputValidation(Convert.ToChar(btn.Text));
            else
                InputValidation('_');
        }

        /// <summary>
        /// Als er geswitched wordt tussen de radiobuttons dan reset de vorige stack en wordt de nieuwe ingeladen.
        /// De stack wordt 2 keer gecalled, 1 keer voor clear, 2e keer voor vullen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            // Als de listbox data bevat wordt dit opgeslagen in listBoxVal
            if (listBox.Items.Count > 0)
            {
                listBoxVal = listBox.Items.Cast<double?>().ToList();
                listBoxVal.Reverse(); // Reverse de lijst zodat hij meteen kan worden toegevoegd aan de list
            }

            // Doe niks als de listbox leeg is
            if (listBoxVal != null)
            {
                if (rb.Checked)
                {
                    foreach (double? value in listBoxVal)
                    {
                        if (rb.Text == "MyListStack")
                            myListSt.Add(0, value);
                        else if (rb.Text == "ArrayStack")
                            arraySt.Add(0, value);
                        else
                            listSt.Add(0, value);
                    }
                }
                else
                {
                    if (rb.Text == "MyListStack")
                        myListSt.Clear();
                    else if (rb.Text == "ArrayStack")
                        arraySt.Clear();
                    else
                        listSt.Clear();
                }
            }
            UpdateListBox();
        }

        /// <summary>
        /// Controleer of user input geldig is
        /// </summary>
        /// <param name="keyChar">De karakter die moet worden toegevoegd</param>
        public void InputValidation(char keyChar)
        {
            // Controleer of input van toetsenbord of numpad is
            if (keyChar >= 48 && keyChar <= 57)
            {
                // Voeg alleen een 0 toe wanneer een ander getal toegevoegd is
                if (keyChar > 48 || textBox.Text != "")
                    textBox.Text = textBox.Text + keyChar.ToString();
            }

            // Voeg alleen een punt toe wanneer er een nummer is toegevoegd en die niet al een punt bevat
            if (keyChar == '.' && textBox.Text != "" && !textBox.Text.Contains('.'))
                textBox.Text = textBox.Text + keyChar.ToString();

            // Voeg alleen een min operator als textbox niet al één bevat en leeg is
            if (keyChar == '_' && !textBox.Text.Contains('-') && textBox.Text == "")
                textBox.Text = textBox.Text + '-'.ToString();
            // Controleer wanneer een operator is toegevoegd
            char[] allowedhars = new char[4] { '/', '*', '-', '+' };

            if (allowedhars.Contains(keyChar))
                UpdateListBox(keyChar);

            // Controleer of de backspace ingedrukt is
            if (keyChar == 8)
            {
                if (textBox.Text != "")
                {
                    int cnt = textBox.Text.Count();
                    textBox.Text = textBox.Text.Remove(cnt - 1, 1);
                }
            }

            // Controleer of de ENTER toets is ingedrukt
            if (keyChar == (char)Keys.Enter)
                UpdateListBox();
        }

        /// <summary>
        /// Update de listBox en voegt data toe aan de list als de textBox niet NULL is
        /// </summary>
        protected void UpdateListBox(char keyChar = '\0')
        {
            if (radio[0].Checked)               // MyListSt
                LoadInput(myListSt, keyChar);
            else if (radio[1].Checked)          // ArraySt
                LoadInput(arraySt, keyChar);
            else                                // ListSt
                LoadInput(listSt, keyChar);

            textBox.Text = "";
        }

        /// <summary>
        /// Voegt items toe aan de listbox en voert calculaties uit
        /// </summary>
        /// <param name="instance">Definieërt welke class deze method gebruikt</param>
        /// <param name="keyChar">De key van de som bijv. +, -, / of *</param>
        private void LoadInput(dynamic instance, char keyChar = '\0')
        {
            // Controleer of de keyChar '\0' is (is een NULL in unicode)
            if (keyChar != '\0')
            {
                // calculate the equation
                double? calc = instance.Operation(instance.item, keyChar);
                if (calc != null)
                {
                    instance.Delete(0);
                    instance.Add(0, calc);
                }
            }

            // Voeg geen nieuwe nummer toe aan de lijst als de textBox niet leeg is
            if (textBox.Text.Length != 0)
                instance.Add(0, Convert.ToDouble(textBox.Text));
            // Herlaad de listBox
            listBox.DataSource = instance.GetList();
        }
    }
}

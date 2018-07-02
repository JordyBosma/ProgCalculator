using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProgCalculator
{
    public partial class Calc : Form
    {
        protected List<double?> listBoxValues = new List<double?>();

        protected TextBox textBox;
        protected ListBox listBox;
        protected List<RadioButton> radios = new List<RadioButton>();
        private Calculator calculator = new Calculator();
        GenerateCalc genCalc = new GenerateCalc();

        public Calc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the components onto the Calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calc_Load(object sender, EventArgs e)
        {
            LoadTextBox();
            LoadListBox();
            LoadNumpad();
            LoadRadio();
            loadConfirmClearBtns();
        }

        /// <summary>
        /// Load a textbox onto the form
        /// </summary>
        private void LoadTextBox()
        {
            textBox = genCalc.CreateTextBox(50, 50, 300, 16);
            calculator.textBox = textBox;
            Controls.Add(textBox);
        }

        /// <summary>
        /// Load a numpad onto the form
        /// </summary>
        private void LoadNumpad()
        {
            // The buttons for the calculator
            string[,] btnNames = new string[4, 4]
            {
                { "7", "8", "9", "/" },
                { "6", "5", "4", "*" },
                { "3", "2", "1", "-" },
                { "(-)", "0", ".", "+" }
            };
            foreach (Button btn in genCalc.CreateNumpad(btnNames))
            {
                btn.Click += (calculator.numpad_Click);

                // Draw Buttons
                Controls.Add(btn);
            }
        }

        /// <summary>
        /// Load a listbox onto the form
        /// </summary>
        private void LoadListBox()
        {
            // Draw Listbox
            listBox = genCalc.CreateListBox(400, 50, 550, 400);
            calculator.listBox = listBox;
            Controls.Add(listBox);
        }

        /// <summary>
        /// Load some radiobuttons onto the form
        /// </summary>
        private void LoadRadio()
        {
            // Draw radio buttons
            foreach (RadioButton radioButton in genCalc.CreateRadioButtons(400, 460))
            {
                radioButton.CheckedChanged += new EventHandler(calculator.radioButtons_CheckedChanged);
                radios.Add(radioButton);
                Controls.Add(radioButton);
            }
            calculator.radio = radios;
        }

        /// <summary>
        /// Load enter and reset buttons onto the form
        /// </summary>
        private void loadConfirmClearBtns()
        {
            // Draw reset button
            Button resetButton = genCalc.CreateClearBtn(875, 460);
            resetButton.Click += new EventHandler(calculator.resetButton_Clicked);
            Controls.Add(resetButton);

            // Draw reset button
            Button enterButton = genCalc.CreateConfirmBtn(355, 50);
            enterButton.Click += new EventHandler(calculator.confirmButton_Clicked);
            Controls.Add(enterButton);
        }

        /// <summary>
        /// Reacts to the keypresses on your keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPress_Event(object sender, KeyPressEventArgs e)
        {
            calculator.InputValidation(e.KeyChar);
        }
    }
}

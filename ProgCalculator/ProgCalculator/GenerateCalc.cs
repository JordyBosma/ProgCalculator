using System.Collections.Generic;
using System.Windows.Forms;

namespace ProgCalculator
{
    class GenerateCalc
    {
        /// <summary>
        /// Maakt een nieuwe textbox
        /// </summary>
        /// <param name="x">De X-ax van het startpunt</param>
        /// <param name="y">De Y-ax van het startpunt</param>
        /// <param name="width">De breedte van de textbox</param>
        /// <param name="fontSize">De textgrootte van de textbox</param>
        /// <returns>Een nieuwe textbox</returns>
        public TextBox CreateTextBox(int x, int y, int width, int fontSize)
        {
            TextBox textBox = new TextBox(); //Maakt het textBox object
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 0);
            textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", fontSize, System.Drawing.FontStyle.Regular);
            textBox.ReadOnly = true;
            textBox.Focus();
            return textBox;
        }

        /// <summary>
        /// Maakt een numpad voor de calculator
        /// </summary>
        /// <param name="btnNames">Enter een array van buttonnamen</param>
        /// <returns>Returnd een lijst met buttons</returns>
        public List<Button> CreateNumpad(string[,] buttonNms)
        {
            List<Button> buttons = new List<Button>();
            for (int x = 0; x < buttonNms.GetLength(0); x++)
            {
                for (int y = 0; y < buttonNms.GetLength(1); y++)
                {
                    Button newButton = new Button(); //Maakt het button object
                    newButton.Name = buttonNms[x, y];
                    newButton.Text = buttonNms[x, y];
                    newButton.Location = new System.Drawing.Point(50 + 80 * y, 100 + 100 * x);
                    newButton.Size = new System.Drawing.Size(60, 60);
                    newButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Regular);
                    buttons.Add(newButton);
                }
            }
            return buttons;
        }

        /// <summary>
        /// Maakt een listBox
        /// </summary>
        /// <param name="x">De X-ax van het startpunt</param>
        /// <param name="y">De Y-ax van het startpunt</param>
        /// <param name="width">De breedte van de box</param>
        /// <param name="height">De hoogte van de box</param>
        /// <returns>Returnt een listBox</returns>
        public ListBox CreateListBox(int x, int y, int width, int height)
        {
            ListBox listBox = new ListBox(); //Maakt het listBox object
            listBox.Name = "StackList";
            listBox.Location = new System.Drawing.Point(x, y);
            listBox.Width = width;
            listBox.Height = height;
            return listBox;
        }

        /// <summary>
        /// Maak radioButtons
        /// </summary>
        /// <param name="x">De X-ax van het startpunt</param>
        /// <param name="y">De Y-ax van het startpunt</param>
        /// <returns>Returnt een lijst met radio buttons</returns>
        public List<RadioButton> CreateRadioButtons(int x, int y)
        {
            List<RadioButton> radioButtons = new List<RadioButton>();
            string[] text = new string[3] { "MyListStack", "ArrayStack", "ListStack" };
            for (int i = 0; i < text.Length; i++)
            {
                RadioButton radio = new RadioButton();
                radio.Location = new System.Drawing.Point(x, y + i * 30);
                radio.Text = text[i];

                if (i == 0) { radio.Checked = true; }

                radioButtons.Add(radio);
            }
            return radioButtons;
        }

        /// <summary>
        /// Maakt een button om items toe te voegen aan de listBox
        /// </summary>
        /// <param name="x">De X-ax van het startpunt</param>
        /// <param name="y">De Y-ax van het startpunt</param>
        /// <returns>Returnt de bevestig knop</returns>
        public Button CreateConfirmBtn(int x, int y)
        {
            Button confirmButton = new Button();
            confirmButton.Text = ">";
            confirmButton.Name = "Confirm";
            confirmButton.Location = new System.Drawing.Point(x, y);
            confirmButton.Size = new System.Drawing.Size(40, 33);
            return confirmButton;
        }

        /// <summary>
        /// Maakt een button om de listBox te clearen
        /// </summary>
        /// <param name="x">De X-ax van het startpunt</param>
        /// <param name="y">De Y-ax van het startpunt</param>
        /// <returns>Returnt de clear knop</returns>
        public Button CreateClearBtn(int x, int y)
        {
            Button ClearBtn = new Button();
            ClearBtn.Text = "Reset";
            ClearBtn.Name = "Reset";
            ClearBtn.Location = new System.Drawing.Point(x, y);
            return ClearBtn;
        }
    }
}

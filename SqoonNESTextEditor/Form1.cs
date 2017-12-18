using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqoonNESTextEditor
{
    public partial class FormSqoonMain : Form
    {
        public FormSqoonMain()
        {
            InitializeComponent();
        }

        private void buttonOpenROM_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxAbsoluteFilename.Text = ofd.FileName;

                clearTextBoxes();
                readRomText();
            }
        }

        #region ClearTextBoxes
        private void clearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
        }
        #endregion

        private void readRomText()
        {
            try
            {
                string absoluteFilename = textBoxAbsoluteFilename.Text;

                Backend backend = new Backend();

                // *** DEBUG - requires a textbox named textBoxDebug, multiline enabled
                // Check each chunk one at a time. These will not kill the program.
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x0, 1); // Game Text
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x1000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x2000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x3000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x4000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x5000); // Game Text
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x6000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x7000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x8000); // No text here
                //backend.getText(absoluteFilename, textBoxDebug, 0x1000, 0x9000); // No text here


                backend.getText(absoluteFilename, textBox1, 0x3, 0x5DD7, 0);
                backend.getText(absoluteFilename, textBox2, 0x3, 0x5DDB, 0);
                backend.getText(absoluteFilename, textBox3, 0x3, 0x5DE1, 0);
                backend.getText(absoluteFilename, textBox4, 0x8, 0x5DE7, 0);
                backend.getText(absoluteFilename, textBox5, 0x11, 0x5DF2, 0);

                backend.getText(absoluteFilename, textBox6, 0x18, 0x5E06, 0);
                backend.getText(absoluteFilename, textBox7, 0x14, 0x5E21, 0);
                backend.getText(absoluteFilename, textBox8, 0xB, 0x5E38, 0);
                backend.getText(absoluteFilename, textBox9, 0x18, 0x5E46, 0);
                backend.getText(absoluteFilename, textBox10, 0x11, 0x5E7D, 0);

                backend.getText(absoluteFilename, textBox11, 0x9, 0x5E8F, 0);
                backend.getText(absoluteFilename, textBox12, 0x18, 0x5E9B, 0);
                backend.getText(absoluteFilename, textBox13, 0x20, 0x5EB6, 0);
                backend.getText(absoluteFilename, textBox14, 0xA, 0x5ED9, 0);
                backend.getText(absoluteFilename, textBox15, 0xF, 0x5EE6, 0);

                backend.getText(absoluteFilename, textBox16, 0x1B, 0x5EF8, 0);
                backend.getText(absoluteFilename, textBox17, 0x1B, 0x5F16, 0);
                backend.getText(absoluteFilename, textBox18, 0x1B, 0x5F34, 0);
                backend.getText(absoluteFilename, textBox19, 0x1B, 0x5F52, 0);
                backend.getText(absoluteFilename, textBox20, 0x1C, 0x5F70, 0);

                backend.getText(absoluteFilename, textBox21, 0x13, 0x5F8F, 0);
                backend.getText(absoluteFilename, textBox22, 0x4, 0x603, 1); // GAME
                backend.getText(absoluteFilename, textBox23, 0x4, 0x608, 1); // OVER
                backend.getText(absoluteFilename, textBox24, 0x8, 0x3AB, 1); // HOMEDATA
                backend.getText(absoluteFilename, textBox25, 0x8, 0xADF, 1); // INTERVAL

                backend.getText(absoluteFilename, textBox26, 0x5, 0xB58, 1); // PHASE
                backend.getText(absoluteFilename, textBox27, 0x4, 0xB5F, 1); // LEFT
                backend.getText(absoluteFilename, textBox28, 0x8, 0x35E6, 0);

                enableButtons();
                enableMenuItems();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enableButtons()
        {
            buttonUpdateText.Enabled = true;
        }

        private void enableMenuItems()
        {
            //updateTextToolStripMenuItem.Enabled = true;
        }

        //private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    AboutBox1 aboutBox = new AboutBox1();
        //    aboutBox.ShowDialog();
        //}

        //private void openROMToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    buttonOpenROM_Click(sender, e);
        //}

        private void buttonUpdateText_Click(object sender, EventArgs e)
        {
            try
            {
                string absoluteFilename = textBoxAbsoluteFilename.Text;
                Backend backend = new Backend();

                backend.updateROMText(absoluteFilename, 0x3, textBox1, 0x5DD7, 0);
                backend.updateROMText(absoluteFilename, 0x3, textBox2, 0x5DDB, 0);
                backend.updateROMText(absoluteFilename, 0x3, textBox3, 0x5DE1, 0);
                backend.updateROMText(absoluteFilename, 0x8, textBox4, 0x5DE7, 0);
                backend.updateROMText(absoluteFilename, 0x11, textBox5, 0x5DF2, 0);

                backend.updateROMText(absoluteFilename, 0x18, textBox6, 0x5E06, 0);
                backend.updateROMText(absoluteFilename, 0x14, textBox7, 0x5E21, 0);
                backend.updateROMText(absoluteFilename, 0xB, textBox8, 0x5E38, 0);
                backend.updateROMText(absoluteFilename, 0x18, textBox9, 0x5E46, 0);
                backend.updateROMText(absoluteFilename, 0x11, textBox10, 0x5E7D, 0);

                backend.updateROMText(absoluteFilename, 0x9, textBox11, 0x5E8F, 0);
                backend.updateROMText(absoluteFilename, 0x18, textBox12, 0x5E9B, 0);
                backend.updateROMText(absoluteFilename, 0x20, textBox13, 0x5EB6, 0);
                backend.updateROMText(absoluteFilename, 0xA, textBox14, 0x5ED9, 0);
                backend.updateROMText(absoluteFilename, 0xF, textBox15, 0x5EE6, 0);

                backend.updateROMText(absoluteFilename, 0x1B, textBox16, 0x5EF8, 0);
                backend.updateROMText(absoluteFilename, 0x1B, textBox17, 0x5F16, 0);
                backend.updateROMText(absoluteFilename, 0x1B, textBox18, 0x5F34, 0);
                backend.updateROMText(absoluteFilename, 0x1B, textBox19, 0x5F52, 0);
                backend.updateROMText(absoluteFilename, 0x1C, textBox20, 0x5F70, 0);

                backend.updateROMText(absoluteFilename, 0x13, textBox21, 0x5F8F, 0);
                backend.updateROMText(absoluteFilename, 0x4, textBox22, 0x603, 1); // GAME
                backend.updateROMText(absoluteFilename, 0x4, textBox23, 0x608, 1); // OVER
                backend.updateROMText(absoluteFilename, 0x8, textBox24, 0x3AB, 1); // HOMEDATA
                backend.updateROMText(absoluteFilename, 0x8, textBox25, 0xADF, 1); // INTERVAL

                backend.updateROMText(absoluteFilename, 0x5, textBox26, 0xB58, 1); // PHASE
                backend.updateROMText(absoluteFilename, 0x4, textBox27, 0xB5F, 1); // LEFT
                backend.updateROMText(absoluteFilename, 0x8, textBox28, 0x35E6, 0);

                MessageBox.Show("Updated Text!", "Sqoon NES Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setMaxLengthOfTextBoxes()
        {
            textBox1.MaxLength = 0x3;
            textBox2.MaxLength = 0x3;
            textBox3.MaxLength = 0x3;
            textBox4.MaxLength = 0x8;
            textBox5.MaxLength = 0x11;

            textBox6.MaxLength = 0x18;
            textBox7.MaxLength = 0x14;
            textBox8.MaxLength = 0xB;
            textBox9.MaxLength = 0x18;
            textBox10.MaxLength = 0x11;

            textBox11.MaxLength = 0x9;
            textBox12.MaxLength = 0x18;
            textBox13.MaxLength = 0x20;
            textBox14.MaxLength = 0xA;
            textBox15.MaxLength = 0xF;

            textBox16.MaxLength = 0x1B;
            textBox17.MaxLength = 0x1B;
            textBox18.MaxLength = 0x1B;
            textBox19.MaxLength = 0x1B;
            textBox20.MaxLength = 0x1C;

            textBox21.MaxLength = 0x13;
            textBox22.MaxLength = 0x4;
            textBox23.MaxLength = 0x4;
            textBox24.MaxLength = 0x8;
            textBox25.MaxLength = 0x8;

            textBox26.MaxLength = 0x5;
            textBox27.MaxLength = 0x4;
            textBox28.MaxLength = 0x8;
        }

        private void FormSqoonMain_Load(object sender, EventArgs e)
        {
            setMaxLengthOfTextBoxes();
        }


        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void updateTextToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    buttonUpdateText_Click(sender, e);
        //}

    }
}

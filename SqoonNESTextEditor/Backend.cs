using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqoonNESTextEditor
{
    class Backend
    {
        int textFlag = 0;

        public Backend()
        {

        }

        public void getText(string path, TextBox texboxname, int length, int offset, int table)
        {
            string romCodeString = "";
            string sqoonAsciiOut = "";
            string tempHexString = "";
            int x = 0;
            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {

                fileStream.Seek(offset, SeekOrigin.Begin);

                while (x < length)
                {
                    romCodeString = fileStream.ReadByte().ToString("X");

                    // if length is single digit add a 0 ( 1 now is 01)
                    if (romCodeString.Length == 1)
                    {
                        romCodeString = "0" + romCodeString;
                    }
                    tempHexString = romCodeString;

                    decodeROMText(tempHexString, table);

                    if (textFlag == 0)
                    {
                        sqoonAsciiOut += decodeROMText(tempHexString, table);
                    }
                    x++;

                    texboxname.Text = sqoonAsciiOut;
                }
            }
        }

        public void updateROMText(string absoluteFilename, int length, TextBox textBox, int offset, int table)
        {

            string newROMTextString = textBox.Text;

            newROMTextString = newROMTextString.PadRight(length);
            string hexReturn = "";
            string tempascii = "";
            string[] newROMTextStringArray = new string[length];
            byte[] newROMTextStringByteArray = new byte[length];
            int[] romDecimal = new int[length];
            string[] romFinal = new string[length];
            string[] romS = new string[length];

            int x = 0;
            while (x < length)
            {
                newROMTextStringArray[x] = newROMTextString[x].ToString();
                tempascii = newROMTextStringArray[x];
                hexReturn += encodeROMText(tempascii, table);
                x++;
            }

            int i = 0;
            int j = 0;
            while (i < length)
            {
                romS[i] = hexReturn[j].ToString() + hexReturn[j + 1].ToString();
                i++;
                j += 2;
            }

            int q = 0;
            while (q < length)
            {
                romDecimal[q] = int.Parse(romS[q], System.Globalization.NumberStyles.HexNumber);
                romFinal[q] = romDecimal[q].ToString();
                newROMTextStringByteArray[q] = byte.Parse(romFinal[q]);
                q++;
            }

            using (FileStream fileStream = new FileStream(@absoluteFilename, FileMode.Open, FileAccess.Write))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                q = 0;
                while (q < length)
                {
                    fileStream.WriteByte(newROMTextStringByteArray[q]);
                    q++;
                }
            }
        }

        private string decodeROMText(String tempHexString, int table)
        {
            string sqoonAscii = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "00": // table 0
                //case "20": // table 1 <-- leave this out for now, not sure if it references a placeholder anywhere
                    sqoonAscii += " ";
                    break;
                case "30":
                    sqoonAscii += "0";
                    break;
                case "31":
                    sqoonAscii += "1";
                    break;
                case "32":
                    sqoonAscii += "2";
                    break;
                case "33":
                    sqoonAscii += "3";
                    break;
                case "34":
                    sqoonAscii += "4";
                    break;
                case "35":
                    sqoonAscii += "5";
                    break;
                case "36":
                    sqoonAscii += "6";
                    break;
                case "37":
                    sqoonAscii += "7";
                    break;
                case "38":
                    sqoonAscii += "8";
                    break;
                case "39":
                    sqoonAscii += "9";
                    break;
                case "3A":
                    sqoonAscii += "©";
                    break;
                case "3C":
                    sqoonAscii += "-";
                    break;
                case "41":
                    sqoonAscii += "A";
                    break;
                case "FB":
                    sqoonAscii += "B";
                    break;
                case "43":
                    sqoonAscii += "C";
                    break;
                case "44":
                    sqoonAscii += "D";
                    break;
                case "45":
                    sqoonAscii += "E";
                    break;
                case "46":
                    sqoonAscii += "F";
                    break;
                case "42": // table 0
                case "47": // table 1
                    sqoonAscii += "G";
                    break;
                case "48":
                    sqoonAscii += "H";
                    break;
                case "49":
                    sqoonAscii += "I";
                    break;
                case "3E":
                    sqoonAscii += "J";
                    break;
                case "51":
                    sqoonAscii += "K";
                    break;
                case "4C":
                    sqoonAscii += "L";
                    break;
                case "4D":
                    sqoonAscii += "M";
                    break;
                case "4E":
                    sqoonAscii += "N";
                    break;
                case "4F":
                    sqoonAscii += "O";
                    break;
                case "50":
                    sqoonAscii += "P";
                    break;
                case "56":
                    if(table == 0)
                    {
                        sqoonAscii += "Q"; // table 0
                    }
                    else
                    {
                        sqoonAscii += "V"; // table 1
                    }
                    break;
                case "52":
                    sqoonAscii += "R";
                    break;
                case "53":
                    sqoonAscii += "S";
                    break;
                case "54":
                    sqoonAscii += "T";
                    break;
                case "55":
                    sqoonAscii += "U";
                    break;
                //case "56": // table 1
                case "D4":
                    sqoonAscii += "V";
                    break;
                case "5A":
                    sqoonAscii += "W";
                    break;
                //case "??": // There is no letter X in this ROM.
                //    sqoonAscii += "X";
                //    break;
                case "59":
                    sqoonAscii += "Y";
                    break;
                //case "??": // There is no letter Z in this ROM.
                //    sqoonAscii += "Z";
                //    break;
                //case "AF":
                case "3F":
                    sqoonAscii += ".";
                    break;
                case "D3":
                    sqoonAscii += "!";
                    break;
                default:
                    sqoonAscii += " ";
                    textFlag = 1;
                    break;
            }

            return sqoonAscii;
        }

        private string encodeROMText(string tempascii, int table)
        {
            string sqoonHex = "";
            tempascii = tempascii.ToUpper();

            switch (tempascii)
            {
                case " ":
                    sqoonHex += "00";
                    break;
                case ".":
                    sqoonHex += "3F";
                    break;
                case "-":
                    sqoonHex += "3C";
                    break;
                case "!":
                    sqoonHex += "D3";
                    break;
                case "0":
                    sqoonHex += "30";
                    break;
                case "1":
                    sqoonHex += "31";
                    break;
                case "2":
                    sqoonHex += "32";
                    break;
                case "3":
                    sqoonHex += "33";
                    break;
                case "4":
                    sqoonHex += "34";
                    break;
                case "5":
                    sqoonHex += "35";
                    break;
                case "6":
                    sqoonHex += "36";
                    break;
                case "7":
                    sqoonHex += "37";
                    break;
                case "8":
                    sqoonHex += "38";
                    break;
                case "9":
                    sqoonHex += "39";
                    break;
                case "©":
                    sqoonHex += "3A";
                    break;
                case "A":
                    sqoonHex += "41";
                    break;
                case "B":
                    sqoonHex += "FB";
                    break;
                case "C":
                    sqoonHex += "43";
                    break;
                case "D":
                    sqoonHex += "44";
                    break;
                case "E":
                    sqoonHex += "45";
                    break;
                case "F":
                    sqoonHex += "46";
                    break;
                case "G":
                    if(table == 0)
                    {
                        sqoonHex += "42"; // table 0
                    }
                    else
                    {
                        sqoonHex += "47"; // table 1
                    }
                    
                    break;
                case "H":
                    sqoonHex += "48";
                    break;
                case "I":
                    sqoonHex += "49";
                    break;
                case "J":
                    sqoonHex += "3E";
                    break;
                case "K":
                    sqoonHex += "51";
                    break;
                case "L":
                    sqoonHex += "4C";
                    break;
                case "M":
                    sqoonHex += "4D";
                    break;
                case "N":
                    sqoonHex += "4E";
                    break;
                case "O":
                    sqoonHex += "4F";
                    break;
                case "P":
                    sqoonHex += "50";
                    break;
                case "Q":
                    if (table == 0)
                    {
                        sqoonHex += "56";
                    }
                    else
                    {
                        sqoonHex += "00"; // Table 1 uses V for value 56, not sure what Q is or if it exists here.
                    }
                    
                    break;
                case "R":
                    sqoonHex += "52";
                    break;
                case "S":
                    sqoonHex += "53";
                    break;
                case "T":
                    sqoonHex += "54";
                    break;
                case "U":
                    sqoonHex += "55";
                    break;
                case "V":
                    if(table == 0)
                    {
                        sqoonHex += "D4"; // table 0
                    }
                    else
                    {
                        sqoonHex += "56"; // table 1
                    }
                    
                    break;
                case "W":
                    sqoonHex += "5A";
                    break;
                //case "X": // There is no letter X in this ROM.
                //    sqoonHex += "00";
                //    break;
                case "Y":
                    sqoonHex += "59";
                    break;
                //case "Z": // There is no letter Z in this ROM.
                //    sqoonHex += "00";
                //    break;
                default: // space if not matches found
                    sqoonHex += "00";
                    break;
            }

            return sqoonHex;
        }
    }
}

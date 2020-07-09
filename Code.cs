using System;
namespace Assembler
{
    public class Code
    {
        public Code()
        {
        }

        public string dest(string des)
        {
            if (des == "null")
            {
                return "000";
            }
            else if (des == "M")
            {
                return "001";
            }
            else if (des == "D")
            {
                return "010";
            }
            else if (des == "MD")
            {
                return "011";
            }
            else if (des == "A")
            {
                return "100";
            }
            else if (des == "AM")
            {
                return "101";
            }
            else if (des == "AD")
            {
                return "110";
            }
            else //if(des == "AMD")
            {
                return "111";
            }
        }

        public string comp(string com)
        {
            if (com == "0")
            {
                return "0101010";
            }
            else if (com == "1")
            {
                return "0111111";
            }
            else if (com == "-1")
            {
                return "0111010";
            }
            else if (com == "D")
            {
                return "0001100";
            }
            else if (com == "A")
            {
                return "0110000";
            }
            else if (com == "!D")
            {
                return "0001101";
            }
            else if (com == "!A")
            {
                return "0110001";
            }
            else if (com == "-D")
            {
                return "0001111";
            }
            else if (com == "-A")
            {
                return "0110011";
            }
            else if (com == "D+1")
            {
                return "0011111";
            }
            else if (com == "A+1")
            {
                return "0110111";
            }
            else if (com == "D-1")
            {
                return "0001110";
            }
            else if (com == "A-1")
            {
                return "0110010";
            }
            else if (com == "D+A")
            {
                return "0000010";
            }
            else if (com == "D-A")
            {
                return "0010011";
            }
            else if (com == "A-D")
            {
                return "0000111";
            }
            else if (com == "D&A")
            {
                return "0000000";
            }
            else if (com == "D|A")
            {
                return "0010101";
            }
            else if (com == "M")
            {
                return "1110000";
            }
            else if (com == "!M")
            {
                return "1110001";
            }
            else if (com == "-M")
            {
                return "1110011";
            }
            else if (com == "M+1")
            {
                return "1110111";
            }
            else if (com == "M-1")
            {
                return "1110010";
            }
            else if (com == "D+M")
            {
                return "1000010";
            }
            else if (com == "D-M")
            {
                return "1010011";
            }
            else if (com == "M-D")
            {
                return "1000111";
            }
            else if (com == "D&M")
            {
                return "1000000";
            }
            else if (com == "D|M")
            {
                return "1010101";
            }
            else
            {
                return "error";
            }
        }

        public string jump(string jum)
        {
            if (jum == "null")
            {
                return "000";
            }
            if (jum == "JGT")
            {
                return "001";
            }
            if (jum == "JEQ")
            {
                return "010";
            }
            if (jum == "JGE")
            {
                return "011";
            }
            if (jum == "JLT")
            {
                return "100";
            }
            if (jum == "JNE")
            {
                return "101";
            }
            if (jum == "JLE")
            {
                return "110";
            }
            else//if (jum == "JMP")
            {
                return "111";
            }
        }
    }
}

using System;
using System.IO;

namespace Assembler
{
    static class Program
    {
        static void Main()
        {
            string title = "Pong"; //Name of source file
            string title2 = "pong"; //Name for file path
                        
            string outfile = "/Applications/nand2tetris/projects/06/"+title2+"/" + title + ".hack";
            bool hasMoreCommands=true;
            string type;
            int nextMem = 16;
            int counter = 0 ;


            Parser p1 = new Parser("/Applications/nand2tetris/projects/06/" + title2 + "/" + title + ".asm");
            SymbolTable st = new SymbolTable();
            while (hasMoreCommands == true)                                     //First
            {
                p1.advance();
                type = p1.commandType();
                if (type == "L_COMMAND")
                {
                    st.addEntry(p1.symbol(), counter);
                }
                else
                {
                    counter += 1;
                    hasMoreCommands = p1.hasMoreCommands();
                }

            }

            hasMoreCommands = true;
            Parser p = new Parser("/Applications/nand2tetris/projects/06/" + title2 + "/" + title + ".asm");
            Code c = new Code();
            while (hasMoreCommands == true)                                     //Second
            {
                p.advance();
                type = p.commandType();
                if (type == "A_COMMAND")
                {
                    string varOrNum = p.symbol();
                    char von = varOrNum[0];

                    if (char.IsDigit(von) == true)
                    {
                        int prexxx = Convert.ToInt32(p.symbol());
                        string xxx = Convert.ToString(prexxx, 2).PadLeft(16, '0');
                        using (StreamWriter sw = new StreamWriter(outfile, true))
                        {
                            sw.WriteLine(xxx);
                        }
                    }
                    else //if(char.IsDigit(von)==false), which means xxx is variable.
                    {
                        bool cont = st.contains(varOrNum);
                        if (cont == false)
                        {
                            st.addEntry(varOrNum, nextMem);
                            string xxx = Convert.ToString(nextMem, 2).PadLeft(16, '0');
                            using (StreamWriter sw = new StreamWriter(outfile, true))
                            {
                                sw.WriteLine(xxx);
                            }
                            nextMem += 1;
                        }
                        else
                        {
                            string xxx=Convert.ToString(st.getAddress(varOrNum),2).PadLeft(16,'0');
                            using (StreamWriter sw = new StreamWriter(outfile, true))
                            {
                                sw.WriteLine(xxx);
                            }
                        }
                    }
                }
                else if (type == "C_COMMAND")
                {
                    string destmne = p.dest();
                    string dest = c.dest(destmne);

                    string compmne = p.comp();
                    string comp = c.comp(compmne);

                    string jumpmne = p.jump();
                    string jump = c.jump(jumpmne);

                    string c_command = "111" + comp + dest + jump;
                    using (StreamWriter sw = new StreamWriter(outfile, true))
                    {
                        sw.WriteLine(c_command);
                    }
                }
                else //if (type=="L_COMMAND")
                {                }
            
                hasMoreCommands = p.hasMoreCommands();
            }
        }
    }
}

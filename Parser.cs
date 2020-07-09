using System;
using System.IO;
using System.Collections;

namespace Assembler
{
    public class Parser
    {
        ArrayList commands;
        int num=0;
        string now;

        public Parser(string filename)
        {
            commands = new ArrayList();
            bool end;
            string line;
            char[] check;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((end = sr.EndOfStream) == false)
                {
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        line = line.Replace(" ", "");  　　　　　　　　　　　　　　　//Deleting spaces
                        check = line.ToCharArray();
                        for (int i = 0; i < check.Length; i++)
                        {
                            if (check[i] == '/' && check[i + 1] == '/')
                            {
                                line = new String(check, 0, i);
                            }
                        }
                            if (!string.IsNullOrEmpty(line))
                            {
                                commands.Add(line);
                            }
                        }
                }
            }
        }
        public bool hasMoreCommands()
        {
            if (num >= commands.Count) { return false; }
            else { return true; }
        }

        public void advance()
        {
            now = Convert.ToString(commands[num]);
            num += 1;
        }

        public string commandType()
        {
            char ch = now[0];

            if (ch == '@')
            {
                return "A_COMMAND";
            }
            else if (ch == '(')
            {
                return "L_COMMAND";
            }
            else { return "C_COMMAND"; }
        }

        public string symbol()
        {
            char[] ch = now.ToCharArray();

            if (ch[0] == '@')
            {
                string sym = now.Replace("@", "");
                return sym;
            }
            else //if(ch[0]=='(')
            {
                string sym = now.Replace("(", "");
                sym = sym.Replace(")", "");
                return sym;
            }
        }

        public string dest()
        {
            char[] ch = now.ToCharArray();
            string des = "null";
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == '=')
                {
                    des = new String(ch, 0, i);
                }
                else { }
            }
            return des;
        }

        public string comp()
        {
            char[] ch = now.ToCharArray();
            string com="";
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == '=')
                {
                    com = new String(ch, i + 1, ch.Length - i - 1);
                }
                else if (ch[i] == ';')
                {
                    com = new String(ch, 0, i);
                }
                else
                {}
            }
            return com;
        }

        public string jump()
        {
            char[] ch = now.ToCharArray();
            if (ch[1] == ';')
            {
                string jum = new String(ch,2,ch.Length-2);
                return jum;
            }
            else { return "null"; }
        }
    }
}
using System;
using System.Collections;

namespace Assembler
{
    public class SymbolTable
    {
        Hashtable table;

        public SymbolTable()
        {
            table = new Hashtable();
            table.Add("SP", 0);
            table.Add("LCL", 1);
            table.Add("ARG", 2);
            table.Add("THIS", 3);
            table.Add("THAT", 4);
            for (int i = 0; i <= 15; i++)
            {
                table.Add("R" + i, i);
            }
            table.Add("SCREEN", 16384);
            table.Add("KBD", 24576);
        }

        public void addEntry(string symbol, int address)
        {
            table.Add(symbol, address);
        }

        public bool contains(string symbol)
        {
            bool cont = table.ContainsKey(symbol);
            return cont;
        }

        public int getAddress(string symbol)
        {
            int ad = (int)table[symbol];

            return ad;
        }
    }
}

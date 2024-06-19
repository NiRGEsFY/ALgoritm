using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALgoritm
{
    public  class machineTuring
    {
        private string line {  get; set; }
        private char[] chars { get; set; }
        private string[][] rule { get; set; }
        private int indexPointer { get; set; }
        private int index = 0;
        private int memFirstNumber = 0;
        private int memLastNumber = 0;
        bool chooseAddition = true;

        public machineTuring(string inLine, char[] inChars, string[][] inRule) {
            this.line = inLine;
            this.chars = inChars;
            this.rule = inRule;
            indexPointer = 0;
            index = 0;
        }
        public void StartMath()
        {
            while (nextMoveMath()) ;
                
        }
        public bool nextMoveMath()
        {

            var temp = line[index];
            var x = Array.IndexOf(chars, temp);
            var y = indexPointer;
            string tempRule = rule[x][y];
            char setChar = ' ';
            foreach (var charact in tempRule)
            {
                if (charact == '\'')
                {
                    int indexChar = tempRule.IndexOf('\'');
                    setChar = tempRule[indexChar + 1];
                    if (setChar == '1')
                    {
                        if (chooseAddition)
                        {
                            memFirstNumber++;
                        }
                        else
                        {
                            memLastNumber++;
                        }
                    }
                    else if(setChar=='/')
                    {
                        chooseAddition = !chooseAddition;
                    }
                    StringBuilder sb = new StringBuilder(line);
                    sb[index] = setChar;
                    line = sb.ToString();
                }
                else if (charact == 'R')
                {
                    index++;
                    if (index >= line.Length)
                    {
                        line = line + chars.LastOrDefault();
                    }
                }
                else if (charact == 'L')
                {
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                        line = chars.LastOrDefault() + line;
                    }
                }
                else if (charact == 'Q')
                {
                    int indexChar = tempRule.IndexOf('Q');
                    indexPointer = int.Parse(tempRule[indexChar + 1].ToString());
                }
                else if (charact == '.')
                {
                    Console.WriteLine(line + $" {memFirstNumber % memLastNumber} " + " End.");
                    return false;
                }
            }
            Console.WriteLine(line);
            return true;
        }
        public void Start()
        {
            while (nextMove())
            {
                
            }
        }
        public bool nextMove()
        {
            
            var temp = line[index];
            var x = Array.IndexOf(chars, temp);
            var y = indexPointer;
            string tempRule = rule[x][y];
            char setChar = ' ';
            Console.Write(line + " -> ");
            foreach (var charact in tempRule)
            {
                if (charact == '\'')
                {
                    int indexChar = tempRule.IndexOf('\'');
                    setChar = tempRule[indexChar + 1];
                    StringBuilder sb = new StringBuilder(line);
                    sb[index] = setChar;
                    line = sb.ToString();
                }
                else if(charact == 'R'){
                    index++;
                    if (index >= line.Length)
                    {
                        line = line + chars.LastOrDefault();
                    }
                }
                else if (charact == 'L')
                {
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                        line = chars.LastOrDefault() + line;
                    }
                }
                else if (charact == 'Q')
                {
                    int indexChar = tempRule.IndexOf('Q');
                    indexPointer = int.Parse(tempRule[indexChar + 1].ToString());
                }
                else if (charact == '.')
                {
                    Console.WriteLine(line + " End.");
                    return false;
                }
            }
            Console.WriteLine(line);
            return true;
        }
        public void setPointer (int pointer) {
            indexPointer = pointer-1;
        }

        public void setStart (int input)
        {
            index = input;
        }
        public void setLine(string input)
        {
            line = input;
        }
        public void setChars(char[] input)
        {
            char[] chars = input;
        }
        public void setRule(string[][] input)
        {
            rule = input;
        }
    }
}

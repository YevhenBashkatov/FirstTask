using System;

namespace FirstTask
{

    static class Cryptographer
    {

       
        static public string Encrypt(string text, int n)
        {
           // Checking reguirements of the technical task  
            if ((text == null) || (n <= 0)) { return text; }
            else
            {
                // Creating Array of chars from IN_text (textArray) and empty Array of chars same size (tempArray)
                // tempArray will be deleted by garbage collector when task will be completed
                char[] textArray = text.ToCharArray();
                char[] tempArray = new char[textArray.Length];


                for (int j = 0; j < n; j++)
                {
                    // Creating variable for remembering even and odd position in tempArray
                    int evenPositionCount = 0;
                    int oddPositionCount = 0;

                    for (int i = 1; i < textArray.Length; i += 2)
                    {
                        tempArray[evenPositionCount] = textArray[i];
                        evenPositionCount += 1;
                    }

                    for (int i = 0; i < textArray.Length; i += 2)
                    {

                        tempArray[textArray.Length / 2 + oddPositionCount] = textArray[i];
                        oddPositionCount += 1;
                    }
                    tempArray.CopyTo(textArray, 0);

                }
                /*
                foreach (char k in tempArr)
                {
                    Console.WriteLine(k);
                }
                */
                //Converting new string from char array
                text = new String(tempArray);

                return text;
            }
        }


        //Decrypt code is similar to Encrypt
        static public string Decrypt(string encrypted_text, int n)
        {
            if ((encrypted_text == null) || (n <= 0)) { return encrypted_text; }
            else
            {
                char[] textArray = encrypted_text.ToCharArray();
                char[] tempArray = new char[textArray.Length];

                for (int k = 0; k < n; k++)
                {
                    int evenPositionCount = 0;
                    int oddPositionCount = 0;

                    for (int i = 0; i < textArray.Length; i += 2)
                    {

                        tempArray[i] = textArray[textArray.Length / 2 + oddPositionCount];
                        oddPositionCount++;

                    }

                    for (int j = 1; j < textArray.Length; j += 2)
                    {

                        tempArray[j] = textArray[evenPositionCount];
                        evenPositionCount++;

                    }

                    tempArray.CopyTo(textArray, 0);



                }

                encrypted_text = new String(tempArray);

                return encrypted_text;
            }

        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            // Expected: IN abcdefghij ----- OUT bdfhjacegi ------ OK! 
            Console.WriteLine(Cryptographer.Encrypt("abcdefghij", 1));

            // Expected: IN bdfhjacegi ----- OUT abcdefghij ------ OK!
            Console.WriteLine(Cryptographer.Decrypt(Cryptographer.Encrypt("abcdefghij", 1), 1));

        }
    }
}

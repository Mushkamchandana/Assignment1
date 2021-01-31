using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
                //Question 1
                Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
                int n = Convert.ToInt32(Console.ReadLine());
                printTriangle(n);
                Console.WriteLine();


                //Question 2:           
                Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
                int n2 = Convert.ToInt32(Console.ReadLine());
                printPellSeries(n2);
                Console.WriteLine();



                //Question 3:            
                Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
                int n3 = Convert.ToInt32(Console.ReadLine());
                bool flag = squareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");

                }


                //Question 4:           
                int[] arr = { 3, 1, 4, 1, 5 };
                Console.WriteLine("Q4: Enter the absolute difference to check");
                int k = Convert.ToInt32(Console.ReadLine());
                int n4 = diffPairs(arr, k);
                Console.WriteLine("There exists {0} pairs with the given difference", n4);


                //Question 5:        
                List<string> emails = new List<string>();
                emails.Add("dis.email + bull@usf.com");
                emails.Add("dis.e.mail+bob.cathy@usf.com");
                emails.Add("disemail+david@us.f.com");
                int ans5 = UniqueEmails(emails);
                Console.WriteLine("Q5");
                Console.WriteLine("The number of unique emails is " + ans5);

                //Quesiton 6:          
                string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };
                string destination = DestCity(paths);
                Console.WriteLine("Q6");
                Console.WriteLine("Destination city is " + destination);
            
            
          
            }
        private static void printTriangle(int n)
        {
            try
            {
                // to print triangle pattern for a given input n 
                for(int k = 1; k<=n; k++)
                {
                    for(int i= n-k; i>=0; i--)//will print space till n-k spots, where n is number of the line 
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j<= 2 * k - 1; j++) //will print * till 2k-1 times
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");

                }
            }
            catch(Exception)
            {
                Console.WriteLine("Exception occured while computing Factorial method");
            }//end of catch

        }//End of PrintTriangle

        private static void printPellSeries(int n2)
        {
            try
            {
                //to print pell numbers for a given a given input
                int a = 0;
                int b = 1;
                int pell;
                if (n2 == 1)//will print 0 for n2=1
                {
                    Console.WriteLine(0);
                }
                else if (n2 == 2)//will print 1 for n2=2
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(0);
                    Console.WriteLine(1);
                    for (int i = 3; i <= n2; i++) //will print pell numbers from i=3
                    {
                        pell = a + 2 * b;
                        a = b;
                        b = pell;       

                        Console.WriteLine(pell);

                    }
                }


            }  
            catch (Exception)  
            
            {

                Console.WriteLine("Exception occured while computing printPellSeries method");     
            }    //end of catch.
        }// end of printPellSeries.
        private static bool squareSums(int n3)
        {
            try
            {
                // to  print a boolean value as true if the value given is sum of squares, False if it is not sum of sqaures. 
                bool k = false;
                if (n3 == 1)
                {
                    return(true);
                }
                else
                {
                    for (int i = 0; i <= (n3 / 2); i++)//p(n-1)
                    {
                        for (int j = i; j <= (n3 / 2); j++)//p(n-2)
                        {
                            if ((i * i) + (j * j) == n3)
                            {
                                k = true;
                            }
                        }
                    }
                    return(k);
                }

            }
            catch (Exception)            
            {
                Console.WriteLine("exception occured while computing squareSeries method");

               throw;            
            }  //end of catch      
        }//end of squareSums
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                // to print count of absolute different pairs in a given array  for a input k
                int n = nums.Length;
                int count = 0;
                //
                for (int i = 0; i < n; i++)
                {
                    // check whether there is a pair for given input k
                    
                    for (int j = i + 1; j < n; j++)
                        if (nums[i] - nums[j] == k ||
                              nums[j] - nums[i] == k)
                            count++;
                }

                return count;
               
            }           
            catch (Exception e)      
            {             
                Console.WriteLine("An error occured: " + e.Message);     
            throw;      
            }  //end of catch   
        }// end of diffpairs

        private static int UniqueEmails(List<string> emails)
        {
            try
            {  
                //to print unique emails for a given input
                List<string> new_email = new List<string>();
                foreach (string s in emails)

                {
                    string mail = string.Empty;
                    int a = 0;//to track @
                    int b = 0;// to track +
                    foreach (char c in s)//to track each char
                    {
                        if (a == 1)
                        {
                            mail = mail + c;
                            continue;
                        }
                        else if (c == '+')
                        {
                            b = 1;
                            continue;
                        }
                        else if (c == '@')
                        {
                            a = 1;
                            b = 0;
                            mail = mail + c;
                            continue;
                        }
                        else if ((a == 0 && c == '.') || b == 1)
                        {
                            continue;
                        }
                        else
                        {
                            mail = mail + c;
                        }

                    }
                    new_email.Add(mail);//adding each modified email to the list new_email
                }
                var g = new_email.GroupBy(i => i);//grouping the strings in a list
                int sum = 0;
                foreach (var grp in g)
                {
                    sum = sum + 1;
                }
                return(sum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            } // end of catch       
        }//end of unique mails

        private static string DestCity(string[,] paths)
        {
            try
            {    
                //to print destination city for a given input 
                for (int i = 0; i < (paths.Length) / 2; i++)//To capture (from) city
                {
                    int a = 0;
                    for (int j = 0; j < (paths.Length) / 2; j++)//To capture (to) city
                    {
                        if (paths[i, 1] == paths[j, 0])
                        {
                            a = a + 1;
                        }
                    }
                    if (a < 1)
                    {
                        return paths[i, 1];
                    }
                }
                return string.Empty;
            }            
            catch (Exception)            
            {
                Console.WriteLine("Exception occured while computing DestCity");
               throw;           
            
            }   //end of catch     
        } //end of DestCity 

    }
}//Self reflection: 
        //   1.This assignment demands learning C# basics like,
         // - Conditional statements
         // - Iterative statements
         // - Method declaration and calling
         // - Array declaration and population
        // 2. This assignment helped me in understanding the essence of Console.WriteLine, which is a great help  
         //   in solving logical errors.
         //3. This assignment made sure I understand the errors and the ways to solve them.
         
        // Recommendations:
         //1.More questions on topic arrays should have been included (atleast one more question).
        // 2.Instead of triangle with *, a triangle with number series would have been more interesting. */



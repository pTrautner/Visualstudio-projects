//used code for writing/reading .txt file from https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
//The program requires access to /(UE3.2.sln path)/bin/Debug/net6.0/StorageUE32
namespace MyApplication
{
    class Program
    {
        //constant string for the password and constant int for remaining attempts to configure
        const string Correctpassword = "Admin";
        const int RemainingAttempts = 3;
        static void Main(string[] args)
        {
            String line;
            try
            {
                //Passes the file path and file name to the StreamReader constructor 
                StreamReader sr = new StreamReader("./StorageUE32.txt");
                //Reads the first line of text file
                line = sr.ReadLine();
                // continues reading until end of txt file
                while (line != null)
                {
                    //first line is assigned to activation status string
                    string activationstatus = line;
                    //if the program is started with an deactivated account, user is asked to contact admin > exit program unless a "backdoor" password (superadmin)is entered
                    if (activationstatus == "0")
                    {
                        Console.WriteLine("Please contact your admin(Too many incorrect attempts)");
                        string Backdoor = Console.ReadLine();
                        if (Backdoor == "superadmin")
                        {

                            break;
                        }
                        else
                        Environment.Exit(0);
                    }
                    //loop break if account is activated
                    if (activationstatus == "1")
                    {
                        break;
                    }

                }
                //closes txt file
                sr.Close();
            }
            // try/catch loop: used in example, not sure if neccesary here
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //declaring user input and attempts to compare to presets
            string enteredpassword;
            int count = 1;
            Repeat:
            do
            {
                //check if attempt count is larger than preset max
                if (count > RemainingAttempts)
                {
                    //Changes value in txt. file and exits program
                    Console.WriteLine($"Too many incorrect attempts");
                    StreamWriter sw = new StreamWriter("./StorageUE32.txt");
                    sw.WriteLine("0");
                    sw.Close();
                    Environment.Exit(0);
                }
                // request password input and display remaining attempts: "count + 1" so it doesnt say 3,2,1,0 remaining attempts
                Console.WriteLine($"Enter password (remaining attempts: {RemainingAttempts - count + 1} )" );
                //convert input to string
                enteredpassword = Console.ReadLine();
                //compare input pass to preset pass, resets the account activation in case the user was previously logged out, then breaks loop
                if (enteredpassword == Correctpassword)
                {
                    count = 1;
                    Console.WriteLine("You have succesfully logged in");
                    StreamWriter sw = new StreamWriter("./StorageUE32.txt");
                    sw.WriteLine("1");
                    sw.Close();
                    break;
                }
                //loop count increment
                count++;
            // loop continues while input is wrong
            } while (enteredpassword != Correctpassword);
            
            Console.WriteLine("Press [y] and hit [Enter] to log out or press any key to see some sick ASCII");
            string response = Console.ReadLine();
            if (response == "y")
            {
                //reverts to login if requested by user
                goto Repeat;
            }
            else
                Console.Title = "ASCII Art";
            string title = @"
  _/      _/  _/_/_/_/  _/_/_/    _/      _/   
 _/      _/  _/        _/    _/    _/  _/      
_/      _/  _/_/_/    _/_/_/        _/         
 _/  _/    _/        _/    _/      _/          
  _/      _/_/_/_/  _/    _/      _/           
                                               
                                               
                                        
     _/_/_/    _/_/      _/_/    _/     
  _/        _/    _/  _/    _/  _/      
 _/        _/    _/  _/    _/  _/       
_/        _/    _/  _/    _/  _/        
 _/_/_/    _/_/      _/_/    _/_/_/_/   
                                        
                                        
                                                   
      _/_/      _/_/_/    _/_/_/  _/_/_/  _/_/_/   
   _/    _/  _/        _/          _/      _/      
  _/_/_/_/    _/_/    _/          _/      _/       
 _/    _/        _/  _/          _/      _/        
_/    _/  _/_/_/      _/_/_/  _/_/_/  _/_/_/     
                                                                 ";

            Console.WriteLine(title);
            Console.Read();
            // placeholder for whatever program the login is for
        }
    }
}

using System;

namespace URLEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("URL Encoder");

            do
            {
                Console.Write("\nProject name: ");
                string projectName = GetUserInput();
                Console.Write("Activity name: ");
                string activityName = GetUserInput();

                Console.WriteLine(CreateURL(Encode(projectName), Encode(activityName)));

                Console.Write("Would you like to do another? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string CreateURL(string projectName, string activityName)
        {
            string url = "https://companyserver.com/content/" + projectName + "/files/" + activityName + "/" + activityName + "Report.pdf";
            return url;
        }

        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.Write("The input contains invalid characters. Enter again: ");
            } while (true);
        }

        static bool IsValid(string input)
        {
            foreach (char character in input.ToCharArray())
                if (char.IsControl(character))
                    return false;
            return true;
        }

        static string Encode(string value)
        {
            string encodedValue = "";
            char dummy;
            foreach (char character in value.ToCharArray())
            {
                dummy = character;
                switch (dummy)
                {
                    case '<':
                        encodedValue += "%3C";
                        break;
                    case '>':
                        encodedValue += "%3E";
                        break;
                    case '#':
                        encodedValue += "%23";
                        break;
                    case '%':
                        encodedValue += "%25";
                        break;
                    case '"':
                        encodedValue += "%93";
                        break;
                    case ';':
                        encodedValue += "%3B";
                        break;
                    case '/':
                        encodedValue += "%2F";
                        break;
                    case '?':
                        encodedValue += "%3F";
                        break;
                    case ':':
                        encodedValue += "%3A";
                        break;
                    case '@':
                        encodedValue += "%40";
                        break;
                    case '&':
                        encodedValue += "%26";
                        break;
                    case '=':
                        encodedValue += "%3D";
                        break;
                    case '+':
                        encodedValue += "%2B";
                        break;
                    case '$':
                        encodedValue += "%24F";
                        break;
                    case '{':
                        encodedValue += "%7B";
                        break;
                    case '}':
                        encodedValue += "%7D";
                        break;
                    case '|':
                        encodedValue += "%7C";
                        break;
                    case '\\':
                        encodedValue += "%5C";
                        break;
                    case '^':
                        encodedValue += "%5C";
                        break;
                    case '[':
                        encodedValue += "%5B";
                        break;
                    case ']':
                        encodedValue += "%5D";
                        break;
                    case '`':
                        encodedValue += "%60";
                        break;
                    case ' ':
                        encodedValue += "%20";
                        break;
                    default:
                        encodedValue += dummy;
                        break;
                }
            }
            return encodedValue;
        }
    }
}

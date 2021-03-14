using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public class UserOperation : IUserOperation
    {

        

        public UserOperation()
        {
        }
        public UserResult Create(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
                throw new Exception("UserNameEmpty");

            string encryptedPassword = Encrypt(user.Password);
            user.Password = encryptedPassword;

            WriteToFile(user);

            return new UserResult { IsSuccess = true, CreatedDate = DateTime.Now };

        }
        public string Encrypt(string password)
        {
            var passwordChars = password.ToCharArray();   // ToCharArray() : String değeri karakterlerine ayırarak dizi şeklinde geri döner yani bırada paswordChar değişkeni bir dizi ve her bir indisinde password ün karakterlerini içeriyor
            StringBuilder passwordBuilder = new StringBuilder(); //Karakterlerin şifrelenmiş değerlerini yan yana yazmak için... KArakterleri artı String olarakda bağlayabiliriz ancak daha büyük programlarda bu sıkıntı çıkartabilir

            foreach (var passwordChar in passwordChars)
            {
                passwordBuilder.Append((int)passwordChar);  // Append : parametresine gönderilen değerler string biçimde birleştirilir
            }
            return passwordBuilder.ToString();
        }
        private const string FILE_PATH = "C:\\Users\\ASUS\\Desktop\\web\\uye.txt";

        public FileResult WriteToFile(User user)
        {
            using (StreamWriter fileWriter = File.AppendText(FILE_PATH))
            {
                fileWriter.WriteLine(string.Format("{0};{1}", user.UserName, user.Password));
                fileWriter.Flush();
            }

            return new FileResult { IsSuccess = true };
        }
        public User ReadFromFile(string userName)
        {
            using (StreamReader fileReader = new StreamReader(FILE_PATH))
            {
                bool isFileEnd = true;
                var UserRes = new User();
                int Status = 400;
                while (isFileEnd)
                {
                    string line = fileReader.ReadLine();
                    if (string.IsNullOrEmpty(line))

                        break;


                    var splitedLine = line.Split(';');
                    if (splitedLine[0] == userName)
                    {
                        UserRes = new User { UserName = splitedLine[0], Password = splitedLine[1] };
                        Status = 200;
                    }

                }
                if (Status == 200)
                {
                    return UserRes;
                }
                else
                {
                    return new User { UserName = "", Password = "" }; ;
                }

            }
            throw new Exception("UserNotFound");
        }

    }

}
